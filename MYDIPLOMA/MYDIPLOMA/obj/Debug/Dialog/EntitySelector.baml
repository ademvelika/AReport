   M S B A M L   `   `   `  ����D  @MYDIPLOMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MYDIPLOMA.DialogMYDIPLOMA.Dialog  5   	   %    MYDIPLOMA.Dialog.EntitySelector   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MYDIPLOMA.Dialog     5   	   -   5          � Title$  EntitetySelector��5	   	   $	��500��6b   $	��600��6o    � WindowStartupLocation$ CenterScreen=�6{    � 	Resources 5         BaseButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers	 P� Property
 P� Value �� 
TargetName �� BasedOn��%�  &	        '�� �    7   �� 5   
   " ��6(   .�5      ��  �@�FocusVisualStyle 61   Z� �� 5       � �� �#1ba1e26+   �� 5       � �� �#cccccc6,   �� 5       � ��$ 1q�60   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 	16,3,16,3q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��Chrome��6!   #��z��5   !   #��z��5   !   #��z��5   !    . ._�5      �� $��	Presenter��6/   #��z��6@   #��z��5   %   #��z��5   %   ��. # z 5!   %   5"       5#      P� 5$      	 � {�
 .  . �5%   "   ��  � �� �#3333336?   5&      P� 5'      	 �@J�IsMouseOver
 . . �5(   "   ��  � �� �#dddddd6?   �� 5)   "    � �� �#cccccc6@   �� 5*   "    � �� �#3333336?   5+      P� 5,      	 � ��
 . . �5-   "   ��  � �� �#1ba1e26?   �� 5.   "    � �� �#1ba1e26@   �� 5/   "    � �� �#ffffff6?   50      P� 51      	 �@J�	IsFocused
 . . �52   "   �� $ Chrome��6)    � �� �#1ba1e26T   53      55      57      58      �� 59   
   8   " ��6<   5:      .��5;      �  � RowDefinitions 5<   
   �� 5=      $
��auto �6   �� 5>      .+�5@   
   � ���#f2f2f2.+�5A      �� -   5        $��GONEXT��5A      .��68   
Go To Next6D   �� 5B      ���#1ba1e2$	��0.5q�6+   ._�5C      � -   5        $��
ManyEntity��5C      6-   5D      5E      �� 5F   
   -   5        $��Editor��5F      $��1��6   5T      5U      5V      