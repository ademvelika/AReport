   M S B A M L   `   `   `  ����D  @MYDIPLOMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MYDIPLOMA.DialogMYDIPLOMA.Dialog  5   	   &     MYDIPLOMA.Dialog.DocumentPreview   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MYDIPLOMA.Dialog     5   	   -   5          � Title$  DocumentPreview��5   	   
������ $��0q�6T    � WindowState$ 	Maximized=�6h    � WindowStartupLocation$ CenterScreen=�6�    � WindowStyle$
 None=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��AUTO �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Right=�6/   .+�5      �� -   5        
������ 
������ $��0q�5   H   .��5      �� $��40��6   $��/Images/print.png��6%   5      �� 5      -   5        $��	PDFExport��5   .   
������ $��0q�6?   
������ .��5      �� $��40��6   $��/Images/pdf.png��6$   6?   5      �� 5      -   5        $��ExcelExport��5   I   
������ 
������ .��5      �� $��40��6   $��/Images/excel.png��6$   6A   5      �� 5      -   5        $��30��5      $��Right=�6!   $��20(�6?   
������ .��5      �� $��/Images/delete.png��6   66   5      5      �� 5   
   -   5        $��Scroller��5   $   $��1��6   .��5      �� -   5        $��	Container��5       5!      5"      5#      5%      