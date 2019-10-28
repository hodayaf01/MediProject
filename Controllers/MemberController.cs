using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web.Http;

using Excel = Microsoft.Office.Interop.Excel;


namespace Association_Managment.Controllers
{
    public class MemberController : ApiController
    {
        public BL.MembersBL _memberBL = new BL.MembersBL();
        [Route("api/Members/Get")]
        [HttpGet]
        public List<Member> Get(string IdMember)
        {
            return _memberBL.Get(new List<long>());
        }

        [Route("api/Members/GetByCriteria")]
        [HttpGet]
        public List<Member> GetByCriteria(string nameMember = null, string idMember = null, Boolean? typeMember = null, Boolean? allowedSignature = null, string mailMember = null, DateTime? joindate = null, DateTime? exitdate = null)
        {
            MembersCriteria membersCriteria = new MembersCriteria()
            {
                NameMember = nameMember,
                AllowedSignature = allowedSignature,
                Exitdate = exitdate,
                IdMember = idMember,
                Joindate = joindate,
                MailMember = mailMember,
                TypeMember = typeMember
            };
            return _memberBL.Get(membersCriteria);
        }

        [HttpPost]
        [Route("api/Members/AddOrEdit")]
        public void AddOrEdit(Member newMember)
        {
            _memberBL.AddOrEditMember(newMember);
        }

        [HttpGet]
        [Route("api/Members/ExportMembers")]
        public HttpResponseMessage exportMembers(string nameMember = null, string idMember = null, Boolean? typeMember = null, Boolean? allowedSignature = null, string mailMember = null, DateTime? joindate = null, DateTime? exitdate = null)//report of amuta members
        {
            MembersCriteria criteria = new MembersCriteria()
            {
                NameMember = nameMember,
                AllowedSignature = allowedSignature,
                Exitdate = exitdate,
                IdMember = idMember,
                Joindate = joindate,
                MailMember = mailMember,
                TypeMember = typeMember
            };
            return _memberBL.ExportMembers(criteria);
        }
        [HttpGet]
        [Route("api/Members/ExportMember")]
        public HttpResponseMessage ExportMember(int codeMember)//report of Member card
        {
            return _memberBL.ExportMember(codeMember);
        }


        [HttpPost]
        public void UpdateExitMember(long id, DateTime ed)
        {
            // BL.UpdateExitMember(id, ed);
        }


       //chedva winner
        
        public MemberController()
        {
                
        }
    
    }
}

