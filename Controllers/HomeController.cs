using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotes.Factory;
using quotes.Models;

namespace quotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
        public HomeController()
        {
            userFactory = new UserFactory();
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors="";
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Quotes quote)
        {
            if(ModelState.IsValid) {
                userFactory.Add(quote);
                return RedirectToAction("Home");
            }
            ViewBag.errors=ModelState.Values;
            return View("Index");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Home()
        {

            ViewBag.Quotes=userFactory.FindAll();
            return View("quotes");
        }

        [HttpPost]
        [Route("skip")]
        public IActionResult Skip()
        {
            return RedirectToAction("Home");
        }

        [HttpPost]
        [Route("addQuote")]
        public  IActionResult Add()
        {
            return RedirectToAction("Index");
        }
    }
}
