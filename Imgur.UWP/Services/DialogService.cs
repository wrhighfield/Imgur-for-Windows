using Imgur.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Imgur.UWP.Controls;

namespace Imgur.UWP.Services
{
    public class DialogService : IDialogService
    {

        public static bool IsDialogOpen;
        private ISystemInfoProvider _systemInfoProvider;

        public async Task OpenUploadAsync()
        {
            if (IsDialogOpen)
            {
                return;
            }

            IsDialogOpen = true;

            var Dialog = new ContentDialog()
            {
                Content = new UploadControl(),
                CloseButtonText = "Close",
                HorizontalAlignment = HorizontalAlignment.Left,
                FullSizeDesired = App.Services.GetRequiredService<ISystemInfoProvider>().IsMobile() ? true : false,
                Style=null,

            };

            //If Fall Creators update then set a Corner Radius
            if (App.Services.GetRequiredService<ISystemInfoProvider>().IsMinBuild(16299)){
                Dialog.CornerRadius = new CornerRadius(3);
            }


            await Dialog.ShowAsync();
            IsDialogOpen = false;

        }

    }
}
