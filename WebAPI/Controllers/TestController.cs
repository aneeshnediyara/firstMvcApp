using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TestController : ApiController
    {
        public IEnumerable<string> GetCities()
        {
            return new List<string> { "Mumbai", "Moscow", "Paris" };
        }
        public IEnumerable<string> GetStates(string id )
        {
            return new List<string> { "Karnata", "Telangana", "UP" };
        }
        [HttpPut]
        public void AddCity() { }
        public void DeleteCity() { }
        public void PostCity() { }
    }
}
