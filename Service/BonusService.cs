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
    public class BonusService
    {
        private AuthSystemEntities context;

        public BonusService()
        {
            context = new AuthSystemEntities();
        }

        public List<ExtraPayment> FindAll()
        {
            return context.ExtraPayments.Include(e => e.Employee).ToList();
        }

        public ExtraPayment FindById(int id)
        {
            ExtraPayment extraPayment = context.ExtraPayments.Find(id);

            if (extraPayment == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("ExtraPayment", "id", AppConstant.NOT_FOUND));
            }

            return extraPayment;
        }

        public void Add(ExtraPayment extraPayment)
        {
            if (extraPayment.Type.Equals("MONTHLY"))
            {
                extraPayment.Achievement = null;
                extraPayment.Month = null;
            }

            if (extraPayment.Type.Equals("PRIZE"))
            {
                if (string.IsNullOrWhiteSpace(extraPayment.Achievement))
                {
                    throw new MissingFieldException("Achievement is required for this type of bonus");
                }
            }

            context.ExtraPayments.Add(extraPayment);
            context.SaveChanges();
        }

        public void Update(int id, ExtraPayment extraPayment)
        {
            var existingExtraPayment = context.ExtraPayments.Find(id);

            if (extraPayment == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("ExtraPayment", "id", AppConstant.NOT_FOUND));
            }

            existingExtraPayment.Amount = extraPayment.Amount;
            existingExtraPayment.Type = extraPayment.Type;
            existingExtraPayment.Month = extraPayment.Month;
            existingExtraPayment.Achievement = extraPayment.Achievement;
            existingExtraPayment.EmployeeId = extraPayment.EmployeeId;

            context.SaveChanges();
        }

        public void Remove(ExtraPayment extraPayment)
        {
            extraPayment = context.ExtraPayments.Find(extraPayment.Id);

            if (extraPayment == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("ExtraPayment", "id", AppConstant.NOT_FOUND));
            }

            context.ExtraPayments.Remove(extraPayment);
            context.SaveChanges();
        }
    }
}
