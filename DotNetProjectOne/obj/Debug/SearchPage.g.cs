﻿#pragma checksum "..\..\SearchPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4CA9B2C6E3D720D69A922ED88AF6EEC5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DotNetProjectOne;
using MahApps.Metro.Controls;
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


namespace DotNetProjectOne {
    
    
    /// <summary>
    /// SearchPage
    /// </summary>
    public partial class SearchPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DotNetProjectOne.SearchPage searchPage;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DotNetProjectOne.OptionsMinimizeDisposeControl disposeControl;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SearchCombo;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView MyMoviesList;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\SearchPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TopMoviesList;
        
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
            System.Uri resourceLocater = new System.Uri("/DotNetProjectOne;component/searchpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SearchPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.searchPage = ((DotNetProjectOne.SearchPage)(target));
            
            #line 13 "..\..\SearchPage.xaml"
            this.searchPage.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.searchPage_MouseDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\SearchPage.xaml"
            this.searchPage.KeyDown += new System.Windows.Input.KeyEventHandler(this.SearchWindow_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.disposeControl = ((DotNetProjectOne.OptionsMinimizeDisposeControl)(target));
            return;
            case 3:
            this.Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\SearchPage.xaml"
            this.Search.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SearchCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.searchButton = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\SearchPage.xaml"
            this.searchButton.Click += new System.Windows.RoutedEventHandler(this.searchButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MyMoviesList = ((System.Windows.Controls.ListView)(target));
            
            #line 62 "..\..\SearchPage.xaml"
            this.MyMoviesList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MyMovieList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TopMoviesList = ((System.Windows.Controls.ListView)(target));
            
            #line 102 "..\..\SearchPage.xaml"
            this.TopMoviesList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TopMovieList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

