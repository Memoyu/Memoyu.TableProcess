/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ExcelFileInfoModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 14:14:38
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
    public class ExcelFileInfoModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Size { get; set; }
        public string Path { get; set; }
    }
}
