using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.IO;
using System.Reflection;
using System.Text;

namespace timeline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class personsController : Controller
    {
        [HttpGet]
        public IActionResult GetData()
        {
            //var data = _context.DataModels.ToList();
            //return new JsonResult(data);
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(basePath, "test.json");
            Encoding encoding = Encoding.ASCII;
            string jsonString = System.IO.File.ReadAllText(filePath, encoding);
            //DataObject dataObject = JsonSerializer.Deserialize<DataObject>(jsonString);
            return new JsonResult(System.IO.File.ReadAllText(System.IO.File.ReadAllText(filePath, encoding)));
        }
    }
}
