/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：LineCenter
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/18 17:59:23
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
    ///// <summary>
    ///// 线路管理
    ///// </summary>
    //[Module(2,"线路管理", "LineCenter", "", "ChartTimelineVariant")]
    public class LineCenter : BaseCenter<LineView, LineViewModel>
    {
        public override async Task BindDefaultModel()
        {
            await ViewModel.GetFileListData();
            View.DataContext = ViewModel;
        }
    }
}
