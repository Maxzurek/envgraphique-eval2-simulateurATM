﻿#pragma checksum "..\..\..\Controls\ClientNavigationBar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "001478F04E5B88A4F1E8CB14EA0258EE87384672147277779D5A3BFE60C985E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EnvGraphique.Evaluation2.ATM.WPF.Controls;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars;
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


namespace EnvGraphique.Evaluation2.ATM.WPF.Controls {
    
    
    /// <summary>
    /// ClientNavigationBar
    /// </summary>
    public partial class ClientNavigationBar : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Controls\ClientNavigationBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton buttonHome;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Controls\ClientNavigationBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton buttonWithdraw;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Controls\ClientNavigationBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton buttonDeposit;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Controls\ClientNavigationBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton buttonTransfer;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Controls\ClientNavigationBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton buttonPay;
        
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
            System.Uri resourceLocater = new System.Uri("/EnvGraphique.Evaluation2.ATM.WPF;component/controls/clientnavigationbar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\ClientNavigationBar.xaml"
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
            this.buttonHome = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 2:
            this.buttonWithdraw = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.buttonDeposit = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.buttonTransfer = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.buttonPay = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

