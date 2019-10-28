using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Association_Managment.Controllers
{
    public class AssociationDetailsController : ApiController
    {
        public BL.AssociationDetailsBL _associationDetailsBL = new BL.AssociationDetailsBL();
        [Route("api/AssociationDetails/Get")]
        [HttpGet]
        public DetailsAssocition Get()
        {
            return _associationDetailsBL.Get();
        }
       
        [Route("api/AssociationDetails/AddOrEdit")]
        [HttpPost]
        public void AddOrEdit()
        {
            DetailsAssocition details = new DetailsAssocition();
            _associationDetailsBL.AddOrEdit(details);
        }
        [Route("api/AssociationDetails/Delete")]
        [HttpDelete]
        public void Delete()
        {
            _associationDetailsBL.Delete();
        }
        [Route("api/AssociationDetails/Login")]
        [HttpGet]
        public bool Login(string UserName, string PassWord)
        {
            LogIn lo = new LogIn()
            {
                UserName = UserName,
                Password = PassWord
            };
            return _associationDetailsBL.LogIn(lo);

        }

    }
}
