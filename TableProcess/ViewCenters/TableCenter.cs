/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：TableCenter
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:36:53
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
using TableProcess.Common.Attributes;
using TableProcess.ViewModels;
using TableProcess.Views;

namespace TableProcess.ViewCenters
{
    /// <summary>
    /// 表格文件处理
    /// </summary>
    [Module(1,"拣货单汇总", "TableCenter", "", "FileExcel")]
    public class TableCenter: BaseCenter<TableView, TableViewModel>
    {
        public override async Task BindDefaultModel()
        {
            await ViewModel.GetFileListData();
            View.DataContext = ViewModel;
        }
    }
}
