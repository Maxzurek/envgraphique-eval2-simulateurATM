   M S B A M L   `   `   `  ����[  WEnvGraphique.Evaluation2.ATM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:EnvGraphique.Evaluation2.ATM.WPF.Views&EnvGraphique.Evaluation2.ATM.WPF.Views  5      K GWPFCustomControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:WPFCustomControl;assembly=WPFCustomControlWPFCustomControl 5      6    0EnvGraphique.Evaluation2.ATM.WPF.Views.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:EnvGraphique.Evaluation2.ATM.WPF.Views     5      UWPFCustomControl8clr-namespace:WPFCustomControl;assembly=WPFCustomControl     5      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Portail de connection��6!   $��Center=�6>   ���	#FF28436F$
��Bold"�6r   $��36(�6�   $��	0 20 0 20q�6�   !  WPFCustomControl.InputField  5   
   -   5          Name$ inputFieldUser��5   &   $��1��6�   $	��Top=�6�   $��200 0 200 0q�6�      	FieldName$ Utilisateur��6�      FieldFontSize$ 22Q�6�   $
��Bold"�6�      FieldForegroundColor �	#FF28436F   FieldBackgroundColor
 �����   FieldNameForegroundColor �	#FF28436F   Input 6>   �� *
Username+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6@  )  #WPFCustomControl.PasswordInputField  5   
   -   5        
  Name$
 inputFieldPassword��5   {   $��2��6�   $	��Top=�6�   $��200 0 200 0q�6�      	FieldName$ Mot de passe��6�      FieldFontSize$ 22Q�6�   $
��Bold"�6�      FieldBackgroundColor
 �����   FieldNameForegroundColor �	#FF28436F   Input 6.   �� *
Password+$ TwoWay=�$	 PropertyChanged=�6,  �� 5   
   -   5         ��Name$ buttonConnect��5      $��3��6(   $��
Connection��65      SubmitButton#��[  6J   $��200,10,200,10q�6p   ��5      �� *LoginCommand+�� 5   
   -   5         ��Name$ borderConnectionTooltip��5      $��4��62    �� CornerRadius$ 10��6?   ���	#FFF91A1A$��2q�6i   $��Center=�6}   $��150 10q�6�   y�6�   �� *LoginTooltipVisibility+._�5      �� -   5         ��Name$ textblockLoginTooltip��5      $
��Wrap=�67   ���	#7FEC9595 �� TextAlignment$ Center=�6�    �� Padding$ 10q�6�   $��Normal"�6�   ��6K   �� *LoginTooltip+6�   5      5      5      