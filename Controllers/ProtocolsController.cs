using Association_Managment.BL;
using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Association_Managment.Controllers
{
    public class ProtocolsController : ApiController
    {
        public ProtocolsBL _protocolsBL = new ProtocolsBL();
        [Route("api/Protocol/Get")]
        [HttpGet]
        public List<Protocol> Get()
        {
           return _protocolsBL.Get();
        }

        public class ch { public string name { get; set; }}
        [Route("api/Protocol/Create")]
        [HttpPost]
        public string Create(ch p)
        {
            return _protocolsBL.Create(null);
        }
    }
}
