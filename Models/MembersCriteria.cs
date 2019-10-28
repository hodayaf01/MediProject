using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.Models
{
    public class MembersCriteria
    {
        public string NameMember { get; set; }
        public string IdMember { get; set; }
        public Boolean? TypeMember { get; set; }
        public Boolean? AllowedSignature { get; set; }
        public string MailMember { get; set; }
        public DateTime? Joindate { get; set; }
        public DateTime? Exitdate { get; set; }
    }
}