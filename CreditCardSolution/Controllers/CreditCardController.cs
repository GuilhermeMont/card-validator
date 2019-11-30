using System;
using System.Diagnostics;
using System.Web.Mvc;
using CreditCardSolution.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardSolution.Controllers
{
    public class CreditCardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Valid = false;
            Console.WriteLine( "Get Data");
            return View(new Models.CreditCard());
        }

        [HttpPost]
        public ActionResult Index (CreditCard card)
        {
            ViewBag.Valid = false;
            Console.WriteLine("Made it");
            if (!card.IsValid()) return View(card);
            ViewBag.Valid = true;
            ViewBag.Type = card.getType();

            return View(card);
        }

    }
}