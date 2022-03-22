using System.Text.Json;

namespace CityPopulationService
{
    public interface IDataProvider
    {
        Task<IList<CityData>> getCityData();
        Task saveCityData(IList<CityData> cityData);
    }

    public class DataProvider : IDataProvider
    {
        private const string FileName = @"citydata.json";

        public async Task<IList<CityData>> getCityData()
        {
            var _cityData = await ReadAll();
            return _cityData;
        }

        public async Task saveCityData(IList<CityData> cityData)
        {
            await SaveAll(cityData);
        }

        private async Task SaveAll(IList<CityData> cityData)
        {
            using FileStream createStream = File.Create(FileName);
            await JsonSerializer.SerializeAsync(createStream, cityData);
            await createStream.DisposeAsync();
        }

        private async Task<IList<CityData>> ReadAll()
        {
            IList<CityData> cityData = null;
            try
            {
                using FileStream openStream = File.OpenRead(FileName);
                cityData =
                    await JsonSerializer.DeserializeAsync<IList<CityData>>(openStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cityData ?? InititalData();
        }

        private static List<CityData> InititalData()
        {
            return new List<CityData>
            {
                new CityData{City="New York", State="New York", Population=8804190},
                new CityData{City="Los Angeles", State="California", Population=3898747},
                new CityData{City="Chicago", State="Illinois", Population=2746388},
            };
        }

    }
}