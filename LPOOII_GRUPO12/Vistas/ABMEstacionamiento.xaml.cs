﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ABMEstacionamiento.xaml
    /// </summary>
    public partial class ABMEstacionamiento : Window
    {
        public ABMEstacionamiento()
        {
            InitializeComponent();
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
        }
    }
}
