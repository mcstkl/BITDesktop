   M S B A M L   `   `   `  ����F  BBITServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BITServices.ViewBITServices.View  5   	   $    BITServices.View.JobAssignView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BITServices.View     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     � Title$  JobAssignView��5	   	   $	��400��6   $	��450��6,    � WindowStyle$
 None=�5
   	   
������  J� SnapsToDevicePixels .  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   � $��0q�6    � RowDefinitions 5      �� 5      $��30 �6    �� 5      $��* �6    .+�5      �� -   5         ��Name$ spTopBar��5      $��0��6+   
������ .+�5      ��  �� CornerRadius$ 	10 10 0 0��6   ���#3D59AB$��30��6G   ._�5      �� 
������ $��Right=�6:    �� Orientation$ 
Horizontal=�6V   .+�5      �� $��16(�6    $��Assign Contractor��6.   $��Stretch=�6J   $��0 0 80 0q�6f   $
��Bold"�6x   
�������6�   �� 5      -   5        $ spTopbar��5   >   
������ $ 
Horizontal=�6P   $��0 0 8 0q�6i   .+�5      �� -   5        	 ��Name$	 btnMinimizeWindow��5   %   ���#3D59AB$��0q�6U   .��5   "   "  FontAwesome.WPF.ImageAwesome  $��5 8 5 0q�63   
   Icon$
 WindowMinimize=�6D      
buttonIcon#��[  6Z   $��15��6~   $��15��6�      
Foreground
 �����6�   5      �� 5      -   5        $	 btnCloseWindow��5   %   ���#3D59AB$��0q�6R   .��5   "     $��5q�62   $
 Close=�6>   #��[  6K   $��15��6o   $��15��6z   
 �����6�   5      5       5!      5"      5#      � 5$      $��1��6   
�������.+�5%      �  5&      �� 5'      $��20 �6(   �� 5(      $��50 �6(   �� 5)      $��50 �6(   �� 5*      $��50 �6(   �� 5+      $��* �6(   �� 5,      $��50 �6(    � ColumnDefinitions 5.      �� 5/      $��* �6+   .+�51      �� $��Center=�6!   $��0��6<   $��20 0 0 0q�6I   $ 
Horizontal=�6[   .+�52      �� $��18(�6    $	��305��6.   $
��Left=�6:   6W   53      �� 54      $��Center=�6!   $��1��6<   $��20 0 0 0q�6I   $ 
Horizontal=�6[   .+�55      �� $��16(�6    $	��305��6.   $
��Left=�6:   .��6U   Minimum Contractor Rating6p   �� 56      $��18(�6t   $	��110��6�   $	��Top=�6�   $��30��6�   ��6"   �� *SelectedRating+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   57      �� 58      $��Center=�6"   $��0��6=   $��2��6M   $��20 0 0 0q�6Z   $ 
Horizontal=�6l   .+�59      �� $��16(�6    $	��305��6.   $
��Left=�6:   .��6U   Maximum Contractor Payrate6q   �� 5:      $��18(�6u   $	��110��6�   $	��Top=�6�   $��30��6�   ��6"   �� *SelectedPayRate+$ TwoWay=�$ PropertyChanged=�6�   5;      �� 5<      -   5        $	 
btnRefresh��5<   :   $��0��6   $��3��6-   $��	315 0 0 0q�6N   $	��110��5=      $��30��6*   $
��Bold"�66   ���#0275d8
���������5<   a   �� *RefreshCommand+ � 	Resources 5>       �� 
TargetType �� Property �� Value��%^   '��       �� 5?      " ��6$   .�5@   "   ��  �@��CornerRadius$ 5��6A   5A      5B      .��5C      �� $ 
Horizontal=�6%   .+�5D        $
 Filter=�6.   
 �����$��0 0 5 0q�6O   $��30��6`   $��18��6k   �� 5E      $��0 0 10 0q�6(   $��18(�6:   $��Filter��6H   5F      5G      &   System.Windows.Controls.DataGrid  5I         GridLinesVisibility$
 None=�6      AutoGenerateColumns .  $��3��6�   $��4��5J      $��9��6,   $   HorizontalScrollBarVisibility$ Hidden=�6=      AlternatingRowBackground
 �����   HeadersVisibility$ Column=�5K       $��
10 0 10 50q�6;   $	��0.2q�6O   
������  �� SelectedItem 5I   V   �� *SelectedContractor+��6�   �� *SkilledContractors+   Columns 5L      0  *System.Windows.Controls.DataGridTextColumn  5M      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      Header$ Fullname��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
FullName+$ TwoWay=�$ PropertyChanged=�6�     5N      $ Payrate��6   $ * 6�    61   �� *	PayRate+$ TwoWay=�$ PropertyChanged=�6�     5O      $ * 6�   $ Rating��6�    61   �� *ContractorRating+$ TwoWay=�$ PropertyChanged=�6�     5P      $ * 6�   $ Username��6�    61   �� *
UserName+$ TwoWay=�$ PropertyChanged=�6�    5T      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn��%�  '        7 �� 5U      8   "  6]   .�5V   "   ��  � �� �#be67166?   �� 5W   "    � ��
 �����6?   �� 5X   "    � ��
 �   �6@   �� 5Y   "    � ��$ 0 0 0 0q�6D   �� 5Z   "    � ��$ 1, 1, 0 , 0q�6;   �� 5[   "    � ��$ 38��6;   �� 5\   "    � ��$
 auto��6:   �� 5]   "    � ��$ 16(�6=   �� 5^   "    � ��$
 Bold"�6?   �� 5_   "    � ��$ Center=�6O   5`      5a         RowStyle 5b      �� 5c      )  #System.Windows.Controls.DataGridRow"  6$   .�5d   "   ��  �@��TextAlignment$ Center=�6L   �� 5e   "    � ��
 ���� 6?   �� 5f   "    � ��$ 14(�6=   �� 5g   "    � ��$ 1 2 1 2q�6D   5h         	CellStyle 5j      �� 5k      *	  $System.Windows.Controls.DataGridCell" 	 6$     �� Triggers  5l   "   P� 5m   &   ! P� Property! �@	 
IsSelected" P� Value" . . �5n   *   ��  � �� �#3D59AB6G   �� 5o   *    � ��$
 Bold"�6G   5p   '   5s      5u      �� 5y      $��5��6!   $ 
Horizontal=�6.   .+�5z      �� -   5        $	 	btnAssign��5z   :   $��0��6   $��5��6-   $��	200 0 0 0q�6M   $	��110��5{      $��30��6*   $
��Bold"�66   ���#0275d8
���������5z   `   �� *AssignCommand+ 5|      ��%^   '��       �� 5}      " ��6$   .�5~   "   ��  �@��CornerRadius$ 5��6A   5      5�      .��5�      �� $ 
Horizontal=�6%   .+�5�        $
 UserPlus=�6.   
 �����$��0 0 5 0q�6Q   $��30��6b   $��18��6m   �� 5�      $��0 0 10 0q�6(   $��18(�6:   $��Assign��6H   5�      5�      �� 5�      -   5        $	 btnDone��5�   :   $��0��6   $��5��6-   $��20 0 0 0q�6a   $	��110��5�      $��30��6*   $
��Bold"�66   ���#0275d8
������� 5�      ��%^   '��       �� 5�      " ��6$   .�5�   "   ��  �@��CornerRadius$ 5��6A   5�      5�      .��5�      �� $ 
Horizontal=�6%   .+�5�        $
 SignIn=�6.   
 �����$��0 0 5 0q�6O   $��30��6`   $��18��6k   �� 5�      $��0 0 10 0q�6(   $��18(�6:   $
��Done��6H   5�      5�      5�      5�      5�      5�      5�      5�      