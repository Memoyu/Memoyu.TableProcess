using System;
using System.Reflection;
using System.Security.Principal;
using System.Windows;
using Autofac;
using TableProcess.Services;
using TableProcess.Services.Interfaces;
using TableProcess.ViewCenters;
using TableProcess.Views;

namespace TableProcess
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.ConfigureServices();
            var view = AutofacProvider.Get<IModuleDialog>(nameof(MainCenter));
            view.ShowDialog();
        }
        protected void ConfigureServices()
        {
            AutofacLocator locator = new AutofacLocator();
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType(typeof(MainCenter)).Named(nameof(MainCenter), typeof(IModuleDialog));
            builder.RegisterType(typeof(EditTableCenter)).Named(nameof(EditTableCenter), typeof(IModuleDialog));
            builder.RegisterType(typeof(TableCenter)).Named(nameof(TableCenter), typeof(IModule));
            builder.RegisterType(typeof(LineCenter)).Named(nameof(LineCenter), typeof(IModule));
            locator.Register(builder);
            AutofacProvider.RegisterServiceLocator(locator);
        }
    }
}
