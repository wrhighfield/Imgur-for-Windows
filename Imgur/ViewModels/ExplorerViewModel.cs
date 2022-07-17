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

        private bool loadingCancelationToken;

        //Commands
        private ICommand _loadViewCommand;

        public ICommand LoadViewCommand
        {
            get
            {
                if (_loadViewCommand == null)
                {

                    _loadViewCommand = new RelayCommand(async () => {
                        if (!Loading){              
                            Loading = true;
                            if (!loadingCancelationToken){
                                loadingCancelationToken = true;
                            }
                            await Task.Delay(1500);                       
                            await LoadGalleryContent();
                            Loading = false;
        

                            

                            //Load Async Media
                            foreach (var cur in RetrievedMedia){
                                if (loadingCancelationToken && Loading){
                                    break;
                                }else{
                                    await cur.RetrieveImageAsync();
                                    await Task.Delay(500);
                                }
                          
                            }

                            loadingCancelationToken = false;


                        }
                    });
                }
                return _loadViewCommand;
            }
        }

        private ICommand _navigateMediaCommand;

        public ICommand NavigateMediaCommand
        {
            get
            {
                if (_navigateMediaCommand == null)
                {
                    _navigateMediaCommand = new RelayCommand(() => {
                        Debug.WriteLine("Navegar pra media");
                        _navigator.Navigate("media");

                    });
                }
                return _navigateMediaCommand;
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

        public void Initialize(){

            //If already loaded just ignore 
            if ((RetrievedGalleries.Count > 0 && RetrievedSort.Count > 0) || Loading){
                return;
            }


            //Retrieve Basic Sort Data (Only Once)
            try
            {
                loadingCancelationToken = false;
                RetrievedGalleries = new ObservableCollection<Category>(_apiconsumption.GetExplorerGalleries());
                RetrievedSort = new ObservableCollection<Category>(_apiconsumption.GetExplorerSort());

                //If Populated then
                if (RetrievedGalleries.Count > 0 && RetrievedSort.Count > 0) {
                    SelectedGallery = 0;
                    SelectedSort = 0;
                }
               
            }catch (Exception e){
                Debug.WriteLine(e);
                Loading = false;
                return;
            }
        }


        public async Task LoadGalleryContent(){

            //Reset RetrievedMedia

            if(RetrievedMedia.Count > 0){
                RetrievedMedia.Clear();
            }
            

            Response ExplorerMediaResponse = await _apiconsumption.GetExplorerMedia(SelectedGallery, SelectedSort);
            
            if (ExplorerMediaResponse.Success){  
                
                RetrievedMedia = new ObservableCollection<Media>((List<Media>)ExplorerMediaResponse.Data);
                
                Debug.WriteLine(RetrievedMedia.Count);
            }
            
        }






    }
}
