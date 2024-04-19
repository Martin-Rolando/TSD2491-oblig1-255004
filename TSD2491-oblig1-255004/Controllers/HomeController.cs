using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using TSD2491_oblig1_255004.Models;

namespace TSD2491_oblig1_255004.Controllers
{
	public class HomeController : Controller
	{
        private readonly static BlazerMatchingGameModel _blazerMatchingGameModel = new BlazerMatchingGameModel();

        public HomeController()
        {

        }

		public IActionResult Index()
		{
			return View();
		}

        [HttpPost]
        public IActionResult ButtonClick(string animal, string description)
        {
            _blazerMatchingGameModel.ButtonClick(animal, description);
            return RedirectToAction("Index");
        }

	}
}
