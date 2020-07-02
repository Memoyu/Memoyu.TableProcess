/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：IModule
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:41:49
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

namespace TableProcess.Services.Interfaces
{
    interface IModule
    {
        /// <summary>
        /// 关联数据上下文
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        void BindViewModel<TViewModel>(TViewModel viewModel) where TViewModel : class, new();

        /// <summary>
        /// 关联默认数据上下文
        /// </summary>
        Task BindDefaultModel();

        object GetView();
    }
}
