using Association_Managment.DAL;
using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.BL
{
    public class AssociationDetailsBL
    {
        public AssociationDetailsDAL _associationDetailsDAL;

        public DetailsAssocition Get()
        {
            _associationDetailsDAL = new AssociationDetailsDAL();
            return _associationDetailsDAL.Get();
        }

        public void AddOrEdit(DetailsAssocition details)
        {
            if (details.id == 0)
            {
                _associationDetailsDAL.Add(details);
            }
            else
            {
                _associationDetailsDAL.Edit(details);
            }
        }

        public void Delete()
        {
            _associationDetailsDAL.Delete();
        }

        public bool LogIn(LogIn l)
        {
            LogIn log = new LogIn()
            {
                UserName = _associationDetailsDAL.Get().UserName,
                Password = _associationDetailsDAL.Get().Password
            };
            if (l.Equals(log))
                return true;
            return false;

        }
    }
}