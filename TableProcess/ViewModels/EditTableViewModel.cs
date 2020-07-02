/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：EditTableViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 17:18:59
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
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using TableProcess.Common;
using TableProcess.Common.Tools;
using TableProcess.Models;

namespace TableProcess.ViewModels
{
    public class EditTableViewModel : BaseViewModel
    {
        private List<string> _tempLines = new List<string>();
        private ObservableCollection<GoodsSheetModel> _goodsSheet;
        private ObservableCollection<string> _lines;
        private SnackbarMessageQueue _snackMessageQueue = new SnackbarMessageQueue();
        public RelayCommand ExportSummaryExcelCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public ObservableCollection<GoodsSheetModel> GoodsSheet
        {
            get => _goodsSheet;
            set { _goodsSheet = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<string> Lines
        {
            get => _lines;
            set { _lines = value; RaisePropertyChanged(); }
        }
        public SnackbarMessageQueue SnackMessageQueue
        {
            get => _snackMessageQueue;
            set { _snackMessageQueue = value; RaisePropertyChanged(); }
        }
        public EditTableViewModel()
        {

            //Lines = new ObservableCollection<string>
            //{
            //    "线路1","线路2","线路3","线路4","线路5","线路6","线路7",
            //};

            ExportSummaryExcelCommand = new RelayCommand(ExportSummaryExcel);
            CloseCommand = new RelayCommand(() => { Messenger.Default.Send(true, MessageToken.EDIT_TABLE_EXIT); });
        }
        private void ExportSummaryExcel()
        {
            string path = ExcelHelper.GetSaveFilePath();
            if (string.IsNullOrWhiteSpace(path)) return;
            try
            {
                Messenger.Default.Send(true, MessageToken.EDIT_TABLE_LOAD);
                List<List<GoodsSummarySheetModel>> goodsSummarySheets = new List<List<GoodsSummarySheetModel>>();
                List<List<GoodsSummarySheetModel>> summaryTemp = new List<List<GoodsSummarySheetModel>>();

                var result = from g in GoodsSheet
                             group g by g.Line;
                foreach (var group in result) //得到各个线路的分组
                {
                    List<GoodsSummarySheetModel> temp = new List<GoodsSummarySheetModel>();
                    foreach (GoodsSheetModel goods in group)
                    {
                        temp.Add(new GoodsSummarySheetModel
                        { Line = goods.Line, GoodsName = goods.GoodsName, Count = goods.Count });
                    }
                    summaryTemp.Add(temp);
                }

                foreach (List<GoodsSummarySheetModel> s in summaryTemp)
                {
                    goodsSummarySheets.Add(GetSumData(s).ToList());
                }

                if (ExcelHelper.ExportExcel(goodsSummarySheets, path))
                {
                    Messenger.Default.Send("导出完成！", MessageToken.EDIT_TABLE_SNACK);
                }
            }
            catch (Exception ex)
            {
                Messenger.Default.Send("导出汇总商品数据异常！", MessageToken.EDIT_TABLE_SNACK);
            }
            finally
            {
                Messenger.Default.Send(false, MessageToken.EDIT_TABLE_LOAD);
            }
        }

        #region 逻辑处理

        private IEnumerable<GoodsSummarySheetModel> GetSumData(List<GoodsSummarySheetModel> dataSource)
        {
            return from q in dataSource.AsEnumerable()
                   group q by q.GoodsName into g//分那列数据
                   select new GoodsSummarySheetModel
                   {
                       Line = g.FirstOrDefault()?.Line,
                       GoodsName = g.Key,
                       Count = g.Sum(c => c.Count),
                   };
        }

        public async Task LoadExcelData(ExcelFileInfoModel fileInfo)
        {
            await Task.Run(() =>
            {
                try
                {
                    Messenger.Default.Send(true, MessageToken.EDIT_TABLE_LOAD);
                    ExcelHelper excel = new ExcelHelper(fileInfo.Path);
                    var data = excel.ExcelToDataTable("样表", true);
                    if (data == null) return;
                    if (!data.Columns.Contains("商品编码")
                        && !data.Columns.Contains("商品名称")
                        && !data.Columns.Contains("团长")) throw new Exception("表单格式存在错误，无法读取数据！");
                    ObservableCollection<GoodsSheetModel> goodsSheet = new ObservableCollection<GoodsSheetModel>();
                    foreach (DataRow dataRow in data.Rows)
                    {
                        int.TryParse(dataRow["序号"].ToString(), out int id);
                        double.TryParse(dataRow["单价"]?.ToString(), out double price);
                        int.TryParse(dataRow["订购数"]?.ToString(), out int count);
                        double.TryParse(dataRow["总价"]?.ToString(), out double amount);
                        var line = dataRow["线路"]?.ToString();
                        goodsSheet.Add(new GoodsSheetModel
                        {
                            Id = id,
                            GoodsCode = dataRow["商品编码"]?.ToString(),
                            GoodsName = dataRow["商品名称"]?.ToString(),
                            GoodsSpec = dataRow["规格"]?.ToString(),
                            Price = price,
                            Count = count,
                            Amount = amount,
                            Head = dataRow["团长"]?.ToString(),
                            Address = dataRow["小区"]?.ToString(),
                            Line = line,

                        });
                        _tempLines.Add(line);
                    }

                    GoodsSheet = goodsSheet;
                    _tempLines = _tempLines.Distinct().ToList();
                    Lines = new ObservableCollection<string>();
                    _tempLines.ForEach(l =>
                    {
                        if (!string.IsNullOrWhiteSpace(l))
                        {
                            Lines.Add(l);
                        }
                    });
                }
                catch (Exception ex)
                {
                    Messenger.Default.Send(ex.Message, MessageToken.EDIT_TABLE_SNACK);
                }
                finally
                {
                    Messenger.Default.Send(false, MessageToken.EDIT_TABLE_LOAD);
                }
            });
        }
        #endregion
    }
}
