using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJackGame.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackJackGame.Controllers
{
    public class HomeController : Controller
    {
        private BlackJack _blackjack;
        public IActionResult Index()
        {
            _blackjack = new BlackJack();
            return View(_blackjack);
        }
    }
}
