using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			const string connectionUri = "mongodb+srv://kmturhan:carparkdbpass@carparkcluster.idihkib.mongodb.net/?retryWrites=true&w=majority";
			var settings = MongoClientSettings.FromConnectionString(connectionUri);
			var client = new MongoClient(settings);
			var database = client.GetDatabase("CarParkDB");
			var collection = database.GetCollection<Test>("Test");

			var test = new Test()
			{
				_Id = ObjectId.GenerateNewId(),
				NameSurname = "test test",
				Age = 25,
				AddressList = new List<Address>()
				{
					new Address
					{
						Title = "Ev",
						Description = "Kocaeli"
					},
					new Address
					{
						Title = "Okul",
						Description = "Sakarya"
					}
				}
			};
			collection.InsertOne(test);

			var customer = new Customer
			{
				Id = 1,
				NameSurname = "testtetstsetse",
				Age = 26
			};
			
			_logger.LogError("Customer step throw error (@customer)", customer);


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
