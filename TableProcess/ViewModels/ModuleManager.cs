/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：ModuleManager
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 10:02:29
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TableProcess.Common;

namespace TableProcess.ViewModels
{
    public class ModuleManager : ViewModelBase
    {

        private ObservableCollection<Module> _modules;
        /// <summary>
        /// 已加载模块
        /// </summary>
        public ObservableCollection<Module> Modules
        {
            get => _modules;
            set { _modules = value; RaisePropertyChanged(); }
        }
        public ModuleManager()
        {

        }
        /// <summary>
        /// 加载程序集模块
        /// </summary>
        /// <returns></returns>
        public async Task LoadAssemblyModule()
        {
            try
            {
                Modules = new ObservableCollection<Module>();
                ModuleComponent mc = new ModuleComponent();
                var ms = await mc.GetAssemblyModules();
                foreach (var i in ms)
                {
                    Modules.Add(new Module { Name = i.Desc, Code = i.Icon, TypeName = i.TypeName, Sort = i.Sort });
                }
                var temp = Modules.OrderBy(m => m.Sort).ToList();
                Modules.Clear();
                temp.ForEach(t=>Modules.Add(t));
                GC.Collect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
