// Updated by XamlIntelliSenseFileGenerator 10.04.2020 5:36:26
#pragma checksum "..\..\Authorizations.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D1E9EA279E58D74D065AAE2B219D40B424F2473E14CE6B9463E63D0F7ED66CE3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AistWPF;
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
using System.Windows.Interactivity;
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


namespace AistWPF
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class Authorizations : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 25 "..\..\Authorizations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblForgot;

#line default
#line hidden


#line 29 "..\..\Authorizations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblLogin;

#line default
#line hidden


#line 30 "..\..\Authorizations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbLogin;

#line default
#line hidden


#line 32 "..\..\Authorizations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPassword;

#line default
#line hidden


#line 33 "..\..\Authorizations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPassword;

#line default
#line hidden


#line 36 "..\..\Authorizations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btEnter;

#line default
#line hidden


#line 37 "..\..\Authorizations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancel;

#line default
#line hidden


#line 41 "..\..\Authorizations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btReg;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AistWPF;component/authorizations.xaml", System.UriKind.Relative);

#line 1 "..\..\Authorizations.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.Authorizations = ((AistWPF.MainWindow)(target));
                    return;
                case 2:
                    this.lblForgot = ((System.Windows.Controls.Label)(target));
                    return;
                case 3:
                    this.lblLogin = ((System.Windows.Controls.Label)(target));
                    return;
                case 4:
                    this.tbLogin = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.lblPassword = ((System.Windows.Controls.Label)(target));
                    return;
                case 6:
                    this.tbPassword = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.btEnter = ((System.Windows.Controls.Button)(target));

#line 36 "..\..\Authorizations.xaml"
                    this.btEnter.Click += new System.Windows.RoutedEventHandler(this.btEnter_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.btCancel = ((System.Windows.Controls.Button)(target));
                    return;
                case 9:
                    this.btReg = ((System.Windows.Controls.Button)(target));

#line 41 "..\..\Authorizations.xaml"
                    this.btReg.Click += new System.Windows.RoutedEventHandler(this.btReg_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

