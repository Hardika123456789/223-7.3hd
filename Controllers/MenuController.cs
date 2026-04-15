using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMenu()
        {
            return Ok(new[] {
                new { name = "Pizza" },
                new { name = "Burger" },
                new { name = "Pasta" }
            });
        }
    }
}
