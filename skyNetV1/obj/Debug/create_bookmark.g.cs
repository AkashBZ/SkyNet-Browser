﻿#pragma checksum "E:\Programming Languages\Windows phone workshop material\projects\final copy skynet\skyNetV1\create_bookmark.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B41749005D21172C263BAC0E9D95BD13"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace skyNetV1 {
    
    
    public partial class create_bookmark : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox book_name;
        
        internal System.Windows.Controls.TextBox book_url;
        
        internal System.Windows.Controls.Button add_book;
        
        internal System.Windows.Controls.Button cancelButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/skyNetV1;component/create_bookmark.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.book_name = ((System.Windows.Controls.TextBox)(this.FindName("book_name")));
            this.book_url = ((System.Windows.Controls.TextBox)(this.FindName("book_url")));
            this.add_book = ((System.Windows.Controls.Button)(this.FindName("add_book")));
            this.cancelButton = ((System.Windows.Controls.Button)(this.FindName("cancelButton")));
        }
    }
}

