   M S B A M L   `   `   `  ����F  BBITServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BITServices.ViewBITServices.View  5      /    )BITServices.View.ContractorManagementView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      *localclr-namespace:BITServices.View  5        N� Title$  ContractorManagementView��5
      .��5      � $��5 0 5 0q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �  5      �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��40��62   $��0 5 0 0q�6>   .+�5      "  FontAwesome.WPF.ImageAwesome     
Foreground �#666   Icon$ ChevronCircleRight=�64   $��Right=�6N   $y�Visible=�5   &   $��20��6;   $��10 0 0 0q�6H   �� 5      ���#666$��20(�6*   $
��Bold"�68   $��10 0 0 0q�6J   .��6\   Contractors6i   �� 5      $��35��6   $��18(�6$   $��20 0 0 0q�62   .��6D   
Search By:6P   �� 5      $��1 1 0 0q�6    �� CornerRadius$	 3.2��63   
���   �
������ $��28��6s   $��6q�6   ._�5      �� $��0 0 1 1q�6   $	 3.2��67   ���#444 �� Padding$ 1q�6]   ._�5       ��  �� SelectedIndex$ 0��6#    �� SelectedValuePath$ Content��6y   $��-1 -1 -1 -1q�6�   $��16(�6�   $��29��6�   	 �� SelectedValue	 65   �� *SelectedItemInFilter+
 �� Mode$
 OneWayToSource=�.@�5!      �� .��6+   -- Select --69   �� 5"      .��6,   	Firstname67   �� 5#      .��6+   
Lastname65   �� 5$      .��6+   	Payrate64   �� 5%      .��6+   Rating63   �� 5&      .��6+   Phone62   �� 5'      .��6+   Email62   5(      5)      5*      �� 5+      $��18(�6i   $��5 0 0 0q�6w   $	��220��6�   $��28��6�   ��6   �� *SearchValue+$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5,      $��0 0 0 0q�6   $ 
Horizontal=�6.   .+�5-      �� -   5         ��Name$ 	btnSearch��5-   ?   $��5 0 60 0q�6R   $��28��6d   $
��Bold"�6p   
����������#444��6   �� *SearchCommand+ � 	Resources 5.       �� 
TargetType �� Property �� Value��%^   '��       �� 5/      " ��6$   .�50   "   ��  �@��CornerRadius$ 5��6A   51      52      .��53      �� $ 
Horizontal=�6%   .+�54        $ Refresh=�6.    �#3D59AB6=   55      56      �� 58      -   5        $ btnAdd��58   Q   $��28��6a   $
��Bold"�6m   
����������#444��6   �� *
AddCommand+ 59      ��%^   '��       �� 5:      " ��6$   .�5;   "   ��  �@��CornerRadius$ 5��6A   5<      5=      .��5>      �� $ 
Horizontal=�6%   .+�5?        $
 Plus=�6.    �#666$��0 0 10 0q�6L   $��20��6^   $��14��6i   �� 5@      $��0 0 10 0q�6(   $��18(�6:   $	��Add��6H   5A      5B      �� 5C      -   5        $ 	btnDelete��5C   W   $��	10 0 10 0q�6j   $��28��6}   $
��Bold"�6�   
����������#444��6   �� *DeleteCommand+ 5D      ��%^   '��       �� 5E      " ��6$   .�5F   "   ��  �@��CornerRadius$ 5��6A   5G      5H      .��5I      �� $ 
Horizontal=�6%   .+�5J        $ Minus=�6.    �#666$��0 0 10 0q�6M   $��20��6_   $��4��6j   �� 5K      $��0 0 10 0q�6(   $��18(�6:   $��Delete��6H   5L      5M      �� 5N      -   5        $ 	btnUpdate��5N   5   $��28��6H   $
��Bold"�6T   
����������#444 5O      ��%^   '��       �� 5P      " ��6$   .�5Q   "   ��  �@��CornerRadius$ 5��6A   5R      5S      .��5T      �� $ 
Horizontal=�6%   .+�5U        $ ArrowUp=�6.    �#666$��0 0 10 0q�6O   $��20��6a   $��14��6l   �� 5V      $��0 0 10 0q�6(   $��18(�6:   $��Update��6H   5W      5X      5Y      5Z      &   System.Windows.Controls.DataGrid  5\      -   5          Name$ dgContractors��5\      $��Stretch=�6.      
IsReadOnly . $��1��6\      GridLinesVisibility$
 None=�6i      AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Hidden=�5^   q      AlternatingRowBackground
 �����   HeadersVisibility$ Column=�5`      $��0 5 0 0q�6.   $	��0.2q�6?   
������ ��5]      �� *Contractors+$
 TwoWay=�$ PropertyChanged=� �� SelectedItem 5^      �� *SelectedContractor+$
 TwoWay=�$ PropertyChanged=�   Columns 5a      0  *System.Windows.Controls.DataGridTextColumn  5b      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Firstname��6y      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *	FirstName+$
 TwoWay=�$ PropertyChanged=�6�     5c      $ Lastname��6x   $ * 6�    6)   �� *
