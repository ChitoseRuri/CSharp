   M S B A M L   `   `   `  ����Q  MSupermarketSalesSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SupermarketSalesSystemSupermarketSalesSystem  5   	   &     SupermarketSalesSystem.Assistant   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:SupermarketSalesSystem     5   	     � Title$  	Assistant��5   	   $	��400��6   $	��600��6(   .��5	      � $	��371��6   $��0,0,0.333,-0.333q�6   $��Bottom=�62    � ColumnDefinitions 5
   
   �� 5      $
��200* �6   �� 5      $
��245* �6   �� 5      $
��149* �6   .+�5   
   �� -   5         ��Name$ 
m_ListName��5      $	��300��6&   $��0,10,148.333,0q�63   $	��Top=�6K   $��1��6c   $��2��6s   �� 5   
   -   5        $ m_ListPrice��5      $	��300��6'   $��0.333,10,0,0q�64   $	��Top=�6J   $��2��6b   $��Right=�6r   �� 5   
   -   5         ��Name$ m_TotalPriceLabel��5      $��	合计：��6+   $��1��69   $��244,319,1.333,0q�6I   $	��Top=�6b   $��Right=�6z   $��25��6�   $��2��6�   �� 5   
   -   5         ��Name$ 	m_Confirm��5      $��结账��6$   $
��Left=�61   $��160,349,0,0q�6L   $	��Top=�6a   $��75��6y   $��1��6�   $��20��6�   6�   �� 5   
   $��	收款：��6   $
��Left=�6   $��
78,319,0,0q�69   $	��Top=�6M   $��25��6e   $��1��6q   $��46��6�   �� 5   
   -   5         ��Name$ m_GetPriceText��5      $
��Left=�6*   $��25��6E   $��124,319,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $��0��6z   $	��Top=�6�   $	��120��6�   $��Center=�6�   $��Right=�6�   $��1��6�   �� 5   
   -   5        $ 	m_AddItem��5      $��添加��6$   $
��Left=�61   $��160,319,0,0q�6L   $	��Top=�6a   $��75��6y   $��25��6�   $��2��6�   6�   �� 5   
   -   5        $ m_ItemIDText��5      $
��Left=�6(   $��25��6C   $��
10,319,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��150��6�   $��Center=�6�   $��Right=�6�   �� 5   
   -   5        $ m_ListID��5      $	��300��6$   $��0,10,0,0q�61   $	��Top=�6C   5      5      