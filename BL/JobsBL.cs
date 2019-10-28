using Association_Managment.DAL;
using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.BL
{
    public class JobsBL
    {
    public JobsDAL _jobsDAL { get; }

    public List<Job> Get()
       {
            return _jobsDAL.Get();
       }

    public void AddOrEdit(Job job)
        {
            if(job.CodeJob==0)
            {
                _jobsDAL.Add(job);
            }
            else
            {
                _jobsDAL.Edit(job);
            }
        }

        public void Delete(Job job)
        {
            _jobsDAL.Delete(job);
        }
    }

    
}