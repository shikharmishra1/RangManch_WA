using Microsoft.AspNetCore.Mvc;
namespace ViteAPI
{
    public class TestController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("hi bro");
        }
    }

}