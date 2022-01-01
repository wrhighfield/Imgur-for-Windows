using Imgur.Helpers;
using Imgur.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
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
    public sealed partial class NavigationView : UserControl
    {
        public NavigationView()
        {
            this.InitializeComponent();
            Load();
        }


        private void Load(){

            IsPaneOpen = false;

            if (App.Services.GetRequiredService<ISystemInfoProvider>().IsMobile() || App.Services.GetRequiredService<ISystemInfoProvider>().IsXbox()){
                IsTitleBarPresent = false;
            }else{
                IsTitleBarPresent = true;
                Window.Current.SetTitleBar(titlePanel);
                SearchBox.Margin = new Thickness(140, 0, 140, 0);
            }
        }

        
        
        public bool IsTitleBarPresent { get; set; }

        public string DisplayMode{
            get { return (string)GetValue(DisplayModeProperty); }
            set {
                SetValue(DisplayModeProperty, value);
               // SetValue(HeaderNeedsAdjustProperty, (value == "CompactInline") && !IsPaneOpen ? true : false);
            }
        }

        // Using a DependencyProperty as the backing store for DisplayMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register("DisplayMode", typeof(string), typeof(NavigationView), new PropertyMetadata(0));



        public bool IsPaneOpen
        {
            get {
                return (bool)GetValue(IsPaneOpenProperty); }
            set {
                SetValue(IsPaneOpenProperty, value);
               // SetValue(HeaderNeedsAdjustProperty, ((DisplayMode.ToString() == "CompactInline") && !value) ? true : false);
            }
        }

        // Using a DependencyProperty as the backing store for IsPaneOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPaneOpenProperty =
            DependencyProperty.Register("IsPaneOpen", typeof(bool), typeof(NavigationView), new PropertyMetadata(0));


        public Thickness HeaderMargin
        {
            get { return (Thickness)GetValue(HeaderMarginProperty); }
            set { SetValue(HeaderMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderMarginProperty =
            DependencyProperty.Register("HeaderMargin", typeof(Thickness), typeof(NavigationView), new PropertyMetadata(0));



        public object FooterPanel
        {
            get { return (object)GetValue(FooterPanelProperty); }
            set { SetValue(FooterPanelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FooterPanel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FooterPanelProperty =
            DependencyProperty.Register("FooterPanel", typeof(object), typeof(NavigationView), new PropertyMetadata(0));



        public object NavigationItems
        {
            get { return (object)GetValue(NavigationItemsProperty); }
            set { SetValue(NavigationItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigationItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigationItemsProperty =
            DependencyProperty.Register("NavigationItems", typeof(object), typeof(NavigationView), new PropertyMetadata(0));



        public object NavigationContent{
            get { return (object)GetValue(NavigationContentProperty); }
            set { SetValue(NavigationContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigationContentProperty =
            DependencyProperty.Register("NavigationContent", typeof(object), typeof(NavigationView), new PropertyMetadata(0));



        public object HeaderContent
        {
            get { return (object)GetValue(HeaderContentProperty); }
            set { SetValue(HeaderContentProperty, value);}
        }

        // Using a DependencyProperty as the backing store for HeaderContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderContentProperty =
            DependencyProperty.Register("HeaderContent", typeof(object), typeof(NavigationView), new PropertyMetadata(0));



        public object PaneHeaderContent
        {
            get { return (object)GetValue(PaneHeaderContentProperty); }
            set { SetValue(PaneHeaderContentProperty, value);  
            }
        }

        // Using a DependencyProperty as the backing store for HeaderContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaneHeaderContentProperty =
            DependencyProperty.Register("PaneHeaderContent", typeof(object), typeof(NavigationView), new PropertyMetadata(0));





        public object HeaderControls
        {
            get { return (object)GetValue(HeaderControlsProperty); }
            set { SetValue(HeaderControlsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderControls.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderControlsProperty =
            DependencyProperty.Register("HeaderControls", typeof(object), typeof(NavigationView), new PropertyMetadata(0));




        public bool HeaderNeedsAdjust
        {
            get { return (bool)GetValue(HeaderNeedsAdjustProperty); }
        }

        // Using a DependencyProperty as the backing store for HeaderNeedsAdjust.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderNeedsAdjustProperty =
            DependencyProperty.Register("HeaderNeedsAdjust", typeof(bool), typeof(NavigationView), new PropertyMetadata(0));

        //Set State Trigger when App Starts
        private void NavigationViewControl_Loaded(object sender, RoutedEventArgs e){
            switch (App.AppStartBounds.Width){
                case double w when (w > 800 && w < 1200):
                    VisualStateManager.GoToState(this, nameof(InlineState), false);
                    break;
                case double w when (w >= 1200):
                    VisualStateManager.GoToState(this, nameof(WidescreenInlineState), false);
                    break;
            }
        }
    }
}
