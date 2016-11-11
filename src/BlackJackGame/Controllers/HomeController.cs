using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJackGame.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackJackGame.Controllers
{
    public class HomeController : Controller
    {
        private BlackJack _blackjack;
        public IActionResult Index()
        {
            _blackjack = new BlackJack();
            WriteSession(_blackjack);
            return View(_blackjack);
        }

        public IActionResult NextCard() {
            _blackjack = ReadSession();
            _blackjack.GivePlayerAnotherCard();
            WriteSession(_blackjack);
            return View(nameof(Index), _blackjack);
        }
        public IActionResult Pass() {
            _blackjack = ReadSession();
            _blackjack.PassToDealer();
            WriteSession(_blackjack);
            return View(nameof(Index), _blackjack);
        }
        private void WriteSession(BlackJack blackjack) {
            HttpContext.Session.SetString("BJ", JsonConvert.SerializeObject(blackjack));
        }

        private BlackJack ReadSession() {
            return JsonConvert.DeserializeObject<BlackJack>(HttpContext.Session.GetString("BJ"));
        }

    }
}
