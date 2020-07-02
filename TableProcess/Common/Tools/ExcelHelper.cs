/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：TableProcess.Common.Tools
*   文件名称 ：ExcelHelper
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-06-18 1:23:28
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Messaging;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using TableProcess.Models;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace TableProcess.Common.Tools
{
    public class ExcelHelper
    {
        private readonly string fileName = null; //文件名  
        private IWorkbook _workbook = null;
        private FileStream _fs = null;
        private bool _disposed;
        public ExcelHelper(string fileName)//构造函数，读入文件名  
        {
            this.fileName = fileName;
            _disposed = false;
        }
        /// 将excel中的数据导入到DataTable中  
        /// <param name="sheetName">excel工作薄sheet的名称</param>  
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>  
        /// <returns>返回的DataTable</returns>  
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                _fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                _workbook = WorkbookFactory.Create(_fs);
                if (sheetName != null)
                {
                    sheet = _workbook.GetSheet(sheetName);
                    //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet  
                    if (sheet == null)
                    {
                        sheet = _workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = _workbook.GetSheetAt(0);
                }

                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号，即总的列数  
                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }

                        startRow = sheet.FirstRowNum + 1; //得到项标题后  
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }
                    //最后一列的标号  
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　  

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            Console.WriteLine($"{row.Cells.Count}，{i},{j}");
                            var cell = row.GetCell(j);
                            if (cell != null && cell.IsMergedCell)
                            {
                                var val = GetMergedRegionStr(sheet, i, row.Cells[j].ColumnIndex);
                                if (val != null) //同理，没有数据的单元格都默认是null  
                                    dataRow[j] = val.ToString();
                            }
                            else
                            {
                                if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null  
                                    dataRow[j] = row.GetCell(j).ToString();
                            }

                        }

                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (IOException ioEx)
            {
                Messenger.Default.Send($"{ioEx.Message}", MessageToken.EDIT_TABLE_SNACK);
            }
            catch (Exception ex)//打印错误信息  
            {
                Messenger.Default.Send($"{ex.Message}", MessageToken.EDIT_TABLE_SNACK);
            }

            return null;
        }
        /// <summary>
        /// 获取合并单元格的值
        /// </summary>
        /// <param name="sheet">第一个sheet</param>
        /// <param name="row">初始行</param>
        /// <param name="column">初始列</param>
        /// <returns></returns>
        private static object GetMergedRegionStr(ISheet sheet, int row, int column)
        {
            //初始化坐标
            Point start = new Point(0, 0);
            Point end = new Point(0, 0);
            //获取合并单元格的数量
            int regionsCount = sheet.NumMergedRegions;
            //初始化单元格的值
            object cellValue = new object();
            //判断坐标
            for (int j = 0; j < regionsCount; j++)
            {
                //获得不同坐标
                CellRangeAddress range = sheet.GetMergedRegion(j);
                //判读参数坐标是否存在
                if (row >= range.FirstRow && row <= range.LastRow && column >= range.FirstColumn && column <= range.LastColumn)
                {
                    //获取坐标
                    start = new Point(range.FirstRow, range.FirstColumn);
                    end = new Point(range.LastRow, range.LastColumn);
                    //坐标x=row,y=colum
                    int x = (int)start.X;//获取所在坐标行号
                    int y = (int)start.Y;//获取所在坐标列号
                    //获取所在行
                    IRow fRow = sheet.GetRow(x);
                    //获取所在列
                    ICell fCell = fRow.GetCell(y);
                    //判断cell的类型
                    if (fCell.CellType == CellType.String)//string类型
                    {
                        cellValue = fCell.StringCellValue;
                    }
                    else if (fCell.CellType == CellType.Numeric)//数字类型
                    {
                        //判断是否是时间类型
                        if (HSSFDateUtil.IsCellDateFormatted(fCell))
                        {
                            cellValue = fCell.DateCellValue;
                        }
                        else
                        {
                            cellValue = fCell.NumericCellValue;
                        }

                    }
                    else if (fCell.CellType == CellType.Formula)//单元格有公式类型
                    {
                        cellValue = fCell.NumericCellValue;
                    }
                    else
                    {
                        cellValue = "";
                    }
                    break;
                }
            }
            return cellValue;
        }

        public static bool ExportExcel(List<List<GoodsSummarySheetModel>> goodsSummarySheets, string Path)
        {
            try
            {
                FileStream fs = null;
                XSSFWorkbook workbook = new XSSFWorkbook();
                foreach (var goodsSummary in goodsSummarySheets)
                {
                    var name = string.IsNullOrWhiteSpace(goodsSummary.FirstOrDefault()?.Line) ? "无" : goodsSummary.FirstOrDefault()?.Line;
                    XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet(name);

                    XSSFCellStyle dateStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    XSSFDataFormat format = (XSSFDataFormat)workbook.CreateDataFormat();
                    dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                    int rowIndex = 0;

                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 0)
                    {
                        #region 列头及样式
                        {
                            XSSFRow headerRow = (XSSFRow)sheet.CreateRow(0);
                            ICell cell = headerRow.CreateCell(0);
                            cell.SetCellValue($"{name}");
                            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 1));
                            XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                            XSSFFont font = (XSSFFont)workbook.CreateFont();
                            font.FontHeightInPoints = 12;
                            font.IsBold = true;
                            //font.Boldweight = 700;
                            headStyle.SetFont(font);
                            headStyle.Alignment = HorizontalAlignment.CenterSelection;
                            cell.CellStyle = headStyle;
                        }
                        #endregion
                        rowIndex = 1;
                    }
                    #endregion

                    foreach (GoodsSummarySheetModel row in goodsSummary)
                    {
                        XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
                        #region 填充内容

                        XSSFCell newCell = (XSSFCell)dataRow.CreateCell(0);
                        XSSFCell newCell1 = (XSSFCell)dataRow.CreateCell(1);
                        newCell.SetCellValue(row.GoodsName);
                        newCell1.SetCellValue(row.Count);

                        #endregion
                        rowIndex++;
                    }
                   AutoColumnWidth(sheet , 0); 
                }
                fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                workbook.Write(fs);
                fs.Dispose();
                return true;
            }
            catch (IOException ioEx)
            {
                Messenger.Default.Send($"{ioEx.Message}", MessageToken.EDIT_TABLE_SNACK);
            }
            catch (Exception ex)//打印错误信息  
            {
                Messenger.Default.Send($"导出汇总Excel表单异常！", MessageToken.EDIT_TABLE_SNACK);
            }
            return false;

        }

        /// <summary>
        /// 获取要保存的文件名称（含完整路径）
        /// </summary>
        /// <returns></returns>
        public static string GetSaveFilePath()
        {
            SaveFileDialog saveFileDig = new SaveFileDialog();
            saveFileDig.Filter = "Excel Office2007及以上(*.xlsx)|*.xlsx|Excel Office97-2003(*.xls)|.xls";
            saveFileDig.FilterIndex = 0;
            saveFileDig.OverwritePrompt = true;
            saveFileDig.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filePath = null;

            if (saveFileDig.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDig.FileName;
            }

            return filePath;
        }

        private static void AutoColumnWidth(ISheet sheet, int cols)
        {
            for (int col = 0; col <= cols; col++)
            {
                sheet.AutoSizeColumn(col);//自适应宽度，但是其实还是比实际文本要宽
                int columnWidth = sheet.GetColumnWidth(col) / 256;//获取当前列宽度
                for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow row = sheet.GetRow(rowIndex);
                    ICell cell = row.GetCell(col);
                    int contextLength = Encoding.UTF8.GetBytes(cell.ToString()).Length;//获取当前单元格的内容宽度
                    columnWidth = columnWidth < contextLength ? contextLength : columnWidth;

                }
                sheet.SetColumnWidth(col, columnWidth * 200);//

            }
        }
    }
}
