﻿#pragma checksum "..\..\AdminForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "60CC2FBD1783BD5F5CA1B05BFD3166E439458576F18B4D545806E7FF947A48D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CRM_System_Development_Plan;
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


namespace CRM_System_Development_Plan {
    
    
    /// <summary>
    /// AdminForm
    /// </summary>
    public partial class AdminForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\AdminForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MembershipTypeFilter;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AdminForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView MembersListView;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AdminForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EventSearchBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AdminForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EventSearchWatermark;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\AdminForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView EventsListView;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\AdminForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MemberSearchBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\AdminForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MemberSearchWatermark;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\AdminForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView EngagementsListView;
        
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
            System.Uri resourceLocater = new System.Uri("/CRM System Development Plan;component/adminform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminForm.xaml"
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
            this.MembershipTypeFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\AdminForm.xaml"
            this.MembershipTypeFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MembershipTypeFilter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MembersListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.EventSearchBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.EventSearchWatermark = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 40 "..\..\AdminForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchEvent_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EventsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.MemberSearchBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.MemberSearchWatermark = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            
            #line 64 "..\..\AdminForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchMember_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.EngagementsListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
