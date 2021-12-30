using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Controle de Usuário está documentado em https://go.microsoft.com/fwlink/?LinkId=234236

namespace Imgur.UWP.Controls
{
    public sealed partial class SelectorButtonFlyout : UserControl
    {
        public SelectorButtonFlyout()
        {
            this.InitializeComponent();
            IsCompact = false;
        }




        public bool IsCompact
        {
            get { return (bool)GetValue(IsCompactProperty); }
            set { SetValue(IsCompactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCompact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCompactProperty =
            DependencyProperty.Register("IsCompact", typeof(bool), typeof(SelectorButtonFlyout), new PropertyMetadata(0));


    }
}
