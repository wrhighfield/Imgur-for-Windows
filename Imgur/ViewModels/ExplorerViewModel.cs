using Imgur.Helpers;
using Imgur.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Imgur.ViewModels
{
    public class ExplorerViewModel: Observable{

        //D.I (Dependency Injection)
        private readonly INavigator _navigator;
        private readonly IDialogService _dialogService;


        //Commands

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
        public ExplorerViewModel(INavigator navigator){
            _navigator = navigator;
        }

        public async Task InitializeAsync()
        {
            Loading = true;
            await Task.Delay(3000);
            Loading = false;
        }


        private ICommand _refreshViewCommand;

        public ICommand RefreshViewCommand
        {
            get
            {
                if (_refreshViewCommand == null)
                {
                    _refreshViewCommand = new RelayCommand(async () => await InitializeAsync());
                }
                return _refreshViewCommand;
            }
        }

    }
}
