/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：BaseDialogCenter
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:21:24
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using TableProcess.Services.Interfaces;

namespace TableProcess.ViewCenters
{
    public class BaseDialogCenter<TView, TViewModel>: IModuleDialog 
        where TView : Window, new()
        where TViewModel : ViewModelBase, new()
    {
        public TView View = new TView();
        public TViewModel ViewModel = new TViewModel();

        /// <summary>
        /// 绑定默认ViewModel
        /// </summary>
        public virtual void BindDefaultViewModel()
        {
            ViewModel = new TViewModel();
            View.DataContext = ViewModel;
        }

        /// <summary>
        /// 注册默认事件
        /// </summary>
        public void RegisterDefaultEvent()
        {
            View.MouseDown += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    View.DragMove();
            };
        }

        /// <summary>
        /// 打开窗口
        /// </summary>
        /// <returns></returns>
        public virtual Task<bool> ShowDialog()
        {
            if (View.DataContext == null)
            {
                this.RegisterMessenger();
                this.RegisterDefaultEvent();
                this.BindDefaultViewModel();
            }
            var result = View.ShowDialog();
            return Task.FromResult(true);
        }

        public void BindViewModel<BViewModel>(BViewModel viewModel)
        {
        }

        public virtual void Close()
        {
        }

        public void Register()
        {
        }

        public virtual void RegisterMessenger()
        {
        }
    }
}
