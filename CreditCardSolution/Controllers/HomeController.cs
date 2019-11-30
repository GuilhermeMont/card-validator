using System;
using System.Diagnostics;
using System.Web.Mvc;
using CreditCardSolution.Models;

namespace CreditCardSolution.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            Console.WriteLine( "Made it");
            return View(new Models.CreditCard());
        }

        
        public void Create(Models.CreditCard card)
        {
            Console.WriteLine( "Made it");
            if (ModelState.IsValid)
            {
               
               Debug.Print(card.isValid().ToString());
            }
 
        }

    }
}