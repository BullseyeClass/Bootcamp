using Bootcamp.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase
    {
        private readonly IGetTest _getTest;

        public Test(IGetTest getTest)
        {
            this._getTest = getTest;
        }

        [HttpGet]
        public IActionResult GetHtmlTest()
        {

        }
    }
}
