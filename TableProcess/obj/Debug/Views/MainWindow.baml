   M S B A M L   `   `   `  ����G  CTableProcess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TableProcessTableProcess  5   	   A%clr-namespace:TableProcess.ConvertersTableProcess.Converters  5   	   7 clr-namespace:TableProcess.ViewsTableProcess.Views  5	   	   #    TableProcess.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:TableProcess  5   	   6
converters%clr-namespace:TableProcess.Converters  5   	   ,views clr-namespace:TableProcess.Views  5	   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 商品拣货单汇总��6.   $	��900��5   	   $
��1200��6   $
��1200��6#   $	��800��63    � 	Resources 5      0   *TableProcess.Converters.MenuWidthConverter   mwc��%   &	          5   
   6(   5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ MainView��6       IsOpen 66   �� *DialogIsOpen+   DialogContent 5   
   �� 5      $	��300��6   $	��150��6!   
�������._�5      �� $��Center=�6   $��Center=�6:   .+�5      �  % !MaterialDesignCircularProgressBar#���  6"    � Value$ 0Q�6^   $��50��6h    � IsIndeterminate . 6s   �� 5      $��0 50 0 0q�6    $��正在加载,请稍候...��62   $��20(�6F   ���#7373736T   5      5      .��5   
   � .+�5      � .+�5      �  � ColumnDefinitions 5      �� 5      -   5        	 ��Name$	 gridMenu��5   +   ��6=   �� 
 �� ElementName$
 toggle�� �� Path$ 	IsChecked� �� 	Converter# [  �� 5       .+�5#      �� 
���   �$��2��60    J� Opacity$	 0.5Q�6D   �� 5$      
���   �$	 0.1Q�60   �� 5%      .+�5&      d� -   5         d�Name$ toggle��5&   '    ' #MaterialDesignHamburgerToggleButton#���  67   $��RightToLeft=�5'   %   $
��Left=�5(   #   $��	18 18 0 0q�6>   $��30��6Q   $��30��6\   
�������6i   �� 5*       �� SelectionMode$ Extended=�6Q   ��6#   �� *ModuleManager.Modules+��5+      �� 5,   "   .R�5-   &   �� 
������ $��40��6F   $	��250��6R    � ToolTip 6^   �� *Name+ J� InputBindings 5.   *   d� 5/   .    d� MouseAction$ 	LeftClicke�6;    �� Command 6S   ��  �� RelativeSource ��  �� AncestorType#   TableProcess.Views.MainWindow"  $! DataContext.OpenPageCommand� �� CommandParameter 51   7   �� *
TypeName+._�53   *   ��  �� Orientation$ 
Horizontal=�65   .+�54   .   '  !MaterialDesignThemes.Wpf.PackIcon  $��25��6]   $��25��6i   $��10 0 0 0q�6t   
�������$��Center=�55   R      Kind 54   F   �� *Code+55   R   �� 56   .   $��20 0 0 0q�68   $��16(�6a   
�������$��Center=�57   D   ��56   J   �� *Name+57   D   58   +   59   '   5:   #   5<      5=      �� 5?      -   5         ��Name$
 page��5?   %   $��1��63   $��2 0 0 0q�6C   5@      5A      '  !MaterialDesignThemes.Wpf.Snackbar  5B      -   5          Name$ Snackbar��5B   '      MessageQueue 69   �� *SnackMessageQueue+5C      5D      5E      