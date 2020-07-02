/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ModuleComponent
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 10:05:10
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TableProcess.Common.Attributes;

namespace TableProcess.Common
{
    public class ModuleComponent
    {
        /// <summary>
        /// 获取程序集下的所有具备模块特性的集合
        /// </summary>
        /// <returns>模块特性集合</returns>
        public async Task<List<ModuleAttribute>> GetAssemblyModules()
        {
            try
            {
                List<ModuleAttribute> list = new List<ModuleAttribute>();

                await Task.Run(() =>
                {
                    Assembly asm = Assembly.GetEntryAssembly();
                    var types = asm.GetTypes();
                    foreach (var t in types)
                    {
                        var attr = (ModuleAttribute)t.GetCustomAttribute(typeof(ModuleAttribute), false);
                        if (attr != null)
                            list.Add(attr);
                    }
                });
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
