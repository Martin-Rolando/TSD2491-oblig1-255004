using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;// Importerer nødvendige pakker
using System.Diagnostics;
using TSD2491_oblig1_255004.Models;// Importerer modeller

namespace TSD2491_oblig1_255004.Controllers
{
	public class HomeController : Controller
	{
        // Oppretter en statisk instans av BlazerMatchingGameModel
        private readonly static BlazerMatchingGameModel _blazerMatchingGameModel = new BlazerMatchingGameModel();

        public HomeController()
        {

        }

		public IActionResult Index()
		{
            // Henter spillernavnet fra økten
            _blazerMatchingGameModel.PlayerName = HttpContext.Session.GetString("PlayerName");

            // Hvis spillernavnet ikke er null, henter antall spill spilt
            if (_blazerMatchingGameModel.PlayerName != null)
            {
                _blazerMatchingGameModel.GamesPlayed = BlazerMatchingGameModel.GetGamesPlayed(_blazerMatchingGameModel.PlayerName);
            }
            return View(_blazerMatchingGameModel);// Returnerer visningen med spillmodellen
        }

        // Metode som håndterer klikk på emojiene
        [HttpPost]
        public IActionResult ButtonClick(string emoji, string description)
        {
            _blazerMatchingGameModel.ButtonClick(emoji, description);// Kaller på metoden for å behandle knappeklikk
            return RedirectToAction("Index");// Omdirigerer tilbake til Index-metoden etter håndtert klikk
        }
        
        // Metode som registrerer spillernavnet
        [HttpPost]
        public IActionResult RegisterPlayer(BlazerMatchingGameModel model)
        {
            // Setter spillernavnet i økten
            HttpContext.Session.SetString("PlayerName", model.PlayerName);

            // Oppdaterer spillernavnet i spillmodellen
            _blazerMatchingGameModel.PlayerName = model.PlayerName;

            // Hvis antall spill spilt er 0, henter antall spill spilt fra modellen
            if (_blazerMatchingGameModel.GamesPlayed == 0) 
            {
                _blazerMatchingGameModel.GamesPlayed = BlazerMatchingGameModel.GetGamesPlayed(_blazerMatchingGameModel.PlayerName);
            }
            // Omdirigerer tilbake til Index-metoden etter registrering av spiller
            return RedirectToAction("Index");
        }

    }
}
