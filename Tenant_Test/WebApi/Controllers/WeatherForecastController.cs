using Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TestContext db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TestContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [HttpGet("product")]
        public IActionResult GetByProduct()
        {
            var products = this.db.Products.ToArray();

            return this.Ok(products);
        }

        [HttpGet("user")]
        public IActionResult GetByUser()
        {
            var products = this.db.Products.ToArray();

            return this.Ok(products);
        }

        [HttpPost("login")]
        public IActionResult LogIn(string email)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return this.BadRequest("Sorry!!!");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("Tenant",user.TenantId)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return this.Ok("Logged!!!");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return this.Ok("Unlogged!");
        }
    }
}