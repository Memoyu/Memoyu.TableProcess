/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ModuleAttribute
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:58:44
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

namespace TableProcess.Common.Attributes
{
    /// <summary>
    /// 模块特性, 标记该特性表示属于应用模块的部分
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ModuleAttribute : Attribute
    {
        public ModuleAttribute(int sort, string desc, string typeName, string nameSpace, string icon)
        {
            this.Sort = sort;
            this.Desc = desc;
            this.Icon = icon;
            this.TypeName = typeName;
            this.NameSpace = nameSpace;
        }
        /// <summary>
        /// 描述
        /// </summary>
        public int Sort { get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; }

        /// <summary>
        /// 类型
        /// </summary>
        public string TypeName { get; }
    }
}
