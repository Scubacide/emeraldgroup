   M S B A M L   `   `   `  ����H  DDealershipApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DealershipAppDealershipApp  5   	       DealershipApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DealershipApp     5   	     � Title$  Payment Calculator��5   	   $��242.449��6$   $��419.031��65   .��5	      � $��0,0,2,0q�6    � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ CarSelection��5      $
��Left=�6)   $��	46,64,0,0q�6D   $	��Top=�6W   $	��120��6o   $��22��6�   �� 5   
   -   5         ��Name$ 
inputYears��5      $
��Left=�6&   $��23��6A   $��
180,64,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $��6��6u   $	��Top=�6~   $	��129��6�    � ContextMenu 5   
   Z� 6!   �� 5   
   -   5         ��Name$ 
totalLabel��5      $�� ��6$   $
��Left=�6/   $��
46,138,0,0q�6J   $	��Top=�6^   $	��120��6v   $��26��6�   �� 5   
   $��Car Type��6   $��Center=�6#   $
��Left=�6G   $��	46,38,0,0q�6b   $	��Top=�6u   $	��120��6�   $��26��6�   �� 5   
   -   5        $ lengthLabel��5      $��Loan Length (Years)��6%   $
��Left=�6C   $
��Left=�6e   $��
180,38,0,0q�6�   $	��Top=�6�   $	��230��6�   $��26��6�   �� 5   
   -   5        $ CarPrice��5      $�� ��6"   $
��Left=�6-   $��	46,87,0,0q�6H   $	��Top=�6[   $	��120��6s   $��26��6   �� 5   
   -   5        $ InterestRate��5      $�� ��6&   $
��Left=�61   $��
314,63,0,0q�6L   $	��Top=�6`   $��96��6x   $��23��6�   �� 5   
   -   5        $ inputDiscount��5      $
��Left=�6)   $��23��6D   $��180,112,0,0q�6P   $
 Wrap=�6e   $��0��6y   $	��Top=�6�   $	��129��6�    5      Z� 6$   �� 5   
   -   5        $ discountLabel��5      $��Discount: 0%��6'   $
��Left=�6>   $��
180,87,0,0q�6Y   $	��Top=�6m   $	��230��6�   $��25��6�   �� 5   
   -	   5        $ monthlyLabel��5      $�� ��6&   $
��Left=�61   $��
46,112,0,0q�6L   $	��Top=�6`   $	��120��6x   $��26��6�   5      5      