﻿#pragma checksum "..\..\..\..\View\CreateProduct.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3E97C477FF6C215268A0C87CF9D47FC2C93A06A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Reolmarkedet_System.View;
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


namespace Reolmarkedet_System.View {
    
    
    /// <summary>
    /// CreateProduct
    /// </summary>
    public partial class CreateProduct : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxTenantFullname;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductDescription;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductPrice;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductQuantity;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxProductGroup;
        
        #line default
        #line hidden
        
        
        #line 295 "..\..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxRack;
        
        #line default
        #line hidden
        
        
        #line 319 "..\..\..\..\View\CreateProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateProduct;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Reolmarkedet_System;V1.0.0.0;component/view/createproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\CreateProduct.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\..\..\View\CreateProduct.xaml"
            ((Reolmarkedet_System.View.CreateProduct)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ComboBoxTenantFullname = ((System.Windows.Controls.ComboBox)(target));
            
            #line 57 "..\..\..\..\View\CreateProduct.xaml"
            this.ComboBoxTenantFullname.Loaded += new System.Windows.RoutedEventHandler(this.cmboShowTenantFullname);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\..\View\CreateProduct.xaml"
            this.ComboBoxTenantFullname.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxTenantFullname_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\..\View\CreateProduct.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\..\View\CreateProduct.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtProductDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtProductPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtProductQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ComboBoxProductGroup = ((System.Windows.Controls.ComboBox)(target));
            
            #line 268 "..\..\..\..\View\CreateProduct.xaml"
            this.ComboBoxProductGroup.Loaded += new System.Windows.RoutedEventHandler(this.ComboBoxProdutGroup_Loaded);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ComboBoxRack = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.btnCreateProduct = ((System.Windows.Controls.Button)(target));
            
            #line 329 "..\..\..\..\View\CreateProduct.xaml"
            this.btnCreateProduct.Click += new System.Windows.RoutedEventHandler(this.btnCreateProduct_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

