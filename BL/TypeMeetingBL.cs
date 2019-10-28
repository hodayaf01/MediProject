using Association_Managment.DAL;
using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.BL
{
    public class TypeMeetingBL
    {
        public TypeMeetingDAL _typeMeetingDAL { get; }

        public List<TypeMeeting> Get()
        {
            return _typeMeetingDAL.Get();
        }
    }
}