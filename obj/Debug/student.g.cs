﻿#pragma checksum "..\..\student.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FA35AB98361FFA46006498C3FA258FC8AFAA6D069FF886C0024B2F0FF80485E2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GoogleForms;
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


namespace GoogleForms {
    
    
    /// <summary>
    /// student
    /// </summary>
    public partial class student : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\student.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DATA;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\student.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox vopTB;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\student.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox otvTB;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\student.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button insertBtn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\student.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox idNumber;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\student.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox student1;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\student.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prepod;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\student.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox test;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\student.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PravotvTB;
        
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
            System.Uri resourceLocater = new System.Uri("/GoogleForms;component/student.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\student.xaml"
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
            
            #line 8 "..\..\student.xaml"
            ((GoogleForms.student)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DATA = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\student.xaml"
            this.DATA.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DATA_SelectionChanged_2);
            
            #line default
            #line hidden
            return;
            case 3:
            this.vopTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.otvTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.insertBtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\student.xaml"
            this.insertBtn.Click += new System.Windows.RoutedEventHandler(this.insertBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.idNumber = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.student1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\student.xaml"
            this.student1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.otvTB_Copy1_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.prepod = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\student.xaml"
            this.prepod.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.otvTB_Copy1_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.test = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.PravotvTB = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
