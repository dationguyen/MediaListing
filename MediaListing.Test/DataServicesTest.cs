using MediaListing.Core.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MediaListing.Test
{
    [TestFixture]
    public class DataServicesTest
    {
        [Test]
        public async Task TestReadJsonDataSuccess()
        {
            var dataService = new DataService();

            var result = await dataService.ReadJsonDataAsync();

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task TestReadJsonDataWrongURL()
        {
            var dataService = new DataService();

            var result = await dataService.ReadJsonDataAsync("dummyURL.com");

            Assert.IsNull(result);
        }
    }
}
