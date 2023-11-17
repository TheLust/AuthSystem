using AuthSystem.Context;
using AuthSystem.Security;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSystem.Service
{
    public class WageService
    {
        private AuthSystemEntities context;

        public WageService()
        {
            context = new AuthSystemEntities();
        }

        public List<Wage> FindAllIncludingDefaults()
        {
            return context.Wages.Include(e => e.Job).Include(e => e.Project).ToList();
        }

        public List<Wage> FindAll()
        {
            return context.Wages.Include(e => e.Job).Include(e => e.Project).Where(w => w.ProjectId != null).ToList();
        }

        public Wage FindById(int id)
        {
            Wage wage = context.Wages.Find(id);

            if (wage == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Wage", "id", AppConstant.NOT_FOUND));
            }

            return wage;
        }

        public void Add(Wage wage)
        {
            context.Wages.Add(wage);
            context.SaveChanges();
        }

        public void Update(int id, Wage wage)
        {
            var existingWage = context.Wages.Find(id);

            if (existingWage == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Wage", "id", AppConstant.NOT_FOUND));
            }

            existingWage.JobId = wage.JobId;
            existingWage.ProjectId = wage.ProjectId;
            existingWage.Amount = wage.Amount;

            context.SaveChanges();
        }

        public void Remove(Wage wage)
        {
            wage = context.Wages.Find(wage.Id);

            if (wage == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Wage", "id", AppConstant.NOT_FOUND));
            }

            context.Wages.Remove(wage);
            context.SaveChanges();
        }
    }
}
