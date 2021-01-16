using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaWorld.Client.Models;

namespace PizzaWorld.Client.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller
    {
        //[Route("[controller]")]
        [HttpGet] // http://localhost:5001/store
        public IActionResult GetStoreList()
        {
            var stores = new StoreViewModel();
            //DATA BINDING: 3 options --> Data from action --> view
            ViewBag.Stores = stores.Stores; //dynamic object
            ViewData["Stores"]= stores.Stores; // dictionary object, dictionary<string,object>
            
            //request. Data survives the whole lifetime of the request (until the final request)
            TempData["Stores"]= stores.Stores;
            return View("Store",new StoreViewModel());
        }
        [HttpGet("{store}")] // http://localhost:5001/store/<SOME VALUE>
        public IActionResult GetStore(string store)
        {
            return View("Store",store);
        }
        
    }
}