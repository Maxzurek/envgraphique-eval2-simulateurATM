   M S B A M L   `   `   `  ����[  WEnvGraphique.Evaluation2.ATM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:EnvGraphique.Evaluation2.ATM.WPF.Controls)EnvGraphique.Evaluation2.ATM.WPF.Controls  5      �Hclr-namespace:EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars:EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars  5      B    <EnvGraphique.Evaluation2.ATM.WPF.Controls.AdminNavigationBar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:EnvGraphique.Evaluation2.ATM.WPF.Controls     5      ]adminnavHclr-namespace:EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars     5      .��5
      �   � 	Resources  5   
    �� 
TargetType   	NavButton �� BasedOn��%0   '	�       7   �� 5      " 	�6   8   6-   5       � RowDefinitions 5   
   �� 5      $
��auto �6   .+�5   
   � $��0��6     BrushHeaderPrimary#��[ 6    �� EdgeMode$ Aliased=�6M    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5      	� $��0��6   $��0��6'   $��Gestion��67    d� 	IsChecked$
 TrueY�6I   K   EEnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars.EAdminView   Home#��Z 6�   ��6Z   �� *ChangeAdminViewCommand+6�   	� 5      $��0��6   $��1��6'   $��Créer utilisateur��67      
CreateUser#��Z 6~   ��6S   �� *ChangeAdminViewCommand+6~   	� 5      $��0��6   $��2��6'   $��Créer compte��67   	   CreateAccount#��Z	 6y   ��6N   �� *ChangeAdminViewCommand+6y   	� 5      $��0��6   $��3��6'   $��Transactions��67   
   Transactions#��Z
 6y   ��6N   �� *ChangeAdminViewCommand+6y   	� 5      $��0��6   $��4��6'   $��Prélèvements��67      Withdraw#��Z 6y   ��6N   �� *ChangeAdminViewCommand+6y   �� 5       $��0��6   $��5��6"   $��Déconnection��62   $��Right=�6k     LogoutButton#��[ 6�   ��6I   �� *LogoutCommand+6�   5!      5"      5#      