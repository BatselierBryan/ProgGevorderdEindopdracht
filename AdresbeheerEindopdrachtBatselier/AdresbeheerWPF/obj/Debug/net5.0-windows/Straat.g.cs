﻿#pragma checksum "..\..\..\Straat.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "808D8F0A0B91681CB6C7F09F2195DEC9F9E04E8D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AdresbeheerWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace AdresbeheerWPF {
    
    
    /// <summary>
    /// Straat
    /// </summary>
    public partial class Straat : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Straat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTerug;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Straat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtId;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Straat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStraatnaam;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Straat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTerug1;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Straat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVoegStraatToe;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Straat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStraatCheckAanwezigheid;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Straat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVerwijderStraat;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Straat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdateStraat;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Straat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNiscode;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AdresbeheerWPF;component/straat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Straat.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnTerug = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Straat.xaml"
            this.btnTerug.Click += new System.Windows.RoutedEventHandler(this.Terug_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtStraatnaam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnTerug1 = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Straat.xaml"
            this.btnTerug1.Click += new System.Windows.RoutedEventHandler(this.Terug_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnVoegStraatToe = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Straat.xaml"
            this.btnVoegStraatToe.Click += new System.Windows.RoutedEventHandler(this.btnVoegStraatToe_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnStraatCheckAanwezigheid = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Straat.xaml"
            this.btnStraatCheckAanwezigheid.Click += new System.Windows.RoutedEventHandler(this.btnStraatCheckAanwezigheid_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnVerwijderStraat = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\Straat.xaml"
            this.btnVerwijderStraat.Click += new System.Windows.RoutedEventHandler(this.btnVerwijderStraat_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnUpdateStraat = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\Straat.xaml"
            this.btnUpdateStraat.Click += new System.Windows.RoutedEventHandler(this.btnUpdateStraat_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtNiscode = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

