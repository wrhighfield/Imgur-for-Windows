using Imgur.Helpers;
using Imgur.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Imgur.ViewModels
{
    public class ShutdownViewModel : Observable{


        //D.I (Dependency Injection)
        private readonly INavigator _navigator;


        public ShutdownViewModel(INavigator navigator){
            _navigator = navigator;
        }


        private ICommand _initCommand;

        public ICommand InitCommand
        {
            get
            {
                if (_initCommand == null){
                    _initCommand = new RelayCommand(async () => {
                        await Task.Delay(3000);
                        _navigator.Close();
                    });
                }
                return _initCommand;
            }
        }

    }
}
