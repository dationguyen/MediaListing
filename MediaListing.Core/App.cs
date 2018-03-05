using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace MediaListing.Core
{
    public class App :  MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Services")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterNavigationServiceAppStart<ViewModels.MainPageViewModel>();
        }
    }
}
