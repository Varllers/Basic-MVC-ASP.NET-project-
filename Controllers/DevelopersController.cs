using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab2clis.Models;
using Lab2clis.dataSource;

namespace Lab2clis.Controllers
{
    public class DevelopersController : ApiController
    {
        [HttpGet]
        public Developer[] Get()
        {
            var alldevelopers = Repository.Get();

            return alldevelopers;
        }

        [HttpGet]
        public Developer Get(int id)
        {
            var developer = Repository.Get(id);

            return developer;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Repository.Delete(id);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult PUT(int id, [FromBody]Developer student)
        {
            Repository.Update(id, student);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult POST([FromBody]Developer student)
        {
            Repository.Add(student);

            return Ok();
        }
    }
}
