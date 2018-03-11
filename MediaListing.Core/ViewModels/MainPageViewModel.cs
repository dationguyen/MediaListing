using System;
using MediaListing.Core.Models;
using MediaListing.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;

namespace MediaListing.Core.ViewModels
{
    public class MainPageViewModel:MvxViewModel
    {
        private readonly IDataService _dataService;
        private readonly IMvxNavigationService _navigationService;
        
        public MvxObservableCollection<Category> CategoryDataSource { get; set; }

        private string _text;

        public string SText
        {
            get { return _text; }
            set { SetProperty(ref _text,value); }
        }


        public MainPageViewModel(IDataService dataService,IMvxNavigationService navigationService)
        {
            //setup DI services
            _dataService = dataService;
            _navigationService = navigationService;
            //create default CategoryDataSource
            CategoryDataSource = new MvxObservableCollection<Category>();
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            //retrive data from URL
            var source = await _dataService.ReadJsonDataAsync(null);
            
            if(source != null)
            {
                //revert order of Categories to match with wireframe
                source.Reverse();
                //add items to CategoryDataSource
                foreach(var category in source)
                {
                    //set up wrapped command for child 
                    category.ItemSelectCommand = new MvxCommand<MediaItem>(MediaSelected);
                    CategoryDataSource.Add(category);
                }
            }

        }

        private async void MediaSelected(MediaItem mediaItem)
        {
            //navigate to Item Detail Page
            await _navigationService.Navigate<ItemDetailPageViewModel, MediaItem>(mediaItem);
        }
    }
}
