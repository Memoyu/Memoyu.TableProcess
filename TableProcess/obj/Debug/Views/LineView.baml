   M S B A M L   `   `   `  ����G  CTableProcess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TableProcess.ViewsTableProcess.Views  5      !    TableProcess.Views.LineView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:TableProcess.Views     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   �   � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $��30 �6    �� 5      .+�5      �� $��路线管理��6   $��22(�6$   
������� �� Padding$ 20q�6E   ]� 5      $��1��6   ��.  $��0 0 20 0q�6=    K� ZIndex$ 1��6P   .+�5      ��  �� Orientation$ 
Horizontal=�6   $ 1��66   $��Right=�6G   .+�5      ��    MaterialDesignToolButton#��[  6    � ToolTip$ 添加��6P   $��5 0 15 0q�6]   .��5      �� $ 
Horizontal=�6%   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�67   
�������$��25��6U   $��25��6`   $��Center=�6l   �� 5      $��5 0 0 0q�6(   $��添加��69   $��16(�6C   
�������$��Center=�6d   5       J� InputBindings 5      d� 5       d� MouseAction$ 	LeftClicke�6+    �� Command 6C   �� 	 �� RelativeSource	 �� 
 �� AncestorType!   TableProcess.Views.LineView"
   �� Path$  DataContext.RefreshCommand�5      �� 5      #��[  6   $ 刷新��6P   $��5 0 15 0q�6]   .��5      �� $ 
Horizontal=�6%   .+�5         $ Refresh=�67   
�������$��25��6Y   $��25��6d   $��Center=�6p   �� 5!      $��5 0 0 0q�6(   $��刷新��69   $��16(�6C   
�������$��Center=�6d   5"       5#      d� 5$      $ 	LeftClicke�6+    6C   �� 	 �� "
  $  DataContext.RefreshCommand�5'      5(      5)      &   System.Windows.Controls.DataGrid  5*      $��2��6   $
��10,0q�6C      
IsReadOnly .     CanUserAddRows .     AutoGenerateColumns .  ��6$   �� *Lines+   Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ 	路线名��5/   -      MinWidth$	 100Q�6;    ) %MaterialDesignDataGridTextColumnStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 50   -    0 ,MaterialDesignDataGridTextColumnEditingStyle   EditingElementStyle# [ 51   -      Binding 5.   )   �� *Name+51   -   4  .System.Windows.Controls.DataGridTemplateColumn  52      $ 操作��6-      
IsReadOnly .    CellEditingTemplate 53      �� 54      .R�55   "   �� #��[  6)   $��50��6[   $ 删除��6f   .��56   &   �� $ 
Horizontal=�61   .+�57   *     $ DeleteEmptyOutline=�6C   
���   �$��25��6p   $��25��6{   $��Center=�6�   �� 58   *   $��5 0 0 0q�64   $��删除��6E   $��13(�6O   
���   �$��Center=�6p   59   '    5:   &   d� 5;   *   $ 	LeftClicke�67    6O   �� 	 �� "
  $  DataContext.RefreshCommand�5>   #   5?      5A      5C      5D      '  !MaterialDesignThemes.Wpf.Snackbar  5E   
   -   5          Name$ Snackbar��5E   #      MessageQueue 65   �� *SnackMessageQueue+5F      5G      