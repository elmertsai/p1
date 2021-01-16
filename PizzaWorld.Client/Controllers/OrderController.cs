using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaWorld.Client.Models;
using PizzaWorld.Storing;

namespace PizzaWorld.Client.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PizzaWorldRepository _ctx;

        public OrderController(ILogger<HomeController> logger, PizzaWorldRepository context)
        {
            _logger = logger;
            _ctx = context;
            
        }
        [Route("[controller]/[action]")]
        [Route("[controller]")]
        public IActionResult Get()
        {
            return View("Order");
        }
        public IActionResult Get(string id)
        {
            return View("Order", new OrderViewModel());
        }
        public IActionResult Post(OrderViewModel order)
        {
            if(ModelState.IsValid)
            {
                return View("Orderpass");
            }
    
            {
                return View("OrderFail");
            }
        }
        // public IActionResult Index()
        // {
        //     return View();
        // }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}