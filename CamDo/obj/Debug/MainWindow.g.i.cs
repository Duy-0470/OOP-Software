// Updated by XamlIntelliSenseFileGenerator 12/2/2022 11:35:09 PM
#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B64C577170B658AD02F0523E5887362AE4696D2FC3B1591D0AA9ABA5080215D8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CamDo;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace CamDo
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 103 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid BG;

#line default
#line hidden


#line 115 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid nav_pnl;

#line default
#line hidden


#line 120 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel st_pnl;

#line default
#line hidden


#line 151 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Tg_Btn;

#line default
#line hidden


#line 173 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.Storyboard ShowStackPanel;

#line default
#line hidden


#line 187 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.Storyboard HideStackPanel;

#line default
#line hidden


#line 206 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LV;

#line default
#line hidden


#line 232 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip tt_home;

#line default
#line hidden


#line 260 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip tt_customer;

#line default
#line hidden


#line 288 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip tt_pawn;

#line default
#line hidden


#line 316 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip tt_search;

#line default
#line hidden


#line 344 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip tt_remind;

#line default
#line hidden


#line 401 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip tt_manage;

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
            System.Uri resourceLocater = new System.Uri("/CamDo;component/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\MainWindow.xaml"
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
                    this.BG = ((System.Windows.Controls.Grid)(target));

#line 103 "..\..\MainWindow.xaml"
                    this.BG.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_PreviewMouseLeftButtonDown);

#line default
#line hidden
                    return;
                case 2:
                    this.nav_pnl = ((System.Windows.Controls.Grid)(target));
                    return;
                case 3:
                    this.st_pnl = ((System.Windows.Controls.StackPanel)(target));
                    return;
                case 4:
                    this.Tg_Btn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
                    return;
                case 5:
                    this.ShowStackPanel = ((System.Windows.Media.Animation.Storyboard)(target));
                    return;
                case 6:
                    this.HideStackPanel = ((System.Windows.Media.Animation.Storyboard)(target));
                    return;
                case 7:
                    this.LV = ((System.Windows.Controls.ListView)(target));
                    return;
                case 8:

#line 215 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.ListViewItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListViewItem_MouseEnter);

#line default
#line hidden
                    return;
                case 9:
                    this.tt_home = ((System.Windows.Controls.ToolTip)(target));
                    return;
                case 10:

#line 243 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.ListViewItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListViewItem_MouseEnter);

#line default
#line hidden
                    return;
                case 11:
                    this.tt_customer = ((System.Windows.Controls.ToolTip)(target));
                    return;
                case 12:

#line 271 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.ListViewItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListViewItem_MouseEnter);

#line default
#line hidden
                    return;
                case 13:
                    this.tt_pawn = ((System.Windows.Controls.ToolTip)(target));
                    return;
                case 14:

#line 299 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.ListViewItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListViewItem_MouseEnter);

#line default
#line hidden
                    return;
                case 15:
                    this.tt_search = ((System.Windows.Controls.ToolTip)(target));
                    return;
                case 16:

#line 327 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.ListViewItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListViewItem_MouseEnter);

#line default
#line hidden
                    return;
                case 17:
                    this.tt_remind = ((System.Windows.Controls.ToolTip)(target));
                    return;
                case 18:

#line 355 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.ListViewItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListViewItem_MouseEnter);

#line default
#line hidden
                    return;
                case 19:
                    this.tt_report = ((System.Windows.Controls.ToolTip)(target));
                    return;
                case 20:

#line 384 "..\..\MainWindow.xaml"
                    ((System.Windows.Controls.ListViewItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ListViewItem_MouseEnter);

#line default
#line hidden
                    return;
                case 21:
                    this.tt_manage = ((System.Windows.Controls.ToolTip)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.ToolTip tt_expense;
    }
}

