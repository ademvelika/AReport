   M S B A M L   `   `   `  ���� D  @MYDIPLOMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MYDIPLOMA.DialogMYDIPLOMA.Dialog  %    MYDIPLOMA.Dialog.EntitySelector   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:MYDIPLOMA.Dialog     -     � Title$  EntitetySelector��$	��500��$	��600�� � WindowStartupLocation$ CenterScreen=� � 	Resources    BaseButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers	 P� Property
 P� Value �� 
TargetName �� BasedOn��%�  &	        '�� �    7   �� " ��.���  �@�FocusVisualStyle Z� ��  � �� �#1ba1e2��  � �� �#cccccc��  � ��$ 1q���  � ��
 �������  � ��$ Center=���  � ��$ Center=���  � ��$ 	16,3,16,3q���  � �� �� " ��.R��� $��Chrome��#��z��#��z��#��z�� . ._��� $��	Presenter��#��z��#��z��#��z����. # z  P� 	 � {�
 .  . ���  � �� �#333333P� 	 �@J�IsMouseOver
 . . ���  � �� �#dddddd��  � �� �#cccccc��  � �� �#333333P� 	 � ��
 . . ���  � �� �#1ba1e2��  � �� �#1ba1e2��  � �� �#ffffffP� 	 �@J�	IsFocused
 . . ��� $ Chrome�� � �� �#1ba1e2�� 8   " ��.���  � RowDefinitions �� $
��auto ��� .+�� ���#f2f2f2.+��� -   $��GONEXT��.��
Go To Next�� ���#1ba1e2$	��0.5q�._�� -   $��
ManyEntity���� -   $��Editor��$��1��