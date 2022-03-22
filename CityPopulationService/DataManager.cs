namespace CityPopulationService
{
    public interface IDataManager
    {
        Task<IEnumerable<CityData>> getAll();
        Task<CityData?> getOne(string city, string state);
        Task create(CityData cityData);
        Task save(CityData cityData);
        Task delete(string city, string state);
    }

    public class DataManager : IDataManager
    {
        private readonly IDataProvider dataProvider;

        public DataManager(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public async Task<IEnumerable<CityData>> getAll()
        {
            return await dataProvider.getCityData();
        }

        public async Task create(CityData cityData)
        {
            //TODO Validation

            var current = await dataProvider.getCityData();
            current.Add(cityData);
            await dataProvider.saveCityData(current);
        }

        public async Task<CityData?> getOne(string city, string state)
        {
            var result = await dataProvider.getCityData();
            return result.FirstOrDefault(x => x.City == city && x.State == state);
        }

        public async Task save(CityData cityData)
        {
            var result = (await getAll()).ToList();
            var matches = result.Where(x => x.City == cityData.City && x.State == cityData.State);
            matches.ToList().ForEach(x => x.Population = cityData.Population);
            await dataProvider.saveCityData(result);
        }

        public async Task delete(string city, string state)
        {
            var result = (await getAll()).ToList();
            result.RemoveAll(x => x.City == city && x.State == state);
            await dataProvider.saveCityData(result);
        }
    }
}