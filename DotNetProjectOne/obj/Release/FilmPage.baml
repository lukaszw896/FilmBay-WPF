   M S B A M L   `   `   `  ���� K  GDotNetProjectOne, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DotNetProjectOneDotNetProjectOne  3clr-namespace:DotNetProjectOneDotNetProjectOne      DotNetProjectOne.FilmPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3controlsclr-namespace:DotNetProjectOne     0localclr-namespace:DotNetProjectOne     -   $��filmPage��.���� 
���   �$��3q����#333._�� .+��� -   $��GrayOutCanvas��  K� ZIndex$  3��
������� J� IsHitTestVisible .   J� Opacity ��  �� ElementName$ filmPage�� �� Path$ 	IsEnabled�   opacityConverter �� 	Converter# [  �  � RowDefinitions �� $	��100 ��� $��9* �.+�� $��0�� � ColumnDefinitions �� $��70 ��� $��7* �.+��� -   $��0��$��0q�
������ $��Center=�$��Right=�.���� $��/Icons/back_button.png���� $��1��$��Center=�
�������$��40(�$��Light"�$��2��$
��0,12q�.��	Film page4   .DotNetProjectOne.OptionsMinimizeDisposeControl  -     Name$ disposeControl��$	��Top=�$��Right=��� $��Visible=�$��1��.��� $	��Top=�$
��1275�� �� $	��10* ��� $��3* ��� $	��12* ��� $	��13* ��� $	��15* �.+�� $��0�� �� $	��173 ��� $��9* �.+��� $��10q�$��0��
���   �$��3q�._��� -   	 ��Name$	 Poster��� $��1�� �� $��1* ��� $��3* �.+��� -   
 ��Name$
 Title��$��10,0,0,0q�$��0��$��Center=�
�������$��27(�$��Light"�� $��1�� �� $��1* ��� $	��100 �.+��� $��10q�
���   �$��3q�._��� $
��Auto=�.���� -    ��Name$ Story��$��10q�$
��Wrap=�
�������$��15(��� -   $��1�����#3BA800$��0q�$��10q�$��40(�
�������$��Light"�.��Buy�� $��10q�$��1��
���   �$��3q�._��  �� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��7* �.+��� -	    ��Name$ OneStar��$��3q�
������ $��0��$��0q�.���� -
   $	 OneStarImage��$��/Icons/empty_star.png���� -   $ TwoStars��$��3q�
������ $��1��$��0q�.���� -   $	 TwoStarImage��$��/Icons/empty_star.png���� -   $ 
ThreeStars��$��3q�
������ $��2��$��0q�.���� -   $	 ThreeStarImage��$��/Icons/empty_star.png���� -   $ 	FourStars��$��3q�
������ $��3��$��0q�.���� -   $	 FourStarImage��$��/Icons/empty_star.png���� -   $ 	FiveStars��$��3q�
������ $��4��$��0q�.���� -   $	 FiveStarImage��$��/Icons/empty_star.png���� -   $
 	RatingBox��$��5��$��Center=�
�������$��25(�$��Light"�$��Right=�.��Rating� $��2�� �� $��5* ��� $��6* �.+��� $��0��$��10q�
���   �$��3q�._��  �� $��2* ��� $��9* �.+��� $��0��$��Center=�
�������$��25(�$��Light"�.��Actors�� -    ��Name$ 	ActorList��$��1��$��Hidden=�$��0q�
������ $��Stretch=�$��Stretch=���.  $��10q����� $ 
filmactors�����  �� DataType   DotNetProjectOne.Img"  .R��  �Name$ DataGrid�� �� $
��150* ��� $
��100* � �� $	��23* ��� $	��23* ��� $	��23* �.+��� $	 obraz��$��3��$��0��$	��100��$	��100��$	 0.5Q�$��Stretch=�$��Stretch=�$��1q����� *Str+ � ToolTip _� ���� *Name+�� $��1��$��0��
�������$��20(�$��Light"����� *Name+�� $��1��$��10q�
���   �$��3q�._��� -   $ 	PhotoList��$��1��$��0q�
������ $��Stretch=�$��Stretch=���.  $��10q����� $ moviephotos����� .R�$�  $� Orientation$ 
Horizontal=����� "  .R�� $ DataGrid�� �� $
��150* ��� $
��100* � �� $	��23* �.+��� $	 obraz��$��3��$��0��$	��300��$	��300��$	 0.5Q�$��Stretch=�$��Stretch=�$��1q����� *Str+�� $��10q�$��3��
���   �$��3q�._��  �� $��3* ��� $	��14* �.+��� $��0��$��Center=�
�������$��25(�$��Light"�.��More informations� $��1�� �� $��4* ��� $��4* ��� $��5* ��� $��5* ��� $��5* ��� $��4* �.+��� $��0��$��Center=�
�������$��18(�$��Light"�.��Release Date:�� $��1��$��Center=�
�������$��18(�$��Light"�.��	Director:�� $��2��$��Center=�
�������$��18(�$��Light"�.��
Writers:�� $��3��$��Center=�
�������$��18(�$��Light"�.��
Producers:�� $��4��$��Center=�
�������$��18(�$��Light"�.��
Composers:�� $��5��$��Center=�
�������$��18(�$��Light"�.��	Studio:�� -   $ 	YearBlock��$��0��$��	150,0,0,0q�$��Center=�$��19(�
�������$��Light"�$
��Wrap=�
1 May 2015�� -   $ DirectorBlock��$��1��$��	150,0,0,0q�$��Center=�$��19(�
�������$��Light"�$
��Wrap=�Joss Whedon�� -   $ WriterBlock��$��2��$��	150,0,0,0q�$��Center=�$��15(�
�������$��Light"�$
��Wrap=���Test Test Test TestTest TestTest TestTest Test Test TestTest TestTest TestTest TestTest TestTest TestTest Test Test TestTest TestTest TestTest TestTest TestTest TestTest Test�� -   $ ProducerBlock��$��3��$��	150,0,0,0q�$��Center=�$��15(�
�������$��Light"�$
��Wrap=��� -   $ ComposerBlock��$��4��$��	150,0,0,0q�$��Center=�$��15(�
�������$��Light"�$
��Wrap=��� -   $ StudioBlock��$��5��$��	150,0,0,0q�$��Center=�$��15(�
�������$��Light"�$
��Wrap=��� $��10q�$��4��
���   �$��3q�._�� .+��  �� $��5* ��� $	��23* ��� $��5* �.+��� $��0��$��Center=�
�������$��30(�$��Light"�.��
Comments�� -   $ CommentrList��$��1��
������ $��Stretch=�$��Stretch=���.  $��10q����� $ usercomments����� "  .R�� $ DataGrid�� �� $
��150* ��� $
��100* � �� $	��23* ��� $	��23* ��� $	��23* �.+��� $��0��$��0��$��16(�
�������$��Normal"����� *Login+�� $��1��$��0��$��16(�
�������$��Light"����� *	Comment+�� -   $��0q�$��0,0,20,0q�$��40��$��2��$��Center=�$��Right=�
�������
�������$��15(�.��Add comment