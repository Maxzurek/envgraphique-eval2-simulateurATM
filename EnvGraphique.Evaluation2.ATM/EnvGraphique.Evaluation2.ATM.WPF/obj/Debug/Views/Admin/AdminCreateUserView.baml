   M S B A M L   `   `   `  ����[  WEnvGraphique.Evaluation2.ATM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:EnvGraphique.Evaluation2.ATM.WPF.Views&EnvGraphique.Evaluation2.ATM.WPF.Views  5      K GWPFCustomControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:WPFCustomControl;assembly=WPFCustomControlWPFCustomControl 6Q   @    :EnvGraphique.Evaluation2.ATM.WPF.Views.AdminCreateUserView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:EnvGraphique.Evaluation2.ATM.WPF.Views     5      UWPFCustomControl8clr-namespace:WPFCustomControl;assembly=WPFCustomControl     6Q   -   5        .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   !  WPFCustomControl.InputField  -   5          Name$ lastName��5   &   $��0��68   $��0��6E   $��10q�6U      	FieldName$	 Nom��6�      FieldFontSize$ 20Q�6�   $��SemiBold"�6�      BrushHeaderSecondary   FieldForegroundColor# [  6�      FieldBackgroundColor
 �����   FieldNameForegroundColor# [  6A     Input 6a   �� *
LastName+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6A    5   
   -   5        $ 	firstName��5   &   $��0��69   $��1��6F   $��10q�6V   $ Prénom��6�   $ 20Q�6�   $��SemiBold"�6�   # [  6�   
 �����# [  6F   6b   �� *	FirstName+$	 TwoWay=�$
 PropertyChanged=�6F    5   
   -   5        $ phone��5   &   $��1��65   $��0��6B   $��10q�6R   $ Téléphone��6�   $ 20Q�6�   $��SemiBold"�6�   # [  6�   
 �����# [  6A   6^   �� *Phone+$	 TwoWay=�$
 PropertyChanged=�6A    5   
   -   5        $ email��5   &   $��1��65   $��1��6B   $��10q�6R   $ Email��6�   $ 20Q�6�   $��SemiBold"�6�   # [  6�   
 �����   TooltipForegroundColor# [  6=  # [  6|     Tooltip$ (Facultatif)��6�     TooltipAlwaysVisible .  6^   �� *Email+$	 TwoWay=�$
 PropertyChanged=�6�    5   
   -   5        $ username��5   &   $��2��68   $��0��6E   $��10q�6U   $ Nom d'utilisateur��6�   $ 20Q�6�   $��SemiBold"�6�   # [  6�   
 �����# [  6O   6a   �� *
Username+$	 TwoWay=�$
 PropertyChanged=�6O    5   
   -   5        $	 nip��5   &   $��2��63   $��1��6@   $��10q�6P   $	 NIP��6�   $ 20Q�6�   $��SemiBold"�6�   # [  6�   
 �����# [  67   6\   �� *Nip+$	 TwoWay=�$
 PropertyChanged=�67  �� 5   
   $��3��6   $��0��6!   $��Type d'utilisateur:��61   $��22(�6L   $��10 20q�6Z   $��Right=�6i   #��[  6�   $��SemiBold"�6�   �� 5   
   -   5         ��Name$ comboBoxUserTypes��5      $��3��6X   $��1��6e   $��20(�6u   $
��Bold"�6�   $��10 20q�6�    �� SelectedIndex$ 0��6�    �� SelectedItem 6.   �� *SelectedUserType+6�   �� 5   
   $��4��6<   $��1��6I     SubmitButton#��[ 6Y   $��Enregistrer��6   $��10 20 10 10q�6�   ��6   �� *AdminCreateUserCommand+6�   5       5!      