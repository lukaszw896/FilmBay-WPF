   M S B A M L   `   `   `  ���� K  GDotNetProjectOne, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DotNetProjectOneDotNetProjectOne  3clr-namespace:DotNetProjectOneDotNetProjectOne  3clr-namespace:DotNetProjectOneDotNetProjectOne  !    DotNetProjectOne.SearchPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3controlsclr-namespace:DotNetProjectOne     ,cclr-namespace:DotNetProjectOne     0localclr-namespace:DotNetProjectOne     -   $��
searchPage��.���� 
���   �$��3q����#333._�� .+���   K� ZIndex$  3��
������� J� IsHitTestVisible .   J� Opacity ��  �� ElementName$ 
searchPage�� �� Path$ 	IsEnabled�   opacityConverter �� 	Converter# [  � $��15,0,0,0q� � RowDefinitions �� $��3* ��� $��2* ��� $	��12* �.+��� $��0��$��Center=�
�������$��40(�$��Light"�$��2��$
��0,12q�.��Search page4   .DotNetProjectOne.OptionsMinimizeDisposeControl  -     Name$ disposeControl��$	��Top=�$��Right=�$��1��� $��1��$��2�� � ColumnDefinitions �� $	��20* ��� $	��15* ��� $��50 ��� $	��12* �.+��� $��8q�$��0��
���   �$��1q�._��� -   	 ��Name$	 Search��$��0q����#333$��Center=�
�������$��Light"�$��20(�$��10,0,0,0q�.��Type to search�� -   
 ��Name$
 SearchCombo��$��1��$��20(�$��Center=�$
��0,12q����#333.@��� $��Title��$
��Left=�$	��206�� �� 
IsSelected . �� $��Director��$
��Left=�$	��206���� $��Writer��$
��Left=�$	��206���� $��Producer��$
��Left=�$	��206���� $��Actor��$
��Left=�$	��206���� $��Composer��$
��Left=�$	��206���� -    ��Name$ searchButton��$��2��$��0q�
������ .���� $��8q�$��2��$��/Icons/search.png��� $��2��$��2�� �� �� .+�� $��0�� �� $��1* ��� $��6* �.+��� $��0��$��Center=�
�������$��35(�$��Light"�.��
Your films�� -    ��Name$ MyMoviesList��$��1��$��0q�
������ $��Stretch=�$��Stretch=�$��Hidden=���.  $��20,20,20,20q����� $ mymovies�����  �� DataType   DotNetProjectOne.Img"  mojadata��.R��  �Name$ DataGrid�� �� $
��150* ��� $
��100* � �� $	��23* ��� $	��23* ��� $	��23* �.+���  ��Name$ obraz��$��3��$��0��$	��150��$	��100��$	 0.5Q�$��Stretch=�$��Stretch=�$��1q����� *Str+ � ToolTip _� ���� *Name+�� $��1��$��0��
�������$��20(�$��Light"����� *Name+�� $��1��$��1��
�������$��20(�$��Light"����� *
Director+�� $��1��$��2��
�������$��20(�$��Light"����� *Year+� $��1�� �� $��1* ��� $��6* �.+��� $��0��$��Center=�
�������$��35(�$��Light"�.��Top 10 films�� -   $ TopMoviesList��$��1��$��0q�
������ $��Stretch=�$��Stretch=�$��Hidden=���.  $��20,20,20,20q����� $ 	topmovies����� "  mzz��.R�� $ DataGrid�� �� $
��150* ��� $
��100* � �� $	��23* ��� $	��23* ��� $	��23* �.+��� $ obraz��$��3��$��0��$	��150��$	��100��$	 0.5Q�$��Stretch=�$��Stretch=�$��1q����� *Str+ _� ���� *Name+�� $��1��$��0��
�������$��20(�$��Light"����� *Name+�� $��1��$��1��
�������$��20(�$��Light"����� *
Director+�� $��1��$��2��
�������$��20(�$��Light"����� *Year+