LastName+$
 TwoWay=�$ PropertyChanged=�6�     5d      $ * 6v   $ Street��6�    6)   �� *Street+$
 TwoWay=�$ PropertyChanged=�6�     5e      $ * 6v   $ Suburb��6�    6)   �� *Suburb+$
 TwoWay=�$ PropertyChanged=�6�     5f      $ * 6x   $ Postcode��6�    6)   �� *
PostCode+$
 TwoWay=�$ PropertyChanged=�6�     5g      $ * 6u   $ State��6    6)   �� *State+$
 TwoWay=�$ PropertyChanged=�6     5h      $ * 6u   $ Phone��6    6)   �� *Phone+$
 TwoWay=�$ PropertyChanged=�6     5i      $ * 6u   $ Email��6    6)   �� *Email+$
 TwoWay=�$ PropertyChanged=�6     5j      $ * 6x   $ Username��6�    6)   �� *
UserName+$
 TwoWay=�$ PropertyChanged=�6�     5k      $ * 6�   $ Rating��6�    6)   �� *ContractorRating+$
 TwoWay=�$ PropertyChanged=�6�     5l      $ * 6w   $ Payrate��6�    6)   �� *	PayRate+$
 TwoWay=�$ PropertyChanged=�6�    5o      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn��%�  '        7 �� 5p      8   "  6U   .�5q      ��  � �� �#be671667   �� 5r       � ��
 �����67   �� 5s       � ��
 �   �68   �� 5t       � ��$ 0 0 0 0q�6<   �� 5u       � ��$ 1, 1, 0 , 0q�63   �� 5v       � ��$ 38��63   �� 5w       � ��$
 auto��62   �� 5x       � ��$ 16(�65   �� 5y       � ��$
 Bold"�67   �� 5z       � ��$ Center=�6G   5{      5|         RowStyle 5}      �� 5~      )  #System.Windows.Controls.DataGridRow"  6   .�5      ��  �@��TextAlignment$ Center=�6D   �� 5�       � ��
 ���� 67   �� 5�       � ��$ 14(�65   �� 5�       � ��$ 1 2 1 2q�6<   5�         	CellStyle 5�      �� 5�      *	  $System.Windows.Controls.DataGridCell" 	 6     �� Triggers  5�      P� 5�      ! P� Property! �@	 
IsSelected" P� Value" . . �5�   "   ��  � �� �#3D59AB6?   �� 5�   "    � ��$
 Bold"�6?   5�      5�      5�      �� 5�      $��2��6   .+�5�      � $��15 -20 20 10q�6   # � ColumnDefinitions# 5�      �� 5�      $��* �6+   �� 5�      $��3* �6+   �� 5�      $	��.5* �6+   �� 5�      $��1* �6+   �� 5�      $��3* �6+    5�      �� 5�      $��50 �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   .+�5�      �� $��16(�6   $��1��6*   $��	-4 0 0 20q�67   $��1��6J   $
��Bold"�6Z   .��6l   Contractor Details6�   �� 5�      $��2��6   $��0��6)   $��16(�69   .��6G   	Firstname6R   �� 5�      $��2��6   $��3��6)   $��16(�69   .��6G   
Lastname6Q   �� 5�      $��3��6   $��0��6)   $��16(�69   .��6G   Street6O   �� 5�      $��3��6   $��3��6)   $��16(�69   .��6G   Suburb6O   �� 5�      $��4��6   $��0��6)   $��16(�69   .��6G   
PostCode6Q   �� 5�      $��4��6   $��3��6)   $��16(�69   .��6G   State6N   �� 5�      $��5��6   $��0��6)   $��16(�69   .��6G   Phone6N   �� 5�      $��5��6   $��3��6)   $��16(�69   .��6G   Email6N   �� 5�      $��6��6   $��0��6)   $��16(�69   .��6G   
Username6Q   �� 5�      $��6��6   $��3��6)   $��16(�69   .��6G   
Password6Q   �� 5�      $��7��6   $��0��6)   $��16(�69   .��6G   Rating6O   �� 5�      $��7��6   $��3��6)   $��16(�69   .��6G   	Payrate6P   �� 5�      -   5        $ ��Name$$ tbFirstName��5�      {�.  $��2��6E   $��1��6R   $��16(�6b   $��0 0 0 10q�6p   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.FirstName+$
 TwoWay=�$ PropertyChanged=��� 5�      -   5        $$ 
tbLastName��5�      {�.  $��2��6D   $��4��6Q   $��16(�6a   $��0 0 0 10q�6o   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.LastName+$
 TwoWay=�$ PropertyChanged=��� 5�      -   5        $$ tbStreet��5�      {�.  $��3��6B   $��1��6O   $��16(�6_   $��0 0 0 10q�6m   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.Street+$
 TwoWay=�$ PropertyChanged=��� 5�      -	   5        $$ tbSuburb��5�      {�.  $��3��6B   $��4��6O   $��16(�6_   $��0 0 0 10q�6m   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.Suburb+$
 TwoWay=�$ PropertyChanged=��� 5�      -
   5        $$ 
tbPostCode��5�      {�.  $��4��6D   $��1��6Q   $��16(�6a   $��0 0 0 10q�6o   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.PostCode+$
 TwoWay=�$ PropertyChanged=��� 5�      -   5        $$ tbState��5�      {�.  $��4��6A   $��4��6N   $��16(�6^   $��0 0 0 10q�6l   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.State+$
 TwoWay=�$ PropertyChanged=��� 5�      -   5        $$ tbPhone��5�      {�.  $��5��6A   $��1��6N   $��16(�6^   $��0 0 0 10q�6l   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.Phone+$
 TwoWay=�$ PropertyChanged=��� 5�      -   5        $$ tbEmail��5�      {�.  $��5��6A   $��4��6N   $��16(�6^   $��0 0 0 10q�6l   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.Email+$
 TwoWay=�$ PropertyChanged=��� 5�      -   5        $$ 
tbUsername��5�      {�.  $��6��6D   $��1��6Q   $��16(�6a   $��0 0 0 10q�6o   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.UserName+$
 TwoWay=�$ PropertyChanged=��� 5�      -   5        $$ 
tbPassword��5�      {�.  $��6��6D   $��4��6Q   $��16(�6a   $��0 0 0 10q�6o   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.Password+$
 TwoWay=�$ PropertyChanged=��� 5�      -   5        $$ tbRating��5�      {�.  $��7��6B   $��1��6O   $��16(�6_   $��0 0 0 10q�6m   
�������$��0 0 0 1q�6�   ��6�   �� *%#SelectedContractor.ContractorRating+$
 TwoWay=�$ PropertyChanged=��� 5�      -   5        $$ 	tbPayrate��5�      {�.  $��7��6C   $��4��6P   $��16(�6`   $��0 0 0 10q�6n   
�������$��0 0 0 1q�6�   ��6�   �� *SelectedContractor.PayRate+$
 TwoWay=�$ PropertyChanged=�5�      � 5�      # 5�      �� 5�      $��* �6+   �� 5�      $��3* �6+   �� 5�      $	��.5* �6+   �� 5�      $��1* �6+   �� 5�      $��3* �6+   .+�5�      �� -   5        $ btnSaveUpdate��5�      $��1��64   $��
-150 0 0 0q�6`   $	��110��5�      $��45��6*   $
��Bold"�66   ���#3D59AB
�������{�.  ��5�   t   �� *UpdateCommand+ 5�      ��%^   '��       �� 5�      " ��6$   .�5�   "   ��  �@��CornerRadius$ 5��6A   5�      5�      .��5�      �� $ 
Horizontal=�6%   .+�5�        $
 Save=�6.    �#80fc39$��0 0 5 0q�6O   $��30��6`   $��18��6k   �� 5�      $��0 0 10 0q�6(   $��18(�6:   $
��Save��6H   5�      5�      �� 5�      -   5        $ 	btnCancel��5�      $��1��60   $��	150 0 0 0q�6X   $	��110��5�      $��45��6*   $
��Bold"�66   ���#3D59AB
�������{�.  ��5�   l   �� *CancelCommand+ 5�      ��%^   '��       �� 5�      " ��6$   .�5�   "   ��  �@��CornerRadius$ 5��6A   5�      5�      .��5�      �� $ 
Horizontal=�6%   .+�5�        $	 Ban=�6.   
 � E��$��0 0 5 0q�6P   $��30��6a   $��18��6l   �� 5�      $��0 0 10 0q�6(   $��18(�6:   $��Cancel��6H   5�      5�      �� 5�      -   5        $ 	btnSkills��5�   A   $��
-220 0 0 0q�6   $��4��61   $	��160��5�      $��45��6*   $
��Bold"�66   ���#3D59AB
���������5�   U   �� *SkillsCommand+ 5�      ��%^   '��       �� 5�      " ��6$   .�5�   "   ��  �@��CornerRadius$ 5��6A   5�      5�      .��5�      �� $ 
Horizontal=�6%   $��30 0 0 0q�6>   .+�5�        $ Braille=�6.    �#ffcc00$��0 0 5 0q�6R   $��30��6c   $��18��6n   �� 5�      $��0 0 50 0q�6(   $��18(�6:   $�� Skills��6H   5      5     �� 5     -   5        $ btnAvailabilities��5  @   $��	170 0 0 0q�6   $��4��60   $	��160��5     $��45��6*   $
��Bold"�66   ���#3D59AB
���������5  \   �� *AvailabilitiesCommand+ 5     ��%^   '��       �� 5     " ��6$   .�5  "   ��  �@��CornerRadius$ 5��6A   5     5	     .��5
     �� $ 
Horizontal=�6%   .+�5       $ PuzzlePiece=�6.    �#ffcc00$��0 0 5 0q�6V   $��30��6g   $��18��6r   �� 5     $��0 0 10 0q�6(   $��18(�6:   $��Availabilities��6H   5     5     5     5     5     �� 5  
   $��2��6   .+�5      �� -   5        % ��Name$% tbClock��5      ���#666
������ $	��300��6T   $	��100��6`   $��16(�6m   $
��Bold"�6{   $��Bottom=�6�   $��Right=�6�   $��0 0 -190 -50q�6�   5!     5"     5#     