   M S B A M L   `   `   `  ����Q  MSupermarketSalesSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SupermarketSalesSystemSupermarketSalesSystem  5   	   (    "SupermarketSalesSystem.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:SupermarketSalesSystem     5   	     � Title$  SupermarketSalesSystem��5   	   $��217.313��6(   $	��400��69    � WindowStartupLocation$ CenterScreen=�6E   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ m_AdminLogin��5      $��	管理员��6'   $��Center=�65   $��0,73,0,0q�6R   $	��Top=�6d   $	��150��6|   $��30��6�   6�   �� 5   
   $��登录��6   $��Center=�6   $��0,23,0,0q�6:   $	��Top=�6L   $��24(�6d   $��41��6r   $��58��6~   �� 5   
   -   5        $ m_AssistantLogin��5      $��	销售员��6+   $��Center=�69   $��	0,124,0,0q�6V   $	��Top=�6i   $	��150��6�   $��30��6�   6�   �� 5   
   -   5         ��Name$ m_Name��5      $��Center=�6"   $��30��6?   $��0,80,0,0q�6K    �� TextWrapping$
 Wrap=�6]   $��TextBox��6q   $	��Top=�6�   $	��150��6�   $��24(�6�   �� 5   
   -   5        $ 
m_Password��5      $��Center=�6&   $��30��6C   $��	0,122,0,0q�6O   $
 Wrap=�6b   $��TextBox��6v   $	��Top=�6�   $	��150��6�   $��24(�6�   �� 5   
   -   5        $ m_Cancel��5      $��返回��6#   $��Center=�60   $��-80,159,0,0q�6M   $	��Top=�6b   $��74��6z   $��19��6�   6�   �� 5   
   -   5        $ m_Enter��5      $��确认��6"   $��Center=�6/   $��
80,159,0,0q�6L   $	��Top=�6`   $��74��6x   $��19��6�   6�   �� 5   
   -   5        $ m_TerminalIP��5      $
��Left=�6(   $��25��6C   $��58,5,0,0q�6O   $
 Wrap=�6a   $��	127.0.0.1��6u   $	��Top=�6�   $	��120��6�   $��Center=�6�   �� 5   
   $��	终端ip:��6   $
��Left=�6    $��10,4,0,0q�6;   $	��Top=�6M   $��25��6e   �� 5   
   -   5        $ m_TerminalPort��5      $
��Left=�6*   $��25��6E   $��	187,5,0,0q�6Q   $
 Wrap=�6d   $��12235��6x   $	��Top=�6�   $��Center=�6�   $��58��6�   5      5      