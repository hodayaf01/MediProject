using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Association_Managment.Controllers
{
    public class JobsController : ApiController
    {
        public BL.JobsBL _jobsBL { get; }
        [Route("api/Job/Get")]
        [HttpGet]
        public List<Job> Get()
        {
            return _jobsBL.Get();
        }
        [Route("api/Job/AddOrEdit")]
        public void AddOrEdit(Job job)
        {
            _jobsBL.AddOrEdit(job);
        }
         [Route("api/Job/Delete")]
        public void Delete(Job job)
        {
            _jobsBL.Delete(job);
        }

    }
}
