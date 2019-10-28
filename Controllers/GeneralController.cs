using Association_Managment.BL;
using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace Association_Managment.Controllers
{

    public class GeneralController : ApiController
    {
        public GeneralBL _GeneralBL = new GeneralBL();

        [Route("api/sendEmail")]
        [HttpGet ]
       public bool SendEmail()
        {
            SendEmailModel model = new SendEmailModel()
            {
                Body="checking",
                Subject="checking",                
            };
          return _GeneralBL.CreateMail(model);
        }

    }
}
