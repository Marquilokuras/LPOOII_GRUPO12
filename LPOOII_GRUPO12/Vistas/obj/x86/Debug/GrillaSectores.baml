   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   
 Vistas   Vistas.GrillaSectores   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <svc,clr-namespace:ClasesBase;assembly=ClasesBase     5   	     � Title$  Grilla de Sectores��5   	   $	��367��5   	   $	��555��6    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$. (/Vistas;component/Images/logoParking.png��6.      MyWindowDefault#��[  5   	    � 	Resources 5
        list_sectores S� 
ObjectType   ClasesBase.TrabajarSector S� 
MethodName��%L   &	       S� 5   
   "  5      $ TraerSectores��5      5      5      .��5      � .+�5   
   �� -   5        $��Sectores��5      $
��Auto��6#   $	��Top=�6o   $��10q�6�   ��61   ��  �� Source# [  �� View 5      �� 5      .P�5      ��  �� Width$ 80��6%   $��Codigo Sector��60   	 �� DisplayMemberBinding	 6G   �� 
 �� Path$
 sec_SectorCodigo��� 5      $	 150��6%   $��Codigo Zona��61   	 6F   �� $
 sec_ZonaCodigo��� 5      $ 80��6%   $��Identificador��60   	 6G   �� $
 sec_Identificador��� 5      $ 80��6%   $��Descripcion��60   	 6E   �� $
 sec_Descripcion��� 5      $ 80��6%   $��
Habilitado��60   	 6D   �� $
 sec_Habilitado�5      5      5      5       