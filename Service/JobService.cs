using AuthSystem.Context;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSystem.Service
{
    public class JobService
    {
        private AuthSystemEntities context;

        public JobService()
        {
            context = new AuthSystemEntities();
        }

        public List<Job> FindAll()
        {
            return context.Jobs.ToList();
        }

        public Job FindById(int id)
        {
            Job job = context.Jobs.Find(id);
            return job == null ? throw new Exception(AppConstant.GetExceptionMessage("Employee", "id", AppConstant.NOT_FOUND)) : job;
        }

        public void Add(Job job)
        {
            context.Jobs.Add(job);
            context.SaveChanges();
        }

        public void Update(int id, Job job)
        {
            var existingJob = context.Jobs.Find(id) ?? throw new Exception(AppConstant.GetExceptionMessage("Job", "id", AppConstant.NOT_FOUND));
            existingJob.Name = job.Name;
            existingJob.Rank = job.Rank;
            existingJob.BaseSalary = job.BaseSalary;
            context.SaveChanges();
        }

        public void Remove(Job job)
        {
            job = context.Jobs.Find(job.Id) ?? throw new Exception(AppConstant.GetExceptionMessage("Job", "id", AppConstant.NOT_FOUND));
            context.Jobs.Remove(job);
            context.SaveChanges();
        }
    }
}
