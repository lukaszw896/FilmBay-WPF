   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GDotNetProjectOne, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DotNetProjectOneDotNetProjectOne 5   
   *   $DotNetProjectOne.SearchResultsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   0localclr-namespace:DotNetProjectOne     5   
   -   5        $��SearchPopUp��5   %     � Title$  SearchResultsWindow��6	   $	��450��69   $	��550��6E   {�.  � WindowStyle$
 None=�6d    � AllowsTransparency . 
������ .��5      �� 
���   �$��3q�6!   ._�5   
   � ���#333 � RowDefinitions 5	      �� 5
      $��1* �6    �� 5      $��5* �6    .+�5      �� $��0��6   $��Center=�6"   
�������$��40(�6P   $��Light"�6^   .��6q   Search result6�   �� 5      -   5        $��0q�5   4   
������ $��30��6a   $��30��6m   $	��Top=�6x   $��Right=�6�   .��5      �� $��/Icons/close_button.png��6   6;   5      �� 5      -   5         ��Name$ 
canvasName��5      $��1��6)   ���#333$y�Hidden=�6H   6a   )   #MahApps.Metro.Controls.ProgressRing  5      -   5          Name$ progressRing��5   [   $��1��6$    K� ZIndex$ 3��61   $	��200��6B   $	��200��6O      IsActive .     AccentColorBrush#���   6�   �� 5      -   5         ��Name$ SelectionList��5   O   $��1��6   $��0q�6f   
������ $��Stretch=�6�   $��Stretch=�6�   ��.  $��30q�6�   ��6$   �� 	 �� Path$	 searchmovies���5      �� 5      
 �� DataType  DotNetProjectOne.Img"
  6#   .R�5      �  �Name$ DataGrid��6    � ColumnDefinitions 5      �� 5   "   $	��130 �63   �� 5   "   $
��100* �63    5      �� 5    "   $	��23* �60   �� 5!   "   $	��23* �60   �� 5"   "   $	��23* �60   .+�5%      ��  ��Name$ obraz��6%   $��3��64   $��0��6F   $	��150��6m   $��Stretch=�6~   $
��Left=�6�   $��1q�6�   ��6V   �� *Str+ � ToolTip 5&   "   _� 5'   &   ��6.   �� *Name+5)      �� 5*      $��1��6$   $��0��64   
�������$��20(�6m   $��Light"�6{   $
��Left=�6�   ��6A   �� *Name+6�   �� 5+      $��1��6$   $��1��64   
�������$��20(�6q   $��Light"�6   $
��Left=�6�   ��6A   �� *
Director+6�   �� 5,      $��1��6$   $��2��64   
�������$��20(�6m   $��Light"�6{   $
��Left=�6�   ��6A   �� *Year+6�   5.      5/      51      53      55      57      