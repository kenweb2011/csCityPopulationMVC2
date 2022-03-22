using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace CityPopulationService.Test
{
    public class Tests
    {
        private Mock<IDataProvider> _dataProvider;
        private DataManager _sut;

        [SetUp]
        public void Setup()
        {
            _dataProvider = new Mock<IDataProvider>();
            _dataProvider.Setup(x => x.getCityData()).ReturnsAsync(new[] { new CityData { } });

            _sut = new DataManager(_dataProvider.Object);
        }

        [Test]
        public async Task TestGetAll()
        {
            var result = await _sut.getAll();

            Assert.That(result, Is.Not.Null); ;
            Assert.That(result.Count(), Is.EqualTo(1));
        }
    }
}