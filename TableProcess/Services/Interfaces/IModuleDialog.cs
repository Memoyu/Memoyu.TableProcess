/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：IModuleDialog
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:19:46
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using System.Threading.Tasks;

namespace TableProcess.Services.Interfaces
{
    /// <summary>
    /// 弹出式窗口接口
    /// </summary>
    public interface IModuleDialog
    {
        /// <summary>
        /// 关联默认上下文
        /// </summary>
        void BindDefaultViewModel();

        /// <summary>
        /// 关联数据上下文
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        void BindViewModel<TViewModel>(TViewModel viewModel);

        /// <summary>
        /// 注册模块事件
        /// </summary>
        void RegisterDefaultEvent();

        /// <summary>
        /// 注册模块消息
        /// </summary>
        void RegisterMessenger();

        /// <summary>
        /// 注册窗口默认事件
        /// </summary>
        void Register();

        /// <summary>
        /// 弹出窗口
        /// </summary>
        Task<bool> ShowDialog();

        /// <summary>
        /// 关闭窗口
        /// </summary>
        void Close();

    }
}
