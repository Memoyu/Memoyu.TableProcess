/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：Module
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 10:03:41
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
using GalaSoft.MvvmLight;

namespace TableProcess.ViewModels
{
    public class Module : ViewModelBase
    {
        private int sort;
        private string code;
        private string name;
        private string typeName;

        /// <summary>
        /// 模块图标代码
        /// </summary>
        public int Sort
        {
            get => sort;
            set { sort = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 模块图标代码
        /// </summary>
        public string Code
        {
            get => code;
            set { code = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name
        {
            get => name;
            set { name = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 模块命名空间
        /// </summary>
        public string TypeName
        {
            get => typeName;
            set { typeName = value; RaisePropertyChanged(); }
        }
    }
}
