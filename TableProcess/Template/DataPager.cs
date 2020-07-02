/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：TableProcess.Template
*   文件名称 ：DataPager
*   =================================
*   创 建 者 ：Memoyu
*   电子邮箱 ：mmy6076@outlook.com
*   创建日期 ：2020-06-16 22:25:39
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;

namespace TableProcess.Template
{
    /// <summary>
    /// 数据分页
    /// </summary>
    public class DataPager : Control
    {
        /// <summary>
        /// 页大小
        /// </summary>
        public string PageSize
        {
            get { return (string)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        /// <summary>
        /// 总数量
        /// </summary>
        public string TotalCount
        {
            get { return (string)GetValue(TotalCountProperty); }
            set { SetValue(TotalCountProperty, value); }
        }

        /// <summary>
        /// 页索引
        /// </summary>
        public string PageIndex
        {
            get { return (string)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        /// <summary>
        /// 页总数
        /// </summary>
        public string PageCount
        {
            get { return (string)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        public static readonly DependencyProperty PageSizeProperty = DependencyProperty.Register("PageSize", typeof(string), typeof(DataPager), new PropertyMetadata(""));

        public static readonly DependencyProperty TotalCountProperty = DependencyProperty.Register("TotalCount", typeof(string), typeof(DataPager), new PropertyMetadata(""));

        public static readonly DependencyProperty PageIndexProperty = DependencyProperty.Register("PageIndex", typeof(string), typeof(DataPager), new PropertyMetadata(""));

        public static readonly DependencyProperty PageCountProperty = DependencyProperty.Register("PageCount", typeof(string), typeof(DataPager), new PropertyMetadata(""));

        public RelayCommand GoHomePageCommand
        {
            get { return (RelayCommand)GetValue(GoHomePageCommandProperty); }
            set { SetValue(GoHomePageCommandProperty, value); }
        }

        public RelayCommand GoOnPageCommand
        {
            get { return (RelayCommand)GetValue(GoOnPageCommandProperty); }
            set { SetValue(GoOnPageCommandProperty, value); }
        }

        public RelayCommand GoNextPageCommand
        {
            get { return (RelayCommand)GetValue(GoNextPageCommandProperty); }
            set { SetValue(GoNextPageCommandProperty, value); }
        }

        public RelayCommand GoEndPageCommand
        {
            get { return (RelayCommand)GetValue(GoEndPageCommandProperty); }
            set { SetValue(GoEndPageCommandProperty, value); }
        }

        public static readonly DependencyProperty GoHomePageCommandProperty = DependencyProperty.Register("GoHomePageCommand", typeof(RelayCommand), typeof(DataPager));

        public static readonly DependencyProperty GoNextPageCommandProperty = DependencyProperty.Register("GoNextPageCommand", typeof(RelayCommand), typeof(DataPager));

        public static readonly DependencyProperty GoOnPageCommandProperty = DependencyProperty.Register("GoOnPageCommand", typeof(RelayCommand), typeof(DataPager));

        public static readonly DependencyProperty GoEndPageCommandProperty = DependencyProperty.Register("GoEndPageCommand", typeof(RelayCommand), typeof(DataPager));

    }
}
