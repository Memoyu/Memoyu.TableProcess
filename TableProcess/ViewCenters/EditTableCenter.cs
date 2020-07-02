/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：EditTableCenter
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 17:18:25
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Messaging;
using TableProcess.Common;
using TableProcess.Common.Attributes;
using TableProcess.Models;
using TableProcess.ViewModels;
using TableProcess.Views;

namespace TableProcess.ViewCenters
{
    /// <summary>
    /// 表格处理
    /// </summary>
    public class EditTableCenter : BaseDialogCenter<EditTableView, EditTableViewModel>
    {
        private ExcelFileInfoModel _fileInfo;
        public override void RegisterMessenger()
        {
            Messenger.Default.Register<bool>(View, MessageToken.EDIT_TABLE_LOAD, arg =>
            {
                ViewModel.DialogIsOpen = arg;
            });
            Messenger.Default.Register<string>(View, MessageToken.EDIT_TABLE_SNACK, arg =>
            {
                ViewModel.SnackMessageQueue.Enqueue(
                    $"{arg}",
                    null,
                    null,
                    null,
                    false,
                    true,
                    TimeSpan.FromSeconds(5));

            });
            Messenger.Default.Register<bool>(View, MessageToken.EDIT_TABLE_EXIT, arg =>
            {
                View.Close();
            });

        }
        public async Task ShowDialog(ExcelFileInfoModel fileInfo)
        {
            _fileInfo = fileInfo;
            await base.ShowDialog();
        }
        public override async void BindDefaultViewModel()
        {
            ViewModel = new EditTableViewModel();
            View.DataContext = ViewModel;
            await ViewModel.LoadExcelData(_fileInfo);
        }

    }
}
