   M S B A M L   `   `   `  ����G  CTableProcess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TableProcess.ViewsTableProcess.Views  5      "    TableProcess.Views.TableView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ,views clr-namespace:TableProcess.Views  5      .��5
      � .+�5   
   �   � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $��30 �6    �� 5      $��30 �6    �� 5      .+�5      �� $��拣货单汇总��6   $��22(�6%   
������� �� Padding$ 20q�6F   ]� 5      $��1��6   ��.  $��0 0 20 0q�6=    K� ZIndex$ 1��6P   .+�5      ��  �� Orientation$ 
Horizontal=�6   $ 1��67   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ FolderOutline=�6/   $��	10 0 10 0q�6D    J� Opacity$	 .56Q�6W   $��25��5   +   $��25��66   $��Center=�6B   
�������6]   �� 5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$$ 请选择货单所在文件夹��5       �� 
IsReadOnly . .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�5      $��0q�6Y   
�������$	��350��5   /   $��Center=�6?   $��15(�6Z   ��5      �� *
FolderPath+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�.��5   h   5      5      �� 5      $ 
Horizontal=�6   $ 1��66   $��Right=�6G   .+�5      ��    MaterialDesignToolButton#��[  6    � ToolTip$! 选择货单所在文件夹��6Q   $��5 0 15 0q�6e   .��5       �� $ 
Horizontal=�6%   .+�5!        $ Folder=�67   
�������$��25��6X   $��25��6c   $��Center=�6o   �� 5"      $��5 0 0 0q�6(   $��选择目录��69   $��16(�6E   
�������$��Center=�6f   5#       J� InputBindings 5$      d� 5%       d� MouseAction$ 	LeftClicke�6+    �� Command 6C   ��  �� RelativeSource ��  �� AncestorType"   TableProcess.Views.TableView"   �� Path$% DataContext.SelectFolderCommand�5(      �� 5)      #��[  6   $ 打开货单Excel文件��6P   $��5 0 15 0q�6f   .��5*      �� $ 
Horizontal=�6%   .+�5+        $ FileExcelBoxOutline=�67   
�������$��25��6e   $��25��6p   $��Center=�6|   �� 5,      $��5 0 0 0q�6(   $��打开文件��69   $��16(�6E   
�������$��Center=�6f   5-       5.      d� 5/      $ 	LeftClicke�6+    6C   ��  �� "  $# DataContext.SelectFileCommand�52      �� 53      #��[  6   $ 刷新��6P   $��5 0 15 0q�6]   .��54      �� $ 
Horizontal=�6%   .+�55        $ Refresh=�67   
�������$��25��6Y   $��25��6d   $��Center=�6p   �� 56      $��5 0 0 0q�6(   $��刷新��69   $��16(�6C   
�������$��Center=�6d   57       58      d� 59      $ 	LeftClicke�6+    6C   ��  �� "  $  DataContext.RefreshCommand�5<      5=      5>      �� 5?      $��2��6   $ 
Horizontal=�6'   $ 1��6@   .+�5@        $ Magnify=�6+   $��	10 0 10 0q�6:   $	 .56Q�6M   $��25��5A   '   $��25��62   $��Center=�6>   
�������6Y   �� 5B      $ 检索Excel文件名��5C      $ Hidden=�5D      $��0q�6S   
�������$	��200��5E   )   $��Center=�68   $��15(�6S   ��5B      �� *	QueryText+$	 TwoWay=�$
 PropertyChanged=�.��5E   a    5F      �� 5G      
 �� Key$ Return��6%    62   �� *QueryCommand+.��5H   -   5I      5J      &   System.Windows.Controls.DataGrid  5M      $��3��6      
IsReadOnly . $
��10,0q�6]      CanUserAddRows .     AutoGenerateColumns .  ��6$   �� *ExcelFileInfos+ �� SelectedItem 6l   �� *CurrentExcel+ 5O      d� 5P      $ LeftDoubleClicke�6#    6A   ��  �� "  $&  DataContext.EditExcelDataCommand�   Columns 5S      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$ 	文件名��5V   -      MinWidth$	 100Q�6;    ) %MaterialDesignDataGridTextColumnStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 5W   -    0 ,MaterialDesignDataGridTextColumnEditingStyle   EditingElementStyle# [ 5X   -      Binding 5U   )   �� *Name+5X   -     5Y      $ 创建日期��5Z   %   $	 100Q�64   # [ 5[   %   # [ 5\   %    5Y   )   �� *Date+5\   %     5]      $ 大小��5^   %   $	 100Q�62   # [ 5_   %   # [ 5`   %    5]   )   �� *Size+5`   %   5b      5|      5}      5~      