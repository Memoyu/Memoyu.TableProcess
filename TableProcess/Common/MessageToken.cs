/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：MessageToken
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/18 11:27:58
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using TableProcess.ViewCenters;

namespace TableProcess.Common
{
    public static class MessageToken
    {
        public static string EDIT_TABLE_EXIT = $"{nameof(EditTableCenter)}Exit";
        public static string EDIT_TABLE_LOAD = $"{nameof(EditTableCenter)}Load";
        public static string EDIT_TABLE_SNACK = $"{nameof(EditTableCenter)}Snack";

        public static string MAIN_TABLE_EXIT = $"{nameof(MainCenter)}Exit";
        public static string MAIN_TABLE_LOAD = $"{nameof(MainCenter)}Load";
        public static string MAIN_TABLE_SNACK = $"{nameof(MainCenter)}Snack";
        public static string MAIN_TABLE_NEW_PAGE = $"{nameof(MainCenter)}NewPage";


    }
}
