   M S B A M L   `   `   `  ����K  G09_Bank_Rüscher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:_09_Bank_Rüscher_09_Bank_Rüscher  5   	   "    _09_Bank_Rüscher.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:_09_Bank_Rüscher     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Name:��6   $
��Left=�6/   $��	49,37,0,0q�6J   $	��Top=�6]   �� 5   
   -   5        $ label1��5      $��Amount:��6    $
��Left=�62   $��	49,75,0,0q�6M   $	��Top=�6`   �� 5   
   -   5        $ label2��5      $��	Interest:��6    $
��Left=�64   $��
49,114,0,0q�6O   $	��Top=�6c   �� 5   
   -   5         ��Name$ 	buttonAdd��5      $	��Add��6$   $
��Left=�62   $��
244,37,0,0q�6M   $	��Top=�6a   $��91��6y   $��23��6�   6�   �� 5   
   -   5        $ 
buttonFind��5      $
��Find��6%   $
��Left=�64   $��
244,75,0,0q�6O   $	��Top=�6c   $��91��6{   $��23��6�   6�   �� 5   
   -   5        $ buttonShowAll��5      $��Show All��6(   $
��Left=�6;   $��244,114,0,0q�6V   $	��Top=�6k   $��91��6�   $��23��6�   6�   �� 5   
   -   5         ��Name$ textBoxName��5      $
��Left=�6'   $��23��6B   $��
108,37,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��120��6�   �� 5   
   -   5        $ textBoxAmount��5      $
��Left=�6)   $��23��6D   $��
109,75,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��120��6�   �� 5   
   -	   5        $ textBoxInterest��5      $
��Left=�6+   $��23��6F   $��109,114,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�   �� 5   
   -
   5         ��Name$ listBoxBankAccounts��5      $
��Left=�6/   $	��164��6J   $��
49,145,0,0q�6W   $	��Top=�6k   $	��360��6�   �� 5   
   -   5        $ buttonDeposit��5      $��Deposit��6(   $
��Left=�6:   $��414,145,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5        $ buttonWithDraw��5      $��WithDraw��6)   $
��Left=�6<   $��414,181,0,0q�6W   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $ buttonDelete��5      $��Delete��6'   $
��Left=�68   $��414,218,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5        $ buttonClose��5      $��Close��6&   $
��Left=�66   $��414,253,0,0q�6Q   $	��Top=�6f   $��75��6~    J� RenderTransformOrigin$ 0.049,-0.317&�6�   6�   5      5      