﻿#pragma checksum "..\..\..\View\SettingsEditSkillsView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8E399181622D44AB9B2295D8A44B65F6A7369B5FDE525A6CA5E394A9991BC9B8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BITServices.View;
using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
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


namespace BITServices.View {
    
    
    /// <summary>
    /// SettingsEditSkillsView
    /// </summary>
    public partial class SettingsEditSkillsView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\View\SettingsEditSkillsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spTopBar;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\View\SettingsEditSkillsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spTopbar;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View\SettingsEditSkillsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimizeWindow;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\View\SettingsEditSkillsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCloseWindow;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\View\SettingsEditSkillsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvSkills;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\View\SettingsEditSkillsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemove;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\View\SettingsEditSkillsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDone;
        
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
            System.Uri resourceLocater = new System.Uri("/BITServices;component/view/settingseditskillsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\SettingsEditSkillsView.xaml"
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
            this.spTopBar = ((System.Windows.Controls.StackPanel)(target));
            
            #line 19 "..\..\..\View\SettingsEditSkillsView.xaml"
            this.spTopBar.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.spTopBar_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.spTopbar = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.btnMinimizeWindow = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\View\SettingsEditSkillsView.xaml"
            this.btnMinimizeWindow.Click += new System.Windows.RoutedEventHandler(this.btnMinimizeWindow_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCloseWindow = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\View\SettingsEditSkillsView.xaml"
            this.btnCloseWindow.Click += new System.Windows.RoutedEventHandler(this.btnCloseWindow_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lvSkills = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.btnRemove = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\View\SettingsEditSkillsView.xaml"
            this.btnRemove.Click += new System.Windows.RoutedEventHandler(this.btnRemove_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnDone = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\View\SettingsEditSkillsView.xaml"
            this.btnDone.Click += new System.Windows.RoutedEventHandler(this.btnDone_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

