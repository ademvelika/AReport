﻿#pragma checksum "..\..\..\Dialog\DocumentPreview.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "073E88E193B3568830359FC5E2C69A1EDDB38402773755E48B93A5B1845F1DB9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MYDIPLOMA.Dialog;
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


namespace MYDIPLOMA.Dialog {
    
    
    /// <summary>
    /// DocumentPreview
    /// </summary>
    public partial class DocumentPreview : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Dialog\DocumentPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PDFExport;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Dialog\DocumentPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExcelExport;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Dialog\DocumentPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer Scroller;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Dialog\DocumentPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl Container;
        
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
            System.Uri resourceLocater = new System.Uri("/MYDIPLOMA;component/dialog/documentpreview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Dialog\DocumentPreview.xaml"
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
            
            #line 8 "..\..\..\Dialog\DocumentPreview.xaml"
            ((MYDIPLOMA.Dialog.DocumentPreview)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 15 "..\..\..\Dialog\DocumentPreview.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Print_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PDFExport = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Dialog\DocumentPreview.xaml"
            this.PDFExport.Click += new System.Windows.RoutedEventHandler(this.PDFExport_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ExcelExport = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Dialog\DocumentPreview.xaml"
            this.ExcelExport.Click += new System.Windows.RoutedEventHandler(this.ExcelExport_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 24 "..\..\..\Dialog\DocumentPreview.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Scroller = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 7:
            this.Container = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

