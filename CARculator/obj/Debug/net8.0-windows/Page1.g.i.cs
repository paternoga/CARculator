﻿#pragma checksum "..\..\..\Page1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "032E0300646E9985352D09F047AE2A01994538DB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace CARculator {
    
    
    /// <summary>
    /// Page1
    /// </summary>
    public partial class Page1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BrandComboBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ModelComboBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GenerationComboBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FuelTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EngineComboBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TransmissionComboBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductionYearTextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ResultsListBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OtomotoUrlTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CARculator;component/page1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Page1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BrandComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\Page1.xaml"
            this.BrandComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnBrandSelected);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ModelComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\..\Page1.xaml"
            this.ModelComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnModelSelected);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GenerationComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 31 "..\..\..\Page1.xaml"
            this.GenerationComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnGenerationSelected);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FuelTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\..\Page1.xaml"
            this.FuelTypeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnFuelTypeSelected);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EngineComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 41 "..\..\..\Page1.xaml"
            this.EngineComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnEngineSelected);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TransmissionComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 46 "..\..\..\Page1.xaml"
            this.TransmissionComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnTransmissionSelected);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ProductionYearTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 54 "..\..\..\Page1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnApplyFiltersClicked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ResultsListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 10:
            this.OtomotoUrlTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            
            #line 64 "..\..\..\Page1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnCopyLinkClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

