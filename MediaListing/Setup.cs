using System;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MediaListing.Core;

namespace MediaListing
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate appDelegate,IMvxIosViewPresenter presenter) : base (appDelegate,presenter)
        {
            
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}
