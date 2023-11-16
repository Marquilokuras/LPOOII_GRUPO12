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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Zonas.xaml
    /// </summary>
    public partial class Zonas : Window
    {
        public Zonas()
        {
            InitializeComponent();
        }

        private void btnZ1_Click(object sender, RoutedEventArgs e)
        {
            Sectores sector = new Sectores(1);
            sector.Show();
        }

        private void btnZ2_Click(object sender, RoutedEventArgs e)
        {
            Sectores sector = new Sectores(2);
            sector.Show();
        }

        private void btnZ3_Click(object sender, RoutedEventArgs e)
        {
            Sectores sector = new Sectores(3);
            sector.Show();
        }
    }
}