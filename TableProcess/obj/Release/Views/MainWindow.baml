   M S B A M L   `   `   `  ���� G  CTableProcess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TableProcessTableProcess  A%clr-namespace:TableProcess.ConvertersTableProcess.Converters  7 clr-namespace:TableProcess.ViewsTableProcess.Views  #    TableProcess.Views.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  &localclr-namespace:TableProcess  6
converters%clr-namespace:TableProcess.Converters  ,views clr-namespace:TableProcess.Views    � WindowStartupLocation$  CenterScreen=� � Title$ 商品拣货单汇总��$	��900��$
��1200��$
��1200��$	��800�� � 	Resources 0   *TableProcess.Converters.MenuWidthConverter   mwc��%   &	          .��)  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ MainView��   IsOpen �� *DialogIsOpen+   DialogContent �� $	��300��$	��150��
�������._��� $��Center=�$��Center=�.+��  % !MaterialDesignCircularProgressBar#���   � Value$ 0Q�$��50�� � IsIndeterminate . �� $��0 50 0 0q�$��正在加载,请稍候...��$��20(����#737373.��� .+�� .+��  � ColumnDefinitions �� -   	 ��Name$	 gridMenu������ 
 �� ElementName$
 toggle�� �� Path$ 	IsChecked� �� 	Converter# [  �� .+��� 
���   �$��2�� J� Opacity$	 0.5Q��� 
���   �$	 0.1Q��� .+�d� -    d�Name$ toggle�� ' #MaterialDesignHamburgerToggleButton#���  $��RightToLeft=�$
��Left=�$��	18 18 0 0q�$��30��$��30��
���������  �� SelectionMode$ Extended=����� *ModuleManager.Modules+���� .R��� 
������ $��40��$	��250�� � ToolTip �� *Name+ J� InputBindings d�  d� MouseAction$ 	LeftClicke� �� Command ��  �� RelativeSource ��  �� AncestorType#   TableProcess.Views.MainWindow"  $! DataContext.OpenPageCommand� �� CommandParameter �� *
TypeName+._���  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  $��25��$��25��$��10 0 0 0q�
�������$��Center=�   Kind �� *Code+�� $��20 0 0 0q�$��16(�
�������$��Center=����� *Name+�� -    ��Name$
 page��$��1��$��2 0 0 0q�'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ Snackbar��   MessageQueue �� *SnackMessageQueue+