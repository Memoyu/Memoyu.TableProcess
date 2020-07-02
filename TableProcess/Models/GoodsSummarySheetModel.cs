/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：GoodsSummarySheetModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 18:14:22
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

namespace TableProcess.Models
{
    public class GoodsSummarySheetModel
    {
        public string Line { get; set; }
        public string GoodsName { get; set; }
        public int  Count { get; set; }
    }
}
