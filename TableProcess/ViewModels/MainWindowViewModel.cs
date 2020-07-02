/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：TableProcess.ViewModels
*   文件名称 ：MainWindowViewModel
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-06-16 21:56:56
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using TableProcess.Common;

namespace TableProcess.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ModuleManager _moduleManager;
        private Module _currentModule;
        private SnackbarMessageQueue _snackMessageQueue = new SnackbarMessageQueue();


        /// <summary>
        /// 模块管理器
        /// </summary>
        public ModuleManager ModuleManager
        {
            get => _moduleManager;
            set { _moduleManager = value; RaisePropertyChanged(); }
        }
        public Module CurrentModule
        {
            get => _currentModule;
            set { _currentModule = value; RaisePropertyChanged(); }
        }
        public SnackbarMessageQueue SnackMessageQueue
        {
            get => _snackMessageQueue;
            set { _snackMessageQueue = value; RaisePropertyChanged(); }
        }
        public RelayCommand<string> OpenPageCommand { get; set; }

        public MainWindowViewModel()
        {
            OpenPageCommand = new RelayCommand<string>(arg => { Messenger.Default.Send(arg, MessageToken.MAIN_TABLE_NEW_PAGE); });
        }
        public async Task InitDefaultView()
        {
            //加载模块
            ModuleManager = new ModuleManager();
            await ModuleManager.LoadAssemblyModule();
            Messenger.Default.Send($"{ModuleManager.Modules[0].TypeName}", MessageToken.MAIN_TABLE_NEW_PAGE);//默认选中第一个

        }
    }
}
