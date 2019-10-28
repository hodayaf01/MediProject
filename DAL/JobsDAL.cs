using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.DAL
{
    public class JobsDAL
    {
        Association_ManagmentEntities DB = new Association_ManagmentEntities();

        public List<Job> Get()
        {
            return DB.Jobs.ToList();
        }

        public void Add(Job job)
        {
            DB.Jobs.Add(job);
            DB.SaveChanges();
        }

        public void Edit(Job job)
        {
            DB.Jobs.ToList().Find(j => j.CodeJob == job.CodeJob).NameJob=job.NameJob;
            DB.SaveChanges();
        }

        public void Delete(Job job)
        {
            DB.Jobs.ToList().Find(j => j.CodeJob == job.CodeJob).DeleteRow = false;
        }
    }
}