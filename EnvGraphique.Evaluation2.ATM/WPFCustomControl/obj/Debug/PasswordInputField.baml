   M S B A M L   `   `   `  ����K  GWPFCustomControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPFCustomControlWPFCustomControl  5      )    #WPFCustomControl.PasswordInputField   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:WPFCustomControl     5      -   5        .��5
      � -   5          �Name$
  grid��5
       � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6    � RowDefinitions 5   
   �� 5      ��6   ��  �� ElementName$ field�� �� Path$ ActualHeight��� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$ fieldNameLabel��5      $��	FieldName��6(    K� ZIndex$
 1000��5      $��0q�6$   $��5,0,0,0q�60   $��Bottom=�6a   $��16(�6�   ��5      �� *1/(local:PasswordInputField.FieldNameRowPosition)+ �� RelativeSource �� *FindAncestor+ �� AncestorType" >�5   �   G� 5   
   -   5        	 G�Name$	 field��5      $��1��6%   $��Bottom=�5      $��16(�67   6E   �� 5   
   -   5        $ tooltipLabel��5      $��Tooltip��6&   $��2��68   $��0q�6E   $��14(�6Q   5      5      