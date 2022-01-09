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
                        if (!Loading) {
                            Loading = true;
                            await LoadGalleryContent();
                            await Task.Delay(3000);
                            Loading = false;
                        }else{
                            return;
                        }
                    });
                }
                return _refreshViewCommand;
            }
        }


        //Vars
        private ObservableCollection<Category> _retrievedGalleries = new ObservableCollection<Category>();
        public ObservableCollection<Category> RetrievedGalleries
        {
            get { return _retrievedGalleries; }
            set
            {
                _retrievedGalleries = value;
                OnPropertyChanged("RetrievedGalleries");
            }
        } 


        private ObservableCollection<Category> _retrievedSort = new ObservableCollection<Category>();
        public ObservableCollection<Category> RetrievedSort{
            get { return _retrievedSort; }
            set{
                _retrievedSort = value;
                OnPropertyChanged("RetrievedSort");
            }
        }


        private ObservableCollection<Media> _retrievedMedia = new ObservableCollection<Media>();
        public ObservableCollection<Media> RetrievedMedia
        {
            get { return _retrievedMedia; }
            set
            {
                _retrievedMedia = value;
                Debug.WriteLine("atualizeicoleecao");
                OnPropertyChanged("RetrievedMedia");
            }
        }

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

        private int _selectedSort;

        public int SelectedSort
        {
            get { return _selectedSort; }
            set
            {
                _selectedSort = value;
                OnPropertyChanged("SelectedSort");
            }
        }

        //Constructor
        public ExplorerViewModel(INavigator navigator,IAPIConsumption apiconsumption){
            _navigator = navigator;
            _apiconsumption = apiconsumption;
        }

        public async Task InitializeAsync(){

            //If already loaded just ignore 
            if ((RetrievedGalleries.Count > 0 && RetrievedSort.Count > 0) || Loading){
                return;
            }
            

            Debug.WriteLine("A");

            Loading = true;

            //Retrieve Basic Sort Data (Only Once)
            try{
                if ((RetrievedGalleries = new ObservableCollection<Category>(_apiconsumption.GetExplorerGalleries())).Count > 0) { SelectedGallery = 0; }
                if ((RetrievedSort = new ObservableCollection<Category>(_apiconsumption.GetExplorerSort())).Count > 0) { SelectedSort = 0; }
            }catch (Exception e){
                Debug.WriteLine(e);
                Loading = false;
                return;
            }

            //Load Gallery Content
            await Task.Delay(1000);
            await LoadGalleryContent();
            await Task.Delay(3000);
            Loading = false;          
        }


        public async Task LoadGalleryContent(){
            Response ExplorerMediaResponse = await _apiconsumption.GetExplorerMedia(SelectedGallery, SelectedSort);

            //Reset RetrievedMedia
            RetrievedMedia.Clear();
        
            if (ExplorerMediaResponse.Success){
                await Task.Delay(1000);
                RetrievedMedia = new ObservableCollection<Media>((List<Media>)ExplorerMediaResponse.Data);
            }
        }



        private ICommand _navigateMediaCommand;

        public ICommand NavigateMediaCommand{
            get{
                if (_navigateMediaCommand == null){
                    _navigateMediaCommand = new RelayCommand(() => {
                        _navigator.Navigate("media");
                    
                    });
                }
                return _navigateMediaCommand;
            }
        }





    }
}
