﻿#pragma checksum "..\..\..\MenuPrincipalWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D9EB074C3C3AD9C0773DC43B5ED0CF6239EA9E0E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ClasesBase;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Vistas {
    
    
    /// <summary>
    /// MenuPrincipalWindow
    /// </summary>
    public partial class MenuPrincipalWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\MenuPrincipalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuSectores;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\MenuPrincipalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuTiposVehiculo;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\MenuPrincipalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuGestionClientes;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\MenuPrincipalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuGestionEstacionamiento;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\MenuPrincipalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuSalir;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Vistas;component/menuprincipalwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MenuPrincipalWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\..\MenuPrincipalWindow.xaml"
            ((Vistas.MenuPrincipalWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.menuSectores = ((System.Windows.Controls.MenuItem)(target));
            
            #line 8 "..\..\..\MenuPrincipalWindow.xaml"
            this.menuSectores.Click += new System.Windows.RoutedEventHandler(this.menuSectores_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.menuTiposVehiculo = ((System.Windows.Controls.MenuItem)(target));
            
            #line 9 "..\..\..\MenuPrincipalWindow.xaml"
            this.menuTiposVehiculo.Click += new System.Windows.RoutedEventHandler(this.menuTiposVehiculo_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menuGestionClientes = ((System.Windows.Controls.MenuItem)(target));
            
            #line 10 "..\..\..\MenuPrincipalWindow.xaml"
            this.menuGestionClientes.Click += new System.Windows.RoutedEventHandler(this.menuGestionClientes_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.menuGestionEstacionamiento = ((System.Windows.Controls.MenuItem)(target));
            
            #line 11 "..\..\..\MenuPrincipalWindow.xaml"
            this.menuGestionEstacionamiento.Click += new System.Windows.RoutedEventHandler(this.menuGestionEstacionamiento_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.menuSalir = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\..\MenuPrincipalWindow.xaml"
            this.menuSalir.Click += new System.Windows.RoutedEventHandler(this.menuSalir_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
