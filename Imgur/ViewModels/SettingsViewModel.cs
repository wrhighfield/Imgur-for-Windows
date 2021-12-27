using Imgur.Constants;
using Imgur.Helpers;
using Imgur.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imgur.ViewModels
{
    public class SettingsViewModel : Observable{

        //D.I
        private ILocalSettings _localSettings;

        public SettingsViewModel(ILocalSettings localSettings){

            _localSettings = localSettings;

        }


        public bool RemindNotificationsEnabled
        {
            get => _localSettings.Get<bool>(LocalSettingsConstants.RemindNotifications);
            set => _localSettings.Set(LocalSettingsConstants.RemindNotifications, value);
        }

        public bool DataNotificationsEnabled
        {
            get => _localSettings.Get<bool>(LocalSettingsConstants.DataNotifications);
            set => _localSettings.Set(LocalSettingsConstants.DataNotifications, value);
        }

        public bool HDonWifiEnabled
        {
            get => _localSettings.Get<bool>(LocalSettingsConstants.HDonWifi);
            set => _localSettings.Set(LocalSettingsConstants.HDonWifi, value);
        }

        public bool LiveTilesEnabled
        {
            get => _localSettings.Get<bool>(LocalSettingsConstants.LiveTiles);
            set => _localSettings.Set(LocalSettingsConstants.LiveTiles, value);
        }

    }
}
