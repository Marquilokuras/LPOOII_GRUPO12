   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   
 Vistas   Vistas.GrillaVehiculos   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <svc,clr-namespace:ClasesBase;assembly=ClasesBase     5   	   -   5          � Title$  Grilla de Vehiculos��5   	   $	��367��6%   $	��527��62    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$. (/Vistas;component/Images/logoParking.png��6.      MyWindowDefault#��[  5   	    � 	Resources 5	        list_vehiculo S� 
ObjectType&    ClasesBase.TrabajarTiposVehiculo S� 
MethodName��%Q   &	       S� 5
   
   "  5      $ TraerTiposVehiculo��5      5      5      .��5      � .+�5   
   �� -   5        $��	Vehiculos��5      $	��306��6$   $	��Top=�6o   $��
10,10,10,0q�6�   ��61   ��  �� Source# [  �� View 5      �� 5      .P�5      ��  �� Width$ 80��6%   $��Codigo��60   	 �� DisplayMemberBinding	 6@   �� 
 �� Path$
 tv_TVCodigo��� 5      $	 150��6%   $��Descripcion��61   	 6F   �� $
 tv_Descripcion��� 5      $ 80��6%   $��Tarifa��60   	 6@   �� $
 	tv_Tarifa��� 5      $	 150��6%   $��Imagen��61    �� CellTemplate 5      �� 5      .R�5   "   �� $��50��6J   $��50��6U   ��6(   �� $
 	tv_Imagen�6U   5      5      5       5"      5#      5$      