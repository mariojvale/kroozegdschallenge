using System.Collections.Generic;
using Krooze.EntranceTest.Tests;
using Microsoft.AspNetCore.Mvc;
using Krooze.EntranceTest.WriteHere.Tests;
using Krooze.EntranceTest.WriteHere.Tests.WebTests;
using Newtonsoft.Json.Linq;
using Krooze.EntranceTest.WriteHere.Tests.InjectionTests;
using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Krooze.EntranceTest.WriteHere.Structure.Model;

namespace Krooze.EntranceTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
      
        // GET api/values
        [HttpGet]
        public ActionResult<JObject> Get()
        {
            WebTest web = new WebTest();
            return web.GetAllMovies();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<List<CruiseDTO>> Get(CruiseRequestDTO id)
        {
            InjectionTest injection = new InjectionTest();
            return injection.GetCruises(id);
            
            //var webtests = new WebTest();
            //return webtests.GetAllMovies();
            //return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

            XMLTest logic = new XMLTest();
            logic.TranslateXML();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
