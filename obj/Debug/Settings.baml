   M S B A M L   `   `   `  ����  WpfApplication1    WpfApplication1.Settings   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Settings��5   	    � SizeToContent$ WidthAndHeight=�5   
   $��400px��5   	    +� FocusedElement 5   	   ��  �� ElementName$ Title��.��5      �� $
��20pxq�6   .+�5	   
   �� $
��40px(�6   $��42��6$   $	��Top=�60   $��0,0,0,20q�6H   $��50��6Z   
Settings6s   � 5   
    � 	Resources 5       �� 
TargetType �� Property �� Value��%Y   '��       �� 5      " ��6   .�5      ��  � ��$ 	0,0,10,10q�6/   5      5       � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��3* �6#   	 � RowDefinitions	 5      �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    .+�5      � $��0��6   $��0��6#   .+�5       �� $
��20px(�6   
Username66   5!      � 5"      $��1��6   $��0��6#   .+�5#      �� -   5        $��Username��5#      $��22��6*   68   5$      � 5%      $��0��6   $��1��6#   .+�5&      �� $
��20px(�6   
Password66   5'      � 5(      $��1��6   $��1��6#   .+�5)      G� -   5        $��Password��5)      $��22��6.   5*      � 5+      $��0��6   $��2��6#   .+�5,      �� $
��20px(�6   	Team Name67   5-      � 5.      $��1��6   $��2��6#   .+�5/      �� -   5        $��TeamName��5/      $��22��6*   
 � ToolTip$8
 2E.g. the teamname from http://teamname.leankit.com��66   50      � 51      $��0��6   $��3��6#   .+�52      �� $
��20px(�6   
Board ID66   53      � 54      $��1��6   $��3��6#   .+�55      �� -   5        $��BoardID��55      $��22��6)   $8
 2E.g. the teamname from http://teamname.leankit.com��65   56      � 57      $��0��6   $��4��6#   .+�58      �� $
��20px(�6   Default Card Type ID6B   59      � 5:      $��1��6   $��4��6#   .+�5;      �� -   5        $��DefaultCardTypeID��5;      $��22��63   $8
 2E.g. the teamname from http://teamname.leankit.com��6?   5<      � 5=      $��0��6   $��5��6#   .+�5>      �� $
��20px(�6   Default Lane ID6=   5?      � 5@      $��1��6   $��5��6#   .+�5A      �� -   5        $��DefaultLaneID��5A      $��22��6/   $8
 2E.g. the teamname from http://teamname.leankit.com��6;   5B      � 5C      $��1��6   $��6��6#   .+�5D      �� -   5        $
��Save��5D      $��5q�6%   $��20(�60    �� 	IsDefault . .��6b   Save6h   5E      5F      5J      5K      