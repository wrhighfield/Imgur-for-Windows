using System;
using System.Collections.Generic;
using System.Text;

namespace Imgur.Services
{
    public interface INavigator
    {


        object RootFrame { get; set; }

        /// <summary>
        /// The inner frame that can navigate. This must be set before
        /// any method is called.
        /// </summary>
        object Frame { get; set; }



        /// <summary>
        /// Navigates to a frame Page inside the Shell.
        /// </summary>
        void Navigate(string name);


        /// <summary>
        /// Navigates to a outside shell page.
        /// </summary>
        void RootNavigate(string name);


        bool CanGoBack();

        void Close();
  
        /// <summary>
        /// Attempts to navigate back.
        /// </summary>
        /// <param name="sourcePage">Optional. If provided,
        /// then specific go back functionality may be applied.
        /// For example, if ScreensaverPage is provided, the 
        /// RootFrame is used for GoBack.</param>
        void GoBack(string sourcePage = null);
    }
}
