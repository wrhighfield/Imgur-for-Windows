using Imgur.Services;
using Imgur.UWP.Services;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Imgur.UWP.Controls
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MediaGrid : Page
    {
        public MediaGrid()
        {
  
            this.InitializeComponent();
            object sysInfo = App.Services.GetService(typeof(ISystemInfoProvider)) ;

            //Fix for Mobile/Desktop WinUI
            if (sysInfo != null && ((ISystemInfoProvider)sysInfo).IsMobile()){
                //this.RepeaterScrollHost.Visibility = Visibility.Collapsed;
                //this.RepeaterScrollDef.Visibility = Visibility.Visible;
                Debug.WriteLine("Mobile");
            }
            else
            {
               // this.RepeaterScrollHost.Visibility = Visibility.Visible;
               // this.RepeaterScrollDef.Visibility = Visibility.Collapsed;
                Debug.WriteLine("PC");
            }
        }




        public object DataSource
        {
            get { return (object)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register("DataSource", typeof(object), typeof(MediaGrid), new PropertyMetadata(0));




        public bool MediaLoaded
        {
            get { return (bool)GetValue(MediaLoadedProperty); }
            set { SetValue(MediaLoadedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoaded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MediaLoadedProperty =
            DependencyProperty.Register("MediaLoaded", typeof(bool), typeof(MediaGrid), new PropertyMetadata(0));



        public ICommand SelectCommand
        {
            get { return (ICommand)GetValue(SelectCommandProperty); }
            set { SetValue(SelectCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectCommandProperty =
            DependencyProperty.Register("SelectCommand", typeof(ICommand), typeof(MediaGrid), new PropertyMetadata(0));


    }
}
