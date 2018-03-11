using MediaListing.Core.Models;
using MediaListing.Core.Services;
using MediaListing.Core.ViewModels;
using Moq;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.Platform;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Test.Core;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaListing.Test
{
    [TestFixture]
    public class MainPageViewModeTest:MvxIoCSupportingTest
    {
        protected MockDispatcher MockDispatcher;
        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();
            MockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
            // required only when passing parameters
            Ioc.RegisterSingleton<IMvxStringToTypeParser>(new MvxStringToTypeParser());


        }

        [OneTimeSetUp]
        public void TestInit()
        {
            Setup();
        }


        [Test]
        public async Task TestThatDataWillBeLoadedAfterInitialize()
        {
            //set up mock data
            var testData = new List<Category>()
            {
                new Category(),
                new Category()
            };

            var mockDataService = new Mock<IDataService>();
            mockDataService.Setup(service => service.ReadJsonDataAsync(It.IsAny<string>()))
                .ReturnsAsync(testData);
            var navigationService = new Mock<IMvxNavigationService>();
            var mainPageViewModel = new MainPageViewModel(mockDataService.Object,navigationService.Object);

            //Action
            await mainPageViewModel.Initialize();

            //Assert
            Assert.AreEqual(testData,mainPageViewModel.CategoryDataSource);

        }
    }
}
