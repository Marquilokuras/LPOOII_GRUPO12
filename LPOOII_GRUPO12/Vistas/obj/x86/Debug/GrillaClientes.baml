   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   
 Vistas   Vistas.GrillaClientes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <svc,clr-namespace:ClasesBase;assembly=ClasesBase     5   	     � Title$  Grilla de Clientes��5   	   $	��310��6$   $	��450��61    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$. (/Vistas;component/Images/logoParking.png��6.      MyWindowDefault#��[  5   	    � 	Resources 5        list_cliente S� 
ObjectType    ClasesBase.TrabajarCliente S� 
MethodName��%L   &	       S� 5	   
   "  5      $ TraerClientes��5      5      5      .��5      � .+�5   
   �� -   5        $��Clientes��5      $	��249��6#   $	��Top=�6m   $��
10,10,10,0q�6�   ��60   ��  �� Source# [  �� View 5      �� 5      .P�5      ��  �� Width$ 80��6%   $	��DNI��60   	 �� DisplayMemberBinding	 6=   �� 
 �� Path$
 cli_ClienteDNI��� 5      $	 150��6%   $��Apellido��61   	 6C   �� $
 cli_Apellido��� 5      $ 80��6%   $��Nombre��60   	 6@   �� $
 
cli_Nombre��� 5      $ 80��6%   $��Teleono��60   	 6A   �� $
 cli_Telefono�5      5      5      5      