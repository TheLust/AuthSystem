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
    public class AssignmentService
    {
        private AuthSystemEntities context;

        public AssignmentService()
        {
            context = new AuthSystemEntities();
        }

        public List<Assignment> FindAll()
        {
            return context.Assignments.Include(e => e.Employee).Include(e => e.Project).ToList();
        }

        public Assignment FindById(int id)
        {
            Assignment assignment = context.Assignments.Find(id);

            if (assignment == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Assignment", "id", AppConstant.NOT_FOUND));
            }

            return assignment;
        }

        public void Add(Assignment assignment)
        {
            context.Assignments.Add(assignment);
            context.SaveChanges();
        }

        public void Update(int id, Assignment assignment)
        {
            var existingAssignment = context.Assignments.Find(id);

            if (existingAssignment == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Assignment", "id", AppConstant.NOT_FOUND));
            }

            existingAssignment.EmployeeId = assignment.EmployeeId;
            existingAssignment.ProjectId = assignment.ProjectId;
            context.SaveChanges();
        }

        public void Remove(Assignment assignment)
        {
            assignment = context.Assignments.Find(assignment.Id);

            if (assignment == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Assignment", "id", AppConstant.NOT_FOUND));
            }

            context.Assignments.Remove(assignment);
            context.SaveChanges();
        }
    }
}
