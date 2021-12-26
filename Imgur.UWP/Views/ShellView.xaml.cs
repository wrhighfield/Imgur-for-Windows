using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Imgur.ViewModels;
using Windows.UI.ViewManagement;
using Imgur.Services;
using Imgur.Helpers;
using System.Diagnostics;



// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Imgur.UWP.Views
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class ShellView : Page
    {
        public ShellView()
        {
            this.InitializeComponent();
            this.DataContext = App.Services.GetRequiredService<ShellViewModel>();
            //this.Unloaded += (_, _) => { ViewModel.Dispose(); };
        }

        public ShellViewModel ViewModel => (ShellViewModel)this.DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var navigator = App.Services.GetRequiredService<INavigator>();
            navigator.Frame = MainFrame;
            Debug.WriteLine("Yoopisie");
            MainFrame.Navigate(typeof(ExplorerView));
        }



    }
}
