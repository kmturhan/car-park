using CarPark.Entities.Concrete;
using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
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
			client = new MongoClient("mongodb+srv://kmturhan:carparkdbpass@carparkcluster.idihkib.mongodb.net/?retryWrites=true&w=majority");
		}

		public IActionResult Index()
		{
			var database = client.GetDatabase("CarParkDB");
			var jsonString = System.IO.File.ReadAllText("cities.json");
			var cities = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cities>>(jsonString);

			var citiesCollection = database.GetCollection<City>("City");
			foreach (var item in cities)
			{
				var city = new City()
				{
					Id = ObjectId.GenerateNewId(),
					Name = item.Name,
					Plate = item.Plate,
					Longitude = item.Longitude,
					Latitude = item.Latitude,
					Counties = new List<County>()
				};
                foreach (var item2 in item.Counties)
                {
					city.Counties.Add(new County
					{
						Id = ObjectId.GenerateNewId(),
						Name = item2,
						Latitude = "",
						Longitude = "",
						PostCode = ""
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
