   M S B A M L   `   `   `  ���� K  GDotNetProjectOne, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DotNetProjectOneDotNetProjectOne  *    $DotNetProjectOne.SearchResultsWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     0localclr-namespace:DotNetProjectOne     -   $��SearchPopUp��  � Title$  SearchResultsWindow��$	��450��$	��550��{�.  � WindowStyle$
 None=� � AllowsTransparency . 
������ .���� 
���   �$��3q�._�� ���#333 � RowDefinitions �� $��1* ��� $��5* �.+��� $��0��$��Center=�
�������$��40(�$��Light"�.��Search result�� -   $��0q�
������ $��30��$��30��$	��Top=�$��Right=�.���� $��/Icons/close_button.png���� -    ��Name$ SelectionList��$��1��$��0q�
������ $��Stretch=�$��Stretch=���.  $��30q�����  �� Path$ searchmovies�����  �� DataType   DotNetProjectOne.Img"  .R��  �Name$ DataGrid�� � ColumnDefinitions �� $
��150* ��� $
��100* � �� $	��23* ��� $	��23* ��� $	��23* �.+��� 	 ��Name$	 obraz��$��3��$��0��$	��100��$	��100��
 J� Opacity$	
 0.5Q�$��Stretch=�$��Stretch=�$��1q����� *Str+ � ToolTip _� ���� *Name+�� $��1��$��0������ *Name+�� $��1��$��1������ *
Director+�� $��1��$��2������ *Year+