using Imgur.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.ViewModels
{
    public class TagsViewModel : Observable{


        //Vars
        private bool _loading;

        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                OnPropertyChanged("Loading");
            }
        }


        public async void InitializeAsync()
        {
            Loading = true;
            await Task.Delay(3000);
            Loading = false;
        }

    }


}
