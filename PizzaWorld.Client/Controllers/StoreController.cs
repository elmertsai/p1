using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaWorld.Client.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.Client.Controllers
{
    
    [Route("[controller]")]
    public class StoreController : Controller
    {
        
        private readonly PizzaWorldRepository _repo;

        public StoreController(PizzaWorldRepository repo)
        {
            _repo = repo;
        }
        [Route("[action]")]
        [HttpGet]
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
        [Route("[action]")]
        [HttpGet]
        public IActionResult StoreSelect()
        {
            StoreViewModel model = new StoreViewModel();
            model.Addresses = _repo.GetStoreAddresses();
            model.Stores = _repo.GetStoreNames();

            return View("StoreSelect",model);
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostStoreSelected(StoreViewModel model)
        {
            TempData["SelectedStoreName"] = model.SelectedStoreName;
            return View("StoreHome",model);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetStoreHistory()
        {
            StoreViewModel model = new StoreViewModel();
            model.SelectedStoreName = TempData.Peek("SelectedStoreName") as string;
            model.StoreOrderHistory = _repo.GetStoreOrders(model.SelectedStoreName).ToList();
            double revenue = 0;
            foreach (var item in model.StoreOrderHistory)
            {
                revenue = revenue+item.Price;        
            }

            model.Revenue=revenue;
            
            return View("StoreOrderHistory",model);
        }
        
    }
}