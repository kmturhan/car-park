using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
