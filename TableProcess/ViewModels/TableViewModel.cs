/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：TableViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:50:41
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TableProcess.Common;
using TableProcess.Models;
using TableProcess.Services;
using TableProcess.Services.Interfaces;
using TableProcess.ViewCenters;

namespace TableProcess.ViewModels
{
    public class TableViewModel : BaseViewModel
    {
        private string _folderPath;
        private string _queryText;
        private ObservableCollection<ExcelFileInfoModel> _excelFileInfos;
        private List<ExcelFileInfoModel> _dataSource = new List<ExcelFileInfoModel>();
        private ExcelFileInfoModel _currentExcel;

        public string FolderPath
        {
            get => _folderPath;
            set { _folderPath = value; RaisePropertyChanged(); }
        }
        public string QueryText
        {
            get => _queryText;
            set { _queryText = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<ExcelFileInfoModel> ExcelFileInfos
        {
            get => _excelFileInfos;
            set { _excelFileInfos = value; RaisePropertyChanged(); }
        }

        public ExcelFileInfoModel CurrentExcel
        {
            get => _currentExcel;
            set
            {
                _currentExcel = value; RaisePropertyChanged();
            }
        }

        public RelayCommand SelectFolderCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand QueryCommand { get; set; }
        public RelayCommand EditExcelDataCommand { get; set; }
        public RelayCommand SelectFileCommand { get; set; }
        public TableViewModel()
        {
            SelectFolderCommand = new RelayCommand(SelectFolder);
            RefreshCommand = new RelayCommand(RefreshFolderFile);
            QueryCommand = new RelayCommand(QueryExcel);
            EditExcelDataCommand = new RelayCommand(EditExcelData);
            SelectFileCommand = new RelayCommand(SelectFile);
        }

        private void SelectFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择文件夹";
            if (fbd.ShowDialog() != DialogResult.OK) return;
            FolderPath = fbd.SelectedPath;
            GetExcelFilesDataSource();
        }

        private void RefreshFolderFile()
        {
            GetExcelFilesDataSource();
        }
        private void QueryExcel()
        {
            var input = QueryText?.Trim();
            var info = _dataSource.Where(e => e.Name.ToLower().Contains(input?.ToLower()))
                .OrderByDescending(e => e.Date).ToList();
            ObservableCollection<ExcelFileInfoModel> temp = new ObservableCollection<ExcelFileInfoModel>();
            info.ForEach(e => temp.Add(e));
            ExcelFileInfos = temp;
        }

        private async void EditExcelData()
        {
            if (!JudgeFileState(CurrentExcel.Path)) return;
            var module = (EditTableCenter)AutofacProvider.Get<IModuleDialog>(nameof(EditTableCenter));
            await module.ShowDialog(CurrentExcel);
        }
        private void GetExcelFilesDataSource()
        {
            if (string.IsNullOrWhiteSpace(FolderPath)) return;
            _dataSource.Clear();
            GetExcelFiles(FolderPath);
            ObservableCollection<ExcelFileInfoModel> temp = new ObservableCollection<ExcelFileInfoModel>();
            _dataSource.ForEach(e => temp.Add(e));
            ExcelFileInfos = temp;
        }
        private async void SelectFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择数货单Excel文件";
            openFileDialog.Filter = "Excel文件|*.xls;*.xlsx";
            openFileDialog.FileName = string.Empty;
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.DefaultExt = "xls";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            string txtFile = openFileDialog.FileName;
            if (string.IsNullOrWhiteSpace(txtFile)) return;
            if (!JudgeFileState(txtFile)) return;
            var module = (EditTableCenter)AutofacProvider.Get<IModuleDialog>(nameof(EditTableCenter));
            await module.ShowDialog(new ExcelFileInfoModel { Path = txtFile });

        }

        #region 逻辑处理

        private void GetExcelFiles(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                //判断所指的文件夹/文件是否存在  
                if (!dir.Exists) return;
                FileSystemInfo[] files = dir.GetFileSystemInfos();//获取文件夹下所有文件和文件夹  
                //对单个FileSystemInfo进行判断，如果是文件夹则进行递归操作  
                foreach (FileSystemInfo fileSystemInfo in files)
                {
                    if (fileSystemInfo is FileInfo fileInfo)
                    {
                        //如果是文件，进行文件操作  
                        FileInfo info = new FileInfo(fileInfo.DirectoryName + "\\" + fileInfo.Name);//获取文件所在原始路径 

                        if (info.Extension.Equals(".xls") || info.Extension.Equals(".xlsx"))
                        {
                            _dataSource.Add(new ExcelFileInfoModel
                            {
                                Name = fileInfo.Name,
                                Date = $"{fileInfo.CreationTime:yyyy年MM月dd日 HH:mm:ss}",
                                Path = fileInfo.DirectoryName + "\\" + fileInfo.Name,
                                Size = $"{CountSize(fileInfo.Length)}"
                            });
                            _dataSource = _dataSource.OrderByDescending(e => e.Date).ToList();
                        }
                    }
                    else
                    {
                        //如果是文件夹，则进行递归调用 
                        string pp = fileSystemInfo.Name;
                        GetExcelFiles(path + "\\" + fileSystemInfo);
                    }
                }

            }
            catch (Exception ex) { }

        }
        /// <summary>
        /// 计算文件大小函数(保留两位小数),Size为字节大小
        /// </summary>
        /// <param name="Size">初始文件大小</param>
        /// <returns></returns>
        public static string CountSize(long Size)
        {
            string m_strSize = "";
            long FactSize = 0;
            FactSize = Size;
            if (FactSize < 1024.00)
                m_strSize = FactSize.ToString("F2") + " Byte";
            else if (FactSize >= 1024.00 && FactSize < 1048576)
                m_strSize = (FactSize / 1024.00).ToString("F2") + " K";
            else if (FactSize >= 1048576 && FactSize < 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00).ToString("F2") + " M";
            else if (FactSize >= 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00 / 1024.00).ToString("F2") + " G";
            return m_strSize;
        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        private bool JudgeFileState(string path)
        {
            if (!File.Exists(path))
            {
                Messenger.Default.Send("当前文件已被移除！", MessageToken.MAIN_TABLE_SNACK);
                return false;
            }
            IntPtr vHandle = _lopen(path, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (vHandle == HFILE_ERROR)
            {
                Messenger.Default.Send("当前文件已被占用！", MessageToken.MAIN_TABLE_SNACK);
                return false;
            }
            CloseHandle(vHandle);
            return true;
        }
        #endregion
        public async Task GetFileListData()
        {

        }
    }
}
