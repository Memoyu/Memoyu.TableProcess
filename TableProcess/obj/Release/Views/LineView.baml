   M S B A M L   `   `   `  ���� G  CTableProcess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TableProcess.ViewsTableProcess.Views  !    TableProcess.Views.LineView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:TableProcess.Views     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� .+��   � RowDefinitions  �� $
��Auto ��� $��30 ��� .+��� $��路线管理��$��22(�
������� �� Padding$ 20q�]� $��1����.  $��0 0 20 0q� K� ZIndex$ 1��.+���  �� Orientation$ 
Horizontal=�$ 1��$��Right=�.+���    MaterialDesignToolButton#��[   � ToolTip$ 添加��$��5 0 15 0q�.���� $ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�
�������$��25��$��25��$��Center=��� $��5 0 0 0q�$��添加��$��16(�
�������$��Center=� J� InputBindings d�  d� MouseAction$ 	LeftClicke� �� Command �� 	 �� RelativeSource	 �� 
 �� AncestorType!   TableProcess.Views.LineView"
   �� Path$  DataContext.RefreshCommand��� #��[  $ 刷新��$��5 0 15 0q�.���� $ 
Horizontal=�.+�  $ Refresh=�
�������$��25��$��25��$��Center=��� $��5 0 0 0q�$��刷新��$��16(�
�������$��Center=� d� $ 	LeftClicke� �� 	 �� "
  $  DataContext.RefreshCommand�&   System.Windows.Controls.DataGrid  $��2��$
��10,0q�   
IsReadOnly .     CanUserAddRows .     AutoGenerateColumns .  ���� *Lines+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	路线名��   MinWidth$	 100Q� ) %MaterialDesignDataGridTextColumnStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  0 ,MaterialDesignDataGridTextColumnEditingStyle   EditingElementStyle# [    Binding �� *Name+4  .System.Windows.Controls.DataGridTemplateColumn  $ 操作��   
IsReadOnly .    CellEditingTemplate �� .R��� #��[  $��50��$ 删除��.���� $ 
Horizontal=�.+�  $ DeleteEmptyOutline=�
���   �$��25��$��25��$��Center=��� $��5 0 0 0q�$��删除��$��13(�
���   �$��Center=� d� $ 	LeftClicke� �� 	 �� "
  $  DataContext.RefreshCommand�'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ Snackbar��   MessageQueue �� *SnackMessageQueue+