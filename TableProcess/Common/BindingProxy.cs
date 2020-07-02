/**************************************************************************  
*   =================================
*   CLR�汾  ��4.0.30319.42000
*   �ļ����� ��BindingProxy
*   =================================
*   �� �� �� ��Memoyu
*   �������� ��2020/6/17 14:14:38
*   �������� ��
*   =================================
*   �� �� �� ��
*   �޸����� ��
*   �޸����� ��
*   ================================= 
***************************************************************************/
using System.Windows;

namespace TableProcess.Common
{
    public class BindingProxy : Freezable
    {
        protected override Freezable CreateInstanceCore() => new BindingProxy();

        public object Data
        {
            get => GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }
}