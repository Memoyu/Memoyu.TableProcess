   M S B A M L   `   `   `  ���� G  CTableProcess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TableProcess.ViewsTableProcess.Views  "    TableProcess.Views.TableView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  ,views clr-namespace:TableProcess.Views  .��� .+��   � RowDefinitions  �� $
��Auto ��� $��30 ��� $��30 ��� .+��� $��拣货单汇总��$��22(�
������� �� Padding$ 20q�]� $��1����.  $��0 0 20 0q� K� ZIndex$ 1��.+���  �� Orientation$ 
Horizontal=�$ 1��.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ FolderOutline=�$��	10 0 10 0q� J� Opacity$	 .56Q�$��25��$��25��$��Center=�
��������� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$$ 请选择货单所在文件夹�� �� 
IsReadOnly . .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�$��0q�
�������$	��350��$��Center=�$��15(����� *
FolderPath+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�.���� $ 
Horizontal=�$ 1��$��Right=�.+���    MaterialDesignToolButton#��[   � ToolTip$! 选择货单所在文件夹��$��5 0 15 0q�.���� $ 
Horizontal=�.+�  $ Folder=�
�������$��25��$��25��$��Center=��� $��5 0 0 0q�$��选择目录��$��16(�
�������$��Center=� J� InputBindings d�  d� MouseAction$ 	LeftClicke� �� Command ��  �� RelativeSource ��  �� AncestorType"   TableProcess.Views.TableView"   �� Path$% DataContext.SelectFolderCommand��� #��[  $ 打开货单Excel文件��$��5 0 15 0q�.���� $ 
Horizontal=�.+�  $ FileExcelBoxOutline=�
�������$��25��$��25��$��Center=��� $��5 0 0 0q�$��打开文件��$��16(�
�������$��Center=� d� $ 	LeftClicke� ��  �� "  $# DataContext.SelectFileCommand��� #��[  $ 刷新��$��5 0 15 0q�.���� $ 
Horizontal=�.+�  $ Refresh=�
�������$��25��$��25��$��Center=��� $��5 0 0 0q�$��刷新��$��16(�
�������$��Center=� d� $ 	LeftClicke� ��  �� "  $  DataContext.RefreshCommand��� $��2��$ 
Horizontal=�$ 1��.+�  $ Magnify=�$��	10 0 10 0q�$	 .56Q�$��25��$��25��$��Center=�
��������� $ 检索Excel文件名��$ Hidden=�$��0q�
�������$	��200��$��Center=�$��15(����� *	QueryText+$	 TwoWay=�$
 PropertyChanged=�.�� �� 
 �� Key$ Return�� �� *QueryCommand+.��&   System.Windows.Controls.DataGrid  $��3��   
IsReadOnly . $
��10,0q�   CanUserAddRows .     AutoGenerateColumns .  ���� *ExcelFileInfos+ �� SelectedItem �� *CurrentExcel+ d� $ LeftDoubleClicke� ��  �� "  $&  DataContext.EditExcelDataCommand�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	文件名��   MinWidth$	 100Q� ) %MaterialDesignDataGridTextColumnStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  0 ,MaterialDesignDataGridTextColumnEditingStyle   EditingElementStyle# [    Binding �� *Name+  $ 创建日期��$	 100Q�# [ # [  �� *Date+  $ 大小��$	 100Q�# [ # [  �� *Size+