   M S B A M L   `   `   `  ����[  WEnvGraphique.Evaluation2.ATM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:EnvGraphique.Evaluation2.ATM.WPF.Views&EnvGraphique.Evaluation2.ATM.WPF.Views  5      K GWPFCustomControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:WPFCustomControl;assembly=WPFCustomControlWPFCustomControl 6Q   C    =EnvGraphique.Evaluation2.ATM.WPF.Views.AdminCreateAccountView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:EnvGraphique.Evaluation2.ATM.WPF.Views     5      UWPFCustomControl8clr-namespace:WPFCustomControl;assembly=WPFCustomControl     6Q   -   5        .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��Utilisateur:��61   $��22(�6E   $��10 20q�6S   $��Right=�6b      BrushHeaderSecondary#��[  6~   $��SemiBold"�6�   �� 5   
   $��0��6a   $��1��6n   $��20(�6~   $
��Bold"�6�   $��10 20q�6�   $��0��6�   ��6   �� *AvailableUsers+ �� SelectedItem 6;   �� *SelectedUser+6�   �� 5   
   $��1��6   $��0��6!   $��Type de compte:��61   $��22(�6H   $��10 20q�6V   $��Right=�6e   #��[  6�   $��SemiBold"�6�   �� 5   
   -   5         ��Name$ comboBoxAccountType��5   @   $��1��6]   $��1��6j   $��20(�6z   $
��Bold"�6�   $��10 20q�6�    �� SelectedIndex$ 0��6�   $��1��6�    6   �� *SelectedAccountType+6�   !  WPFCustomControl.InputField  5   
   -   5          Name$ initialBalance��5   &   $��2��6>   $��0��6K   $��10q�6[      	FieldName$ Balance initiale ($)��6�      FieldFontSize$ 20Q�6�   $��SemiBold"�6�      FieldForegroundColor �	#FF28436F	   FieldBackgroundColor
	 �����
   FieldNameForegroundColor
 �	#FF28436F$��2��6g  ��.    Input 6g   �� *InitialBalance+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6t    5   
   -   5        $ maxWithdrawal��5   &   $��2��6=   $��1��6J   $��10q�6Z   $! Montant retrait maximal ($)��6�   $ 20Q�6�   $��SemiBold"�6�    �	#FF28436F
	 �����
 �	#FF28436F$��3��6r  ��.  6f   �� *MaxWithdrawalAmount+$ TwoWay=�$ PropertyChanged=�6    5   
   -   5        $ interestRate��5   &   $��3��6<   $��0��6I   $��10q�6Y   $ Taux d'intérêt (%)��6�   $ 20Q�6�   $��SemiBold"�6�    �	#FF28436F
	 �����
 �	#FF28436F��. $��4��6r   6e   �� *InterestRate+$ TwoWay=�$ PropertyChanged=�6r    5   
   -   5        $ invoicePaymentFee��5   &   $��3��6A   $��1��6N   $��10q�6^   $  Frais paiement facture ($)��6�   $ 20Q�6�   $��SemiBold"�6�    �	#FF28436F
	 �����
 �	#FF28436F��. $��5��6�   6j   �� *InvoicePaymentFee+$ TwoWay=�$ PropertyChanged=�6�  �� 5    
   $��4��6?   $��1��6L     SubmitButton#��[ 6\   $��Enregistrer��6�   $��10 20 10 10q�6�   $��6��6�   ��6   �� *AdminCreateAccountCommand+6�   5!      5"      