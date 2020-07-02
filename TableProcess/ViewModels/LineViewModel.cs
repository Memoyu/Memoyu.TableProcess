/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：LineViewModel
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/18 17:58:53
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
using TableProcess.Models;

namespace TableProcess.ViewModels
{
    public class LineViewModel : BaseViewModel
    {
        private ObservableCollection<LineModel> _lines;

        public ObservableCollection<LineModel> Lines
        {
            get => _lines;
            set { _lines = value; RaisePropertyChanged(); }
        }

        public LineViewModel()
        {
            Lines = new ObservableCollection<LineModel>
            {
               new LineModel{ Name = "线路1"},
               new LineModel{ Name = "线路2"},
               new LineModel{ Name = "线路3"},
               new LineModel{ Name = "线路4"},
               new LineModel{ Name = "线路5"},
               new LineModel{ Name = "线路6"},
               new LineModel{ Name = "线路7"},
               new LineModel{ Name = "线路8"},
               new LineModel{ Name = "线路9"},
            };
        }

        public async Task GetFileListData()
        {

        }
    }
}
