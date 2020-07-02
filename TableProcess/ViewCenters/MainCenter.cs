/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：MainCenter
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:31:42
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using System;
using GalaSoft.MvvmLight.Messaging;
using TableProcess.Common;
using TableProcess.Services;
using TableProcess.Services.Interfaces;
using TableProcess.ViewModels;
using TableProcess.Views;

namespace TableProcess.ViewCenters
{
    public class MainCenter : BaseDialogCenter<MainWindow, MainWindowViewModel>
    {
        public override void RegisterMessenger()
        {
            Messenger.Default.Register<bool>(View, MessageToken.MAIN_TABLE_LOAD, arg =>
            {
                ViewModel.DialogIsOpen = arg;
            });
            Messenger.Default.Register<string>(View, MessageToken.MAIN_TABLE_SNACK, arg =>
            {
                ViewModel.SnackMessageQueue.Enqueue(
                    $"{arg}",
                    null,
                    null,
                    null,
                    false,
                    true,
                    TimeSpan.FromSeconds(5));
            });
            Messenger.Default.Register<string>(View, MessageToken.MAIN_TABLE_NEW_PAGE, async arg =>
            {
                var module = AutofacProvider.Get<IModule>(arg);
                if (module != null)
                {
                    ViewModel.DialogIsOpen = true;
                    //await Task.Delay(30);
                    await module.BindDefaultModel();
                    View.page.Content = module.GetView();
                    ViewModel.DialogIsOpen = false; //关闭等待窗口
                }
                else
                {

                }
            });
        }
        public override async void BindDefaultViewModel()
        {
            ViewModel = new MainWindowViewModel();
            await ViewModel.InitDefaultView();
            //View.page.Content = new HomeView();
            View.DataContext = ViewModel;
        }
    }
}
