using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RestaurantApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private static List<string> orders = new List<string>();

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] string item)
        {
            orders.Add(item);
            return Ok("Order placed");
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(orders);
        }
    }
}
