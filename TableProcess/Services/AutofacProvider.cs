/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：AutofacProvider
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:17:16
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using TableProcess.Services.Interfaces;

namespace TableProcess.Services
{
    public class AutofacProvider
    {
        public static IAutoFacLocator Instance { get; private set; }

        public static void RegisterServiceLocator(IAutoFacLocator locator)
        {
            if (Instance == null)
            {
                Instance = locator;
            }
        }

        public static T Get<T>()
        {
            if (Instance == null) return default(T);
            return Instance.Get<T>();
        }

        public static T Get<T>(string typeName)
        {
            if (Instance == null) return default(T);
            return Instance.Get<T>(typeName);
        }
    }
}
