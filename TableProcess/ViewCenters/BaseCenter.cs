/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：BaseCenter
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:38:24
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using TableProcess.Services.Interfaces;

namespace TableProcess.ViewCenters
{
    public abstract class BaseCenter<TView, TViewModel> : IModule
        where TView : UserControl, new()
        where TViewModel : ViewModelBase, new()
    {
        public TView View = new TView();
        public TViewModel ViewModel = new TViewModel();
        public abstract Task BindDefaultModel();

        public void BindViewModel<BViewModel>(BViewModel viewModel) where BViewModel : class, new()
        {
            this.View.DataContext = viewModel;
        }
        public UserControl GetView()
        {
            return View;
        }

        object IModule.GetView()
        {
            return View;
        }

    }
}
