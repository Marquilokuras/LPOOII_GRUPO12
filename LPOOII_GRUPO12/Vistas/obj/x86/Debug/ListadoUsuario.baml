   M S B A M L   `   `   `  ����
  Vistas    Vistas.ListadoUsuario   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Listado de Usuario��5   	   $	��390��6$   $	��487��61   $	��390��6=   $	��487��6M    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$. (/Vistas;component/Images/logoParking.png��6.      MyWindowDefault#��[  5   	   .��5      � $	��362��6   $	��465��6   .+�5   
   �� -   5        $��	txtFilter��5      $	��211��6#   $
��Left=�6/   $	��Top=�6J   $��	98,12,0,0q�6b   $��26��6u   �� 5	   
   -   5        $��Buscar��5	      $��61��6"   $��26��6-   $	��Top=�69   $��Right=�6Q   $��	0,12,89,0q�6m     ButtonStyle#��[ 6�   $��12(�6�   &   System.Windows.Controls.DataGrid  5
   
   -   5        $��userGrid��5
   W      AutoGenerateColumns .  $	��261��6/   $
��Left=�6<   $	��Top=�6g   $	��278��6   $��	98,44,0,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
Usr_Nombre+  5      $ Nombre de Usuario��6%    6@   �� *Usr_UserName+5      �� 5   
   -   5        $��Vista Previa��5      #��[ 6E   $��12(�6j   $��Center=�6x   $��Center=�6�   $	��278��6�   $��98,310,89,22q�6�   5      5      