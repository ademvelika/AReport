   M S B A M L   `   `   `  ���� D  @MYDIPLOMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MYDIPLOMA	MYDIPLOMA  =#clr-namespace:MYDIPLOMA.MyControlerMYDIPLOMA.MyControler      MYDIPLOMA.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:MYDIPLOMA     5mycon#clr-namespace:MYDIPLOMA.MyControler     -     � Icon$  adi.ico�� � Title$ 
MainWindow�� � 	Resources    ScrollThumbs �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle  BaseButtonStyle J� SnapsToDevicePixels ��Name �� BasedOn��%�  &	        '�� P    &	 ^    'd� �    7  �� " n�.���  � �� �� " n�.R�� $
 Grid��.+��� $��Stretch=�$��Stretch=�$
��Auto��$
��Auto��
������ �� $ 
Rectangle1��$	 10��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��#��z��
 P�  �@�Tag$ 
Horizontal��. ��� $ 
Rectangle1�� � ��$
 Auto���� $ 
Rectangle1�� � ��$ 7���� " ��.���  �@��IsFlicksEnabled .  ��  � ��
 �������  � ��
 �������  � ��$ 10����  � �� �� " ��.R�� $ GridRoot��$��19��#��z�� �� $��0.00001* �.+�]� $ 
PART_Track��$��0����. |�.   n� $ Thumb��#��z��#���    �� $ PageUp��$��ScrollBar.PageDownCommand��$ 0Q�|�.   �� $ PageDown��$��ScrollBar.PageUpCommand��$ 0Q�|�.  
 P� $ Thumb�� �@J�IsMouseOver . . ��� # �  $ Thumb�� � ��P� $ Thumb�� �@n�
IsDragging . . ��� # �  $ Thumb�� � ��P�  � {� .  . ��� $ Thumb�� � y�$ 	Collapsed=�P�  �@��Orientation$ 
Horizontal=�. ��� $ GridRoot�� �@�LayoutTransform �� $	 -90Q��� $ 
PART_Track�� �@�LayoutTransform �� $	 -90Q���  � ��$
 Auto����  � ��$ 12���� $ Thumb�� �@�Tag$ 
Horizontal���� $ PageDown�� � ��$ ScrollBar.PageLeftCommand���� $ PageUp�� � ��$  ScrollBar.PageRightCommand���� " d�.���  �@�FocusVisualStyle Z� ��  � ��
 �������  � �� �#cccccc��  � ��$ 0q���  � ��$ Black"���  � ��$
 Left=���  � ��$ Center=���  � ��$ 7,0,10,0q���  � ��$ 0,0,0,2q���  � ��
 �   ���  � ��$ 15(���  � ��$ 40����  � �� �� " d�.R��� $ Chrome��#��z��#��z��#��z�� . ._��� $ 	Presenter��#��z��#��z��#��z����. # z 
 P�  � {� .  . ���  � �� �#333333P�  �@J�IsMouseOver . . ���  � �� �#67b8e0��  � �� �#cccccc��  � ��
 �����P�  � �� . . ���  � �� �#1ba1e2��  � �� �#1ba1e2��  � �� �#ffffffP�  �@J�	IsFocused . . ��� $ Chrome�� � �� �#1ba1e2�� 8   " d�.���  �� $
��auto ��� $��* � � ColumnDefinitions �� $
��auto ��� $
��auto ��� $��6* ��� $
��auto �.+��� $��0��$��3��.+�o� .@�m� $y�	Collapsed=�$
��File��.@�m� -   $
��Open��m� -   $��SaveFile��$
��Save��m� -   $	��New��$	��New��+  %System.Windows.Controls.Ribbon.Ribbon  $��3��   HelpPaneContent 1  +System.Windows.Controls.Ribbon.RibbonButton     SmallImageSource$ Images\help.png��   QuickAccessToolBar =  7System.Windows.Controls.Ribbon.RibbonQuickAccessToolBar  .@�  -     Name$
 Save��$ Images/save.png��    ApplicationMenu  :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5  /System.Windows.Controls.Ribbon.RibbonMenuButton!   KeyTip$! F��.@�>  8System.Windows.Controls.Ribbon.RibbonApplicationMenuItem  -   3  -System.Windows.Controls.Ribbon.RibbonMenuItem"   ImageSource$" Images/openfileicon.png��$
��Open��  -   $	��New��$" Images/actionfileicon.png��  $��Options��$" Images/options.png��  $
��Exit��$" Images/quit.png��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  $
��Home��#   KeyTip$# H��.@�0	  *System.Windows.Controls.Ribbon.RibbonGroup	  -   $ 	 Name$$ ClipboardGroup��$��Preview��.@�  -	   %   LargeImageSource$% /Images/preview.png��&   Label$& Preview��	  -
   $$ Employee��$��Property��.@�2
  ,System.Windows.Controls.Ribbon.RibbonControl
  .��� .+��� $��15(�.��	Font Size�� -   $��FontSize��$��15(�$��30��$��35��
�������$��Center=�' �� SelectedIndex$' 0���� $��15(�$��1��.��Ngjyra�� -   $��NgjyraCombo��$��30��
�������$��Center=�$' 7���� $��15(�.��Border�� -   $��BorderClick��
������ 
������ .���� $��20��$��/Images/border.png��	  $��Controls��.@�  -   $% Images/stext.png��$& Static Text��(   KeyTip$( X��  -   $% Images/database.png��$& Field��$( X��  -   $% Images/tabele.png��$& Table��$( X��  -   $��LineBtn��$% Images/line.png��$
& Line��	  $��Filter��.@�  -   $% /Images/filter.png��$& Filter��2  ,System.Windows.Controls.Ribbon.RibbonTextBox  -   $��
FilterText��$��-��  $
��Data��$# D��.@�	  .@�
  .��� .+��� .��
Instanca�� -   $��
MyIntances��$	��120��) �� 
IsEditable) . �� -   $��LoadDatabases��$	��5,0q�.��Load�� .��
Databaza�� -   $��DatabaseCombo��$	��120��	  .@�  -   $��NgarkoSkemen��$% /Images/ImportDB.png��$& Ngarko Skemen��	  .@�  -   $��ClearSchema��$% /Images/reset.png��$& Pastro Skeme��  $��Advanced��$# L���� 9� -   $��SchemaExpander�����#D5DBE9$��1��$��0��$��2��* 9� ExpandDirection$* Right=�.���� $��0,0,10,5q�$
��Auto=�.���� 
�������._��� -   $��	LeftPanel��.+���   shiritibackgroud#��[ .��All Entities�� -   $��AllEntities��$��Stretch=��� #��[ .��RelationShip�� -   $��ChildrenEnities���� $��1��$��2���� -   $��Editor��$��1��
�������$��2��$��2��