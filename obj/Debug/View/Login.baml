   M S B A M L   `   `   `  ����F  BBITServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BITServicesBITServices  5   	       BITServices.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   %localclr-namespace:BITServices  5   	   -   5          � Title$  BITServices Login��5	   	   $	��500��6#   $	��800��60   $��14(�6<    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.    � AllowsTransparency . 
������  J� SnapsToDevicePixels . .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   
������ $��2��6;   .+�5      ��  �� CornerRadius$ 	10 10 0 0��6   ���#3D59AB$��30��6C   ._�5      �� $��Right=�6    �� Orientation$ 
Horizontal=�69   .+�5      �� $��Stretch=�6   $��	0 0 310 0q�68   $
��Bold"�6K   
�������.��6p   Login6w   �� 5      -   5         ��Name$ spTopbar��5   !   $ 
Horizontal=�63   .+�5      �� -   5        	 ��Name$	 btnMinimizeLoginWindow��5   !   ���#3D59AB$��0q�6V   .��5      "  FontAwesome.WPF.ImageAwesome  $��5 8 5 0q�6/   
   Icon$
 WindowMinimize=�6@      
buttonIcon#��[  6V   $��15��6z   $��15��6�      
Foreground
 �����6�   5      �� 5      -   5        $	 btnCloseLoginWindow��5   !   ���#3D59AB$��0 0 10 0q�6S   .��5        $��5q�6.   $
 Close=�6:   #��[  6G   $��15��6k   $��15��6v   
 �����6�   5       5!      5"      5#      5$      � 5&   
   $��1��6   $��2��6    � ColumnDefinitions 5'      �� 5(      $
��1.5* �6#   �� 5)      $��2* �6#   .+�5+      �� $
��Left=�6   $	��Top=�6/   $	��110��6G   $��	10 20 0 0q�6T   $��../Images/bitlogo.png��5,       K� ZIndex$ 1��6/   �� 5-      $ 0 0 0 10��6   ��5.      �� 5/       �� 
StartPoint$	 0,1&�6*    �� EndPoint$	 1,1&�6;   .��50      �  � Color$ 
WhiteSmoke��6'    � Offset$ 1Q�6:   � 51      $ #ecd1b9��6'   $ 0Q�67   52      ._�54      �� $��0��6   $��Center=�6-   .+�55      �� $��	40 60 0 0q�6   $��../Images/background.png��6/   56      57      �� 5;      
�������$��1��6-   $ 0 0 10 0��6=   ._�5<      �� $��1��6   
������ $��Center=�6F   .+�5@      �� -   5         ��Name$ lblLogin��5@   (   $��20q�6   $
��Bold"�6:   $��Center=�5A      $��24(�65   ���#301a00$��Arial Rounded MT Bold)�5B      $��Welcome to BIT Services��6;   �� 5C      -   5        $ lblLoginHint��5C      ���#824700$%��Please enter your login details��5D      $��Center=�5E      �� 5G      $��1q�6   ���#acb0af$
��70 7q�6G   $ 5��6U   ._�5H      � $	��7 9q�6    5I      �� 5J   "   $
��auto �63   �� 5K   "   $��* �63   .+�5M      �� $��../Images/profile.png��6$   $��20��6C   �� 5N      -   5         ��Name$ textUsername��5N   6    � Cursor$
 Hand��6(   $��Username��6o     hint#��[ 6   �� 5O      -   5         ��Name$ txtUsername��5O   4   $
 Hand��6&     textBox#��[ 6o   5P      5Q      �� 5T      $��1q�6   ���#acb0af$
��70 7q�6G   $ 5��6U   ._�5U      � $	��7 9q�6    5V      �� 5W   "   $
��auto �63   �� 5X   "   $��* �63   .+�5Z      �� $��../Images/key.png��6$   $��20��6?   �� 5[      -	   5        $ textPassword��5[   6   $
 Hand��6(   $��Password��6o   #��[ 6   G� 5\      -
   5         G�Name$ txtPassword��5\   8   $
 Hand��6*   #��[ 6{   5]      5^      �� 5_      $
 Hand��6    $��
70 0 240 0q�6.   $��Forgot your Password?��6B   ���#0095ff6_   �� 5`      -   5        $	 btnLogin��5`      $
 Hand��6/   $��Login��6=    
 button#��[ 5a      69   5c      5d      �� 5e      $
 Hand��6   $��10(�6&   $��	70 0 0 10q�64   $��Copyright Policy��6G   $��1��6_   $ 1��6o   $��Bottom=�5f      $
��Left=�6+   ���#187bcd6F   �� 5g      $
 Hand��6   $��10(�6&   $��
150 0 0 10q�64   $��User Agreement��6H   $��1��5h      $ 1��6$   ���#187bcd$��Bottom=�5i      $
��Left=�6+   �� 5j      $
 Hand��6   $��10(�6&   $��
230 0 0 10q�64   $��Send Feedback��6H   $��1��6]   $ 1��6m   $��Bottom=�5k      $
��Left=�6+   ���#187bcd6F   �� 5l      $��12(�6   $��	0 0 10 10q�6&   $��BITServices ©2022��69   $��1��6R   $ 1��6b   $��Bottom=�5m      $��Right=�6+   ���#187bcd6G   5n      5o      5p      