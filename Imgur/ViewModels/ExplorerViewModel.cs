using Imgur.Helpers;
using Imgur.Models;
using Imgur.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Imgur.ViewModels
{
    public class ExplorerViewModel: Observable{

        //D.I (Dependency Injection)
        private readonly INavigator _navigator;
        private readonly IAPIConsumption _apiconsumption;
        private readonly IDialogService _dialogService;


        //Commands
        private ICommand _refreshViewCommand;

        public ICommand RefreshViewCommand
        {
            get
            {
                if (_refreshViewCommand == null)
                {
                    _refreshViewCommand = new RelayCommand(async () => {
                        Loading = true;
                        await LoadGalleryContent();
                        Loading = false;

                    });
                }
                return _refreshViewCommand;
            }
        }


        //Vars
        private ObservableCollection<Category> _retrievedGalleries;
        public ObservableCollection<Category> RetrievedGalleries
        {
            get { return _retrievedGalleries; }
            set
            {
                _retrievedGalleries = value;
                OnPropertyChanged("RetrievedGalleries");
            }
        }


        private ObservableCollection<Category> _retrievedSort;
        public ObservableCollection<Category> RetrievedSort{
            get { return _retrievedSort; }
            set{
                _retrievedSort = value;
                OnPropertyChanged("RetrievedSort");
            }
        }


        private ObservableCollection<Category> _retrievedMedia;
        public ObservableCollection<Category> RetrievedMedia
        {
            get { return _retrievedMedia; }
            set
            {
                _retrievedMedia = value;
                OnPropertyChanged("RetrievedMedia");
            }
        }


        // private ObservableCollection<DataRead> _retrievedImages;



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

        private int _selectedGallery;

        public int SelectedGallery{
            get { return _selectedGallery; }
            set{
                _selectedGallery = value;
                OnPropertyChanged("SelectedGallery");
            }
        }



        //Constructor
        public ExplorerViewModel(INavigator navigator,IAPIConsumption apiconsumption){
            _navigator = navigator;
            _apiconsumption = apiconsumption;
        }

        public async Task InitializeAsync(){

            Loading = true;

            if ((RetrievedGalleries = new ObservableCollection<Category>(_apiconsumption.GetExplorerGalleries())).Count > 0){ SelectedGallery = 0; }
            //if ((RetrievedSort = new ObservableCollection<Category>(_apiconsumption.GetExplorerSort())).Count > 0) { SelectedGallery = 0; }

            //Load Gallery Content

            await LoadGalleryContent();
            Loading = false;

        }


        public async Task LoadGalleryContent(){
            await Task.Delay(3000);
        }



        private ICommand _navigateMediaCommand;

        public ICommand NavigateMediaCommand{
            get{
                if (_navigateMediaCommand == null){
                    _navigateMediaCommand = new RelayCommand(() => {
                        Debug.WriteLine("Entrei");
                        _navigator.Navigate("media");
                    
                    });
                }
                return _navigateMediaCommand;
            }
        }





    }
}
