using Imgur.Services;
using Imgur.UWP.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Imgur.UWP.Services
{
    public class Navigator: INavigator{

        public object RootFrame { get; set; }

        /// <inheritdoc/>
        public object Frame { get; set; }

        /// <inheritdoc/>
        public void GoBack(string sourcePage = null)
        {
            
            switch (sourcePage)
            {
                
                case nameof(sourcePage):
                    // supress transition to avoid implicit animation bug on home page.
                    GoBackSafely(RootFrame, new SuppressNavigationTransitionInfo());
                    break;
                default:
                    GoBackSafely(Frame);
                    break;
                    
            }
        
        }

        private void GoBackSafely(object frame, NavigationTransitionInfo transition = null)
        {
            if (frame is Frame f && f.CanGoBack)
            {
                f.GoBack(transition);
            }
        }

        public void Navigate(string name){
            if (Frame is Frame f) {
                switch (name){
                    case "explorer":
                        //Can't Navigate Twice to the same View
                        if (f.Content.GetType() != typeof(ExplorerView))
                        {
                            f.Tag = name;
                            f.Navigate(typeof(ExplorerView), null, new DrillInNavigationTransitionInfo());
                        }
                        break;
                    case "tags":
                        if (f.Content.GetType() != typeof(TagsView)){
                            f.Tag = name;
                            f.Navigate(typeof(TagsView), null, new DrillInNavigationTransitionInfo());
                        }
                        break;
                    case "settings":
                        if (f.Content.GetType() != typeof(SettingsView)){
                            f.Tag = name;
                            f.Navigate(typeof(SettingsView), null, new DrillInNavigationTransitionInfo());
                        }                     
                        break;
                }
            }
        }

        /// <inheritdoc/>
        public void ToScreensaver()
        {
            /*
            if (RootFrame is Frame f && f.CurrentSourcePageType != typeof(ScreensaverPage))
            {
                f.Navigate(typeof(ScreensaverPage), null, new DrillInNavigationTransitionInfo());
            }
            */
        }

        /// <inheritdoc/>
        public void ToCatalogue()
        {
            /*
            if (Frame is Frame f)
            {
                f.Navigate(typeof(CataloguePage), null, new SuppressNavigationTransitionInfo());
            }
            */
        }

        public bool CanGoBack(){
            if (Frame is Frame f && f.CanGoBack)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <inheritdoc/>
        public async void ToCompact()
        {
            /*
            if (Frame is Frame f)
            {
                // Ref: https://programmer.group/uwp-use-compact-overlay-mode-to-always-display-on-the-front-end.html
                var preferences = ViewModePreferences.CreateDefault(ApplicationViewMode.CompactOverlay);
                preferences.CustomSize = new Windows.Foundation.Size(360, 500);
                await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay, preferences);
                f.Navigate(typeof(CompactPage), null, new SuppressNavigationTransitionInfo());
            }
            */
        }

        /// <inheritdoc/>
        public void ToUploadPage()
        {
            /*
            if (Frame is Frame f)
            {
                f.Navigate(typeof(UploadPage), null, new DrillInNavigationTransitionInfo());
            }
            */
        }

    }
}
