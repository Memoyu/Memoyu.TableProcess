/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：BaseViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:33:49
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
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace TableProcess.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        private bool _isOpen;
        private object _dialogContent;
        public BaseViewModel()
        {
            CloseCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send(true, "Exit");
            });
        }
        public RelayCommand CloseCommand { get; private set; }
        /// <summary>
        /// 窗口是否显示
        /// </summary>
        public bool DialogIsOpen
        {
            get => _isOpen;
            set { _isOpen = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 弹出窗口
        /// </summary>
        public object DialogContent
        {
            get => _dialogContent;
            set { _dialogContent = value; RaisePropertyChanged(); }
        }
    }
}
