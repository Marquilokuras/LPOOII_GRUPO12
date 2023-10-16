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
    /// Interaction logic for EstadoSector.xaml
    /// </summary>
    public partial class EstadoSector : Window
    {


        public EstadoSector()
        {
            InitializeComponent();

            int defaultIndex = 0;

            if (defaultIndex >= 0 && defaultIndex < comboBox.Items.Count)
                comboBox.SelectedIndex = defaultIndex;
        }
    }
}
