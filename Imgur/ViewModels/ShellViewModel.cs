using Imgur.Helpers;
using Imgur.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace Imgur.ViewModels
{
    public class ShellViewModel : Observable
    {

    
        private string _lastName= "tESTELALala";
        private readonly INavigator _navigator;
        private readonly IDialogService _dialogService;

        public ShellViewModel(INavigator navigator, IDialogService dialogService){
            _navigator = navigator;
            _dialogService = dialogService;
        }



        /*
        public bool IsPaneOpen{
            get { return _lastName;  }
            set{
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        
        private ICommand _setPaneCommand;
        public ICommand OpenPaneCommand
        {
            get
            {
                if (_setPaneCommand == null)
                {
                    _setPaneCommand = new RelayCommand(() => IsPaneOpen = !_isPaneOpen);
                }

                return _setPaneCommand;
            }
        }*/

            
        private ICommand _openUploadCommand;

        public ICommand OpenUploadCommand{
            get{
                if(_openUploadCommand == null){
                    _openUploadCommand = new RelayCommand(() => _dialogService.OpenUploadAsync());
                }
                return _openUploadCommand;
            }
        }

        private ICommand _navigateToCommand;

        public ICommand NavigateToCommand{
            get{
                if (_navigateToCommand == null){
                    _navigateToCommand = new RelayCommand<String>((route) => _navigator.Navigate(route));
                }
                return _navigateToCommand;
            }
        }
        

        public ICommand SwitchThemeCommand { get; private set; }
    }
}
