using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.DAL
{
    public class ProtocolsDAL
    {
        Association_ManagmentEntities DB = new Association_ManagmentEntities();
        public List<Protocol> Get()
        {
           return DB.Protocols.ToList();
        }

    }
}