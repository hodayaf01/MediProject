using Association_Managment.BL;
using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Association_Managment.Controllers
{
    public class TypeMeetingController : ApiController
    {
        public TypeMeetingBL _typeMeetingBL { get; set; }

        [Route("api/TypeMeeting/Get")]
        [HttpGet]
        public List<TypeMeeting> Get()
        {
            return _typeMeetingBL.Get();
        }

    }
}