   M S B A M L   `   `   `  ����
  Vistas    Vistas.VistaPreviaVentas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Icon$. (/Vistas;component/Images/logoParking.png��6.    � Title$ VistaPreviaVentas��5   	   $	��400��6#   $
��1350��60      MyWindowDefault#��[  6T   .��5      � .+�5   
   �� -   5        $��stackPanel1��5   0   $
��Left=�6   $	��Top=�6C   $	��337��6[   $
��1304��6h   $��	12,12,0,0q�6u   
�������.+�5      -� $	��280��6!   $
��1285��6.    -� IsTwoPageViewEnabled . .��5	      /� -   5         �Name$ 	DocVentas��5	       /� ColumnWidth$
 1284��60   .T�5
      J� $
��Bold"�6     �� Margin$ 0q�62    �� TextAlignment$ Center=�6=   .*�6T   Listado de Ventas6g   �� 5      .r�5      &   System.Windows.Controls.DataGrid  -   5        $��dgVentas��5   #      AutoGenerateColumns .  $��Center=�6O   $	��Top=�6l   	   
IsReadOnly	 . 
   CanUserResizeRows
 .     CanUserDeleteRows .     CanUserAddRows .  $��1��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 65      Header$
 Zona��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *zona_Descripcion+  5   "   $ 60 65   $ Sector��6@    6P   �� *sec_Descripcion+  5   "   $ 70 65   $ # Ticket��6@    6R   �� *tkt_TicketNro+  5   "   $	 200 65   $ Fecha y Hora de Entrada��6A    6b   �� *tkt_FechaHoraEnt+  5   "   $	 200 65   $ Fecha y Hora de Salida��6A    6a   �� *tkt_FechaHoraSal+  5   "   $	 190 65   $ Cliente��6A    6R   �� *	Cliente+  5   "   $	 140 65   $ Tipo de Vehiculo��6A    6[   �� *TipoVehiculo+  5   "   $ 70 65   $ Patente��6@    6Q   �� *tkt_Patente+  5   "   $ 80 65   $ Duracion��6@    6R   �� *tkt_Duracion+  5   "   $ 60 65   $ Tarifa��6@    6P   �� *	tv_Tarifa+  5   "   $	 110 65   $ Importe Total��6A    6X   �� *	tkt_Total+5      5      J� 5      $ Center=�6    .*�67   .*�5      �� $�Total de Ventas: $��6   $
��Bold"�68    �� 5      -   5        $ totalDeVentas��5      $
��Bold"�63   5      5       5!      �� 5"      -   5        $��btnImprimir��5"   (   $��Imprimir��6   $
��0,20q�6;   $	��100��6c     ButtonStyle#��[ 6o   5#      5$      5%      