/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：TableProcess.Models
*   文件名称 ：MenuModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-06-16 22:25:39
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace TableProcess.Models
{
    public class MenuModel : ViewModelBase
    {
        public string IconFont { get; set; }

        public string Title { get; set; }

        public string BackColor { get; set; }

        public bool Display { get; set; } = true;

        private ObservableCollection<TaskInfo> taskInfos = new ObservableCollection<TaskInfo>();

        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return taskInfos; }
            set { taskInfos = value; RaisePropertyChanged(); }
        }
    }
    public class TaskInfo
    {
        public string Content { get; set; }

    }
}
