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

        //D.I (Dependency Injection)
        private readonly INavigator _navigator;
        private readonly IDialogService _dialogService;


        //Commands
        private ICommand _openUploadCommand;

        public ICommand OpenUploadCommand
        {
            get
            {
                if (_openUploadCommand == null)
                {
                    _openUploadCommand = new RelayCommand(() => _dialogService.OpenUploadAsync());
                }
                return _openUploadCommand;
            }
        }

        private ICommand _navigateToCommand;

        public ICommand NavigateToCommand
        {
            get
            {
                if (_navigateToCommand == null)
                {
                    _navigateToCommand = new RelayCommand<string>((route) => _navigator.Navigate(route));
                }
                return _navigateToCommand;
            }
        }

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


        //Constructor
        public ShellViewModel(INavigator navigator, IDialogService dialogService){
            _navigator = navigator;
            _dialogService = dialogService;
        }




    }
}
