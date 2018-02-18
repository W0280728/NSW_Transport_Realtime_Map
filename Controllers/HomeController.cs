using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using nsw_pt_map.Models;
using transit_realtime;

namespace nsw_pt_map.Controllers
{

    public class HomeController : Controller
    {
        private int TRAIN = 0;
        private int BUS = 1;
        private int FERRY = 2;

        private int UPDATE_INTERVAL_SECONDS = 2;

        private IMemoryCache _cache;

        public HomeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public IActionResult Index()
        {
            FeedMessage trainFeed;
            var cacheKey = "TrainFeed";

            // Look for cache key.
            if (!_cache.TryGetValue(cacheKey, out trainFeed))
            {
                // Key not in cache, so get data.
                trainFeed = NSW_Transport_API.Get_Trains();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(UPDATE_INTERVAL_SECONDS));


                // Save data in cache.
                _cache.Set(cacheKey, trainFeed, cacheEntryOptions);
            }

            var trainsForView = PrepareVehiclesForViewCollectionFromFeed(feed: trainFeed, vehicleType: TRAIN);

            string GoogleScriptSource = string.Format("<script src='https://maps.google.com/maps/api/js?key={0}'></script>", System.Configuration.ConfigurationManager.AppSettings["GoogleMapsAPIKey"].ToString());

            ViewData["GoogleMapsAPIKey"] = GoogleScriptSource;

            return View(trainsForView);
        }

        public VehicleViewModelCollection updateTrains()
        {
            FeedMessage trainFeed;
            var cacheKey = "TrainFeed";

            // Look for cache key.
            if (!_cache.TryGetValue(cacheKey, out trainFeed))
            {
                // Key not in cache, so get data.
                trainFeed = NSW_Transport_API.Get_Trains();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(UPDATE_INTERVAL_SECONDS));

                // Save data in cache.
                _cache.Set(cacheKey, trainFeed, cacheEntryOptions);
            }

            var trainsForView = PrepareVehiclesForViewCollectionFromFeed(feed: trainFeed, vehicleType: TRAIN);

            return trainsForView;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private VehicleViewModelCollection PrepareVehiclesForViewCollectionFromFeed(FeedMessage feed, int vehicleType)
        {
            VehicleViewModelCollection vehiclesForViewCollection = new VehicleViewModelCollection();

            foreach (FeedEntity entity in feed.entity)
            {
                if (entity.vehicle.position != null) {

                    string _label = "";

                    switch (vehicleType)
                    {
                        case 0:
                            _label = entity.vehicle.vehicle.label;
                            break;
                        case 1:
                            _label = entity.vehicle.trip.route_id;
                            break;
                        case 2:
                            _label = entity.vehicle.vehicle.label;
                            break;
                    }

                    VehicleViewModel vehicle = new VehicleViewModel(
                        Label: _label,
                        LicensePlate: entity.vehicle.vehicle.license_plate,
                        Latitude: entity.vehicle.position.latitude,
                        Longitude: entity.vehicle.position.longitude,
                        id: entity.id
                        );
                    vehiclesForViewCollection.Vehicles.Add(vehicle);
                }
            }

            return vehiclesForViewCollection;
        }
    }
}
