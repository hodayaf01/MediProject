using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.Models
{
    public class LogIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
           if((obj as LogIn).UserName==UserName&& (obj as LogIn).Password == Password)
                return true;
            return false;
        }
    }
}