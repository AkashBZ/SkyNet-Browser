﻿#pragma checksum "E:\Programming Languages\Windows phone workshop material\projects\final copy skynet\skyNetV1\history_page.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0BD808E4E605399E3351D9B224B166F7"
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
    
    
    public partial class history_page : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.StackPanel mystackpanel;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton clear_history;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton pre_history;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton lat_history;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/skyNetV1;component/history_page.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.mystackpanel = ((System.Windows.Controls.StackPanel)(this.FindName("mystackpanel")));
            this.clear_history = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("clear_history")));
            this.pre_history = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("pre_history")));
            this.lat_history = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("lat_history")));
        }
    }
}

