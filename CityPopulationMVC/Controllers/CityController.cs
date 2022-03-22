using CityPopulationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityPopulationMVC.Controllers
{
    public class CityController : Controller
    {
        private readonly IDataManager dataManager;

        public CityController(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<CityData> cityData = await dataManager.getAll();
            return View(cityData);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CityData cityData)
        {
            await dataManager.create(cityData);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(string city, string state)
        {
            var cityData = await dataManager.getOne(city, state);
            if (cityData==null)
                return NotFound();

            return View(cityData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CityData cityData)
        {
            await dataManager.save(cityData);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(string city, string state)
        {
            var cityData = await dataManager.getOne(city, state);
            if (cityData == null)
                return NotFound();
            return View(cityData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CityData cityData)
        {
            await dataManager.delete(cityData.City, cityData.State);
            return RedirectToAction(nameof(Index));
        }
    }
}
