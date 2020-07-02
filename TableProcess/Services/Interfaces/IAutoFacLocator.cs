﻿/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：IAutoFacLocator
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:15:40
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using Autofac;

namespace TableProcess.Services.Interfaces
{
    public interface IAutoFacLocator
    {
        void Register(ContainerBuilder builder);

        TInterface Get<TInterface>();

        TInterface Get<TInterface>(string typeName);
    }
}
