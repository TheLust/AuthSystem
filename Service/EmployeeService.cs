using AuthSystem.Context;
using AuthSystem.Security;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSystem.Service
{
    public class EmployeeService
    {
        private AuthSystemEntities context;

        public EmployeeService()
        {
            context = new AuthSystemEntities();
        }

        public List<Employee> FindAll()
        {
            return context.Employees.ToList();
        }

        public Employee FindById(int id)
        {
            Employee employee = context.Employees.Find(id);

            if (employee == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Employee", "id", AppConstant.NOT_FOUND));
            }

            return employee;
        }

        public void Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Update(int id, Employee employee)
        {
            var existingEmployee = context.Employees.Find(id);

            if (existingEmployee == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Employee", "id", AppConstant.NOT_FOUND));
            }

            existingEmployee.JobId = employee.JobId;
            context.SaveChanges();
        }

        public void Remove(Employee employee)
        {
            employee = context.Employees.Find(employee.Id);

            if (employee == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Employee", "id", AppConstant.NOT_FOUND));
            }

            context.Employees.Remove(employee);
            context.SaveChanges();
        }
    }
}
