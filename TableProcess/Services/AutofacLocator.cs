/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：AutofacLocator
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 9:13:56
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/

using System;
using Autofac;
using TableProcess.Services.Interfaces;

namespace TableProcess.Services
{
    public class AutofacLocator:IAutoFacLocator
    {
        Autofac.IContainer _container;

        public TInterface Get<TInterface>(string typeName)
        {
            if (_container == null) throw new Exception("IContainer is null");
            if (_container.IsRegisteredWithName<TInterface>(typeName))
                return _container.ResolveNamed<TInterface>(typeName);
            else
                return default;
        }
        public TInterface Get<TInterface>()
        {
            if (_container == null) throw new Exception("IContainer is null");
            return _container.Resolve<TInterface>();
        }

        public void Register(ContainerBuilder builder)
        {
            _container = builder.Build();
        }
    }
}
