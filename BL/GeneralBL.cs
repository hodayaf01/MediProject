using Association_Managment.DAL;
using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Association_Managment.BL
{
    public class GeneralBL
    {
        public GeneralDAL generalDAL { get; }
        public  BL.MembersBL _membersBL { get; }

        public bool CreateMail(SendEmailModel model)
        {
            //שליחת מייל


            MessageGmail mg = new MessageGmail();
            mg.Body = model.Body;
            mg.Subject = model.Subject;

            model.MembersEmail.ForEach(m => mg.ToList.Add(m, m));


            return SendMail.SendEMail(mg);

    
        }
    

    }
}