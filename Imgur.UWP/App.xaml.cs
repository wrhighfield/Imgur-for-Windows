//using Microsoft.Extensions.DependencyInjection;
using Imgur.Services;
using Imgur.UWP.Services;
using Imgur.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;




namespace Imgur.UWP
{
    /// <summary>
    ///Fornece o comportamento específico do aplicativo para complementar a classe Application padrão.
    /// </summary>
    sealed partial class App : Application
    {

        private static Frame AppFrame;
        private IServiceProvider _serviceProvider;

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }


        protected override async void OnLaunched(LaunchActivatedEventArgs e){
            await ActivateAsync(e.PrelaunchActivated);
        }


        private async Task ActivateAsync(bool prelaunched){

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content
            if (rootFrame == null) { 
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;

                _serviceProvider = ConfigureServices();

                //Set Theme Listner if Fall Creators Update
                if(Services.GetRequiredService<ISystemInfoProvider>().IsMinBuild(14393)){
                    rootFrame.ActualThemeChanged += OnActualThemeChanged;
                }
            }

      
            if (prelaunched==false){
                CoreApplication.EnablePrelaunch(true);
                
                if (rootFrame.Content == null) {
                    rootFrame.Navigate(typeof(Views.ShellView));
                }

                HardwareButtons.BackPressed += HardwareButtons_BackPressed;

                Window.Current.Activate();
                
            }

           

            AppFrame = rootFrame;
            Services.GetRequiredService<INavigator>().RootFrame = rootFrame;
            CustomizeTitleBar(false);
            await SetAppBarAsync();
            this.FocusVisualKind = FocusVisualKind.Reveal;
            //SetAppRequestedTheme();
        }


        private async void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e){
            e.Handled = true;
            /*
            Navigator NavService = Services.GetRequiredService<Navigator>();
            */
            if (Services.GetRequiredService<INavigator>().CanGoBack()){
                Services.GetRequiredService<INavigator>().GoBack();
            }
            else
            {
                var msg = new MessageDialog("Confirm Close");
                var okBtn = new UICommand("OK");
                var cancelBtn = new UICommand("Cancel");
                msg.Commands.Add(okBtn);
                msg.Commands.Add(cancelBtn);
                IUICommand result = await msg.ShowAsync();

                if (result != null && result.Label == "OK")
                {
                    Application.Current.Exit();
                }
            }
        }



        public static IServiceProvider Services
        {
            get
            {
                IServiceProvider serviceProvider = ((App)Current)._serviceProvider;

                if (serviceProvider is null)
                {
                    Debug.WriteLine("Cagada no S.P");
                }

                return serviceProvider;
            }
        }
        
        private void CustomizeTitleBar(bool darkTheme)
        {
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            var viewTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.ButtonBackgroundColor = Colors.Transparent;
            viewTitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            viewTitleBar.ButtonForegroundColor = darkTheme ? Colors.LightGray : Colors.Black;
        }

        private async Task SetAppBarAsync(){
            
            //Set Frist Time on Desktop
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
       

            // If we have a phone contract, hide the status bar
            if (Services.GetRequiredService<ISystemInfoProvider>().IsMobile()){
                var statusBar = StatusBar.GetForCurrentView();
                await statusBar.HideAsync();
            }
        }

        private static IServiceProvider ConfigureServices(){


            var provider = new ServiceCollection()
                .AddSingleton<INavigator, Navigator>()
                .AddSingleton<IDialogService,DialogService>()
                .AddSingleton<ISystemInfoProvider,SystemInfoProvider>()
                .AddTransient<ShellViewModel>()
                .AddTransient<SettingsViewModel>()
                .AddTransient<ExplorerViewModel>()
                .AddTransient<TagsViewModel>()
                .BuildServiceProvider(true);
            return provider;
        }

        private void OnActualThemeChanged(FrameworkElement sender, object args)
        {
            CustomizeTitleBar(true);
        }


        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
   
        }

        /// <summary>
        /// Chamado quando a execução do aplicativo está sendo suspensa.  O estado do aplicativo é salvo
        /// sem saber se o aplicativo será encerrado ou retomado com o conteúdo
        /// da memória ainda intacto.
        /// </summary>
        /// <param name="sender">A fonte da solicitação de suspensão.</param>
        /// <param name="e">Detalhes sobre a solicitação de suspensão.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Salvar o estado do aplicativo e parar qualquer atividade em segundo plano
            deferral.Complete();
        }
    }
}
