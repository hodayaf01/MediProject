using System;
using Association_Managment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.DAL
{
    public class AssociationDetailsDAL
    {
        Association_ManagmentEntities DB = new Association_ManagmentEntities();


        public DetailsAssocition Get()
        {
            var res = DB.DetailsAssocitions.ToList().FirstOrDefault();
            res = (res == null ? new DetailsAssocition() : res);
            return res;
        }

        public void Add(DetailsAssocition details)
        {
            DB.DetailsAssocitions.Add(details);
            DB.SaveChanges();
        }

        public void Edit(DetailsAssocition details)
        {
            DB.Entry(details);
            DB.SaveChanges();
        }
        public void Delete()
        {
            DB.DetailsAssocitions.First().DeleteRow = false;
        }
        
        
    }
}