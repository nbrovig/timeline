using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.IO;

namespace timeline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        [HttpGet]
        public IActionResult GetData()
        {
            //var data = _context.DataModels.ToList();
            //return new JsonResult(data);
            string jsonString = System.IO.File.ReadAllText("~/data/events.json");
            DataObject dataObject = JsonSerializer.Deserialize<DataObject>(jsonString);
            return new JsonResult(dataObject);
        }
    }
}

