   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Price_CalculatorPrice_Calculator  5	   	   !    Price_Calculator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Price_Calculator     5	   	   -   5          �Name$  _this��5   	      
MainWindow#���   5       � Title$ Price Calculator��5   	   $��347.385��6"   $��531.666��63    � WindowStartupLocation$ CenterScreen=�5   	   .��5      (� .��5   
   �� $
��Left=�6   $	��318��6,   $	��Top=�69   $	��553��6Q   $��3��6]   $��	0,0,-27,0q�6n   ._�5      � -   5         �Name$ MainWindowGrid��5   <     MainBackground#���  6   $��0,0,0,0q�6T    � RowDefinitions 5      �� 5      $��8* �6$   �� 5      $	��27* �6$   �� 5      $��8* �6$   �� 5      $
��116* �6$   .+�5      �� -   5        $��SavedLedger��5   B     LedgerDisplay#���  6   $
��Left=�6U   $	��186��6p   $��
306,39,0,0q�6}    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��202��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $��3��6�    �� 
IsReadOnly . $��1��6  �� 5      -   5          CalculateButton#���  5      $��	Calculate��6C   $
��Left=�6W   $��29��6r   $��185,181,0,0q�6~   $	��Top=�6�   $��97��6�   $��3��6�   �� 5      -   5          
SaveButton#���  5      $
��Save��6>   $
��Left=�6M   $��25��6h   $��306,183,0,0q�6t   $	��Top=�6�   $��81��6�   $��3��6�   �� 5      -   5         ��Name$ ClearButton��5      #���  6.   $��Clear��6S   $
��Left=�6c   $��25��6~   $��427,183,0,0q�6�   $	��Top=�6�   $��81��6�   $��3��6�   {�.  6�   	� 5      -   5        	 	�Name$	 	DarkTheme��5        RadioButton_Left#���  61   $��
Dark Theme��6\   $
��Left=�6q   $��11,6,0,0q�6�   $	��Top=�6�   
 d� 	IsChecked$
 FalseY�6�   $��24��6�   $��73��6�   $��2��6�   	� 5      -   5        $	 
LightTheme��5        RadioButton_Right#���  62   $��Light Theme��6^   $��Right=�6t   $��	0,6,387,0q�6�   $	��Top=�6�   $

 TrueY�6�   $��24��6�   $��76��6�   $��2��6   � 5!        LabelBackground#���  6   $
��Left=�6A   $	��186��6\   $��	13,39,0,0q�6i   $	��Top=�6|   $	��269��6�   $��3��6�   $��1��6�    5"      �� 5#      $��* �6(   65   �� 5$      $��* �6(   65   �� 5%      $��* �6(   65   �� 5&      $��* �6(   65   �� 5'      $��* �6(   65    � ColumnDefinitions 5)      �� 5*      $
��127* �6+   6:   �� 5+      $
��142* �6+   6:   .+�5.      �� -	   5        $��
Restaurant��5.   �     BillTextbox#���  6   $��Center=�6D   $��0��6f   $��1��6s   $��Center=�6�   $��22��6�   $��13,7,9,8q�6�   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   $	��120��6  �� 5/      -
   5        $��Price��5/   �   #���  6   $��Center=�6D   $��1��6f   $��1��6s   $��Center=�6�   $��22��6�   $��13,8,9,7q�6�   $
 Wrap=�6�   $��0��6�   $��Center=�6�   $	��120��6  6M  �� 50      -   5        $	��Tip��50   �   #���  6   $��Center=�6D   $��2��6f   $��1��6s   $��Center=�6�   $��22��6�   $��13,8,9,7q�6�   $
 Wrap=�6�   $��15��6�   $��Center=�6�   $	��120��6  60  �� 51      -   5        $	��Tax��51   �   #���  6   $��Center=�6D   $��3��6f   $��1��6s   $
��Left=�6�   $��22��6�   $��13,8,0,0q�6�   $
 Wrap=�6�   $��7��6�   $	��Top=�6�   $	��120��6�   6+  �� 52      -   5        $��Total_With_Tax��52   �   #���  6   $��Center=�6D   $��4��6f   $��1��6s   $��Center=�6�   $��20��6�   $��13,9,9,8q�6�   $
 Wrap=�6�   $�� ��6�   $��Center=�6�   $	��120��6   . 6  �� 53       	 	BillLabel#��� 	 6   $��0��6@   $��0��6M   $��Restaurant Name��6]   $��Center=�6w   $��29��6�   $��4,4,13,4q�6�   $��Center=�6�   $	��110��6�   �� 54      #��� 	 6   $��1��6@   $��0��6M   $��Price of Meal��6]   $��Center=�6u   $��25��6�   $��4,7,13,5q�6�   $��Center=�6�   $	��110��6�   �� 55      #��� 	 6   $��2��6@   $��0��6M   $��Tip %��6]   $��Center=�6m   $��25��6�   $��4,7,13,5q�6�   $��Center=�6�   $	��110��6�   �� 56      #��� 	 6   $��3��6@   $��0��6M   $��Tax %��6]   $��Center=�6m   $��25��6�   $��4,7,13,6q�6�   $��Center=�6�   $	��110��6�   �� 57      -   5        $��LblTotal��57   ^    
 
TotalLabel#��� 
 6   $��4��6A   $��0��6N   $��Total��6n   $��Center=�6~   $��25��6�   $��4,4,13,8q�6�   $��Center=�6�   $	��110��6�   58      59      5:      5;      5<      