using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Association_Managment.Models
{
    public class SendEmailModel
    {
         //parameters for send gmail
        public FileStream Pdf { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> MembersEmail { get; set; }

        public SendEmailModel(FileStream pdf, string subject, string body, List<string> membersEmail)
        {
            Pdf = pdf;
            Subject = subject;
            Body = body;
            MembersEmail = membersEmail;
        }
        public SendEmailModel()
        {

        }
    }
}