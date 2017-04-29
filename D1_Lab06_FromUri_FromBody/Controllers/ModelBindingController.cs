using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using D1_Lab06_FromUri_FromBody.Models;

namespace D1_Lab06_FromUri_FromBody.Controllers
{
    public class ModelBindingController : ApiController
    {
        public IHttpActionResult Get([FromUri] GeoPoint location)
        {
            if (location.Latitude == 0 || location.Longitude == 0)
            {
                return BadRequest("Location is empty!");
            }
            var geo = $"Latitude:{location.Latitude},Longitude:{location.Longitude}";
            return Ok(geo);
        }

        public IHttpActionResult Post([FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name is empty!");
            }
            var hello = "Hello " + name;
            return Ok(hello);
        }
    }
}
