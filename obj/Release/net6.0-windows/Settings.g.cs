﻿#pragma checksum "..\..\..\Settings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DD92FC2F641BA939541B8D8ED0FC70E2DA7C5F30"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using CosmosLauncherApp;
using ModernWpf;
using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;
using ModernWpf.DesignTime;
using ModernWpf.Markup;
using ModernWpf.Media.Animation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace CosmosLauncherApp {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Username_Textbox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save_Username_btn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Argument_Textbox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save_Argument;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Logs_Checkbox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save_Logs_btn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CosmosLauncherApp;component/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Settings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Username_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Save_Username_btn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Settings.xaml"
            this.Save_Username_btn.Click += new System.Windows.RoutedEventHandler(this.Save_Username_btn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Argument_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Save_Argument = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Settings.xaml"
            this.Save_Argument.Click += new System.Windows.RoutedEventHandler(this.Save_Argument_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Logs_Checkbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.Save_Logs_btn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Settings.xaml"
            this.Save_Logs_btn.Click += new System.Windows.RoutedEventHandler(this.Save_Logs);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

