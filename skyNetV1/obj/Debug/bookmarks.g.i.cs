﻿#pragma checksum "E:\Programming Languages\Windows phone workshop material\projects\final copy skynet\skyNetV1\bookmarks.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F4E69D96B0A2F29230731234F26CBE7B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
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
    
    
    public partial class bookmarks : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.PivotItem exitsing_bookmarks;
        
        internal System.Windows.Controls.StackPanel bookmark_stackpanel;
        
        internal Microsoft.Phone.Controls.PivotItem add_bookmarks;
        
        internal System.Windows.Controls.TextBox bookmark_name1;
        
        internal System.Windows.Controls.Button only_add1;
        
        internal System.Windows.Controls.Button add_redirect1;
        
        internal System.Windows.Controls.TextBox bookmark_url1;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_button1;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_button2;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_button3;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/skyNetV1;component/bookmarks.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.exitsing_bookmarks = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("exitsing_bookmarks")));
            this.bookmark_stackpanel = ((System.Windows.Controls.StackPanel)(this.FindName("bookmark_stackpanel")));
            this.add_bookmarks = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("add_bookmarks")));
            this.bookmark_name1 = ((System.Windows.Controls.TextBox)(this.FindName("bookmark_name1")));
            this.only_add1 = ((System.Windows.Controls.Button)(this.FindName("only_add1")));
            this.add_redirect1 = ((System.Windows.Controls.Button)(this.FindName("add_redirect1")));
            this.bookmark_url1 = ((System.Windows.Controls.TextBox)(this.FindName("bookmark_url1")));
            this.appbar_button1 = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_button1")));
            this.appbar_button2 = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_button2")));
            this.appbar_button3 = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_button3")));
        }
    }
}

