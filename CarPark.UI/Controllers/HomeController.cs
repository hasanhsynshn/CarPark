using CarPark.Entities.Concrete;
using CarPark.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly MongoClient client;
        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;


        }

        public IActionResult Index()
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://hasanhuseyin:Hasaneyn536@carparkcluster.epotd.mongodb.net/CarParkDB?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("CarParkDB");
            var jsonString = System.IO.File.ReadAllText("cities.json");
            var cities = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cities>>(jsonString);
            var citiesCollection = database.GetCollection<City>("City");
            foreach (var item in cities)
            {
                var city = new City()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = item.name,
                    Plate = item.plate,
                    Latitude = item.latitude,
                    Longitude = item.longitude,
                    Counties = new List<County>()

            };
            foreach (var counties in item.counties)
            {
                    city.Counties.Add(new County
                    {
                        Id=ObjectId.GenerateNewId(),
                        Name=counties,
                        Latitude="",
                        Longitude="",
                        PostCode=""
                    });
            }
                citiesCollection.InsertOne(city);
        }
            return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
