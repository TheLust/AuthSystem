using AuthSystem.Component;
using AuthSystem.Context;
using AuthSystem.Service;
using AuthSystem.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthSystem.View
{
    public partial class Employees : Form
    {
        private EmployeeService employeeService;
        private AccountService accountService;
        private JobService jobService;

        public Employees()
        {
            employeeService = new EmployeeService();
            accountService = new AccountService();
            jobService = new JobService();
            InitializeComponent();
            LoadCrud();
        }

        private void LoadCrud()
        {
            Crud<Employee> crud = new Crud<Employee>();
            crud.Fields = new Dictionary<string, string>
            {
                { "Account", "Username" },
                { "Job", "DisplayName" }
            };
            crud.FieldReferences = new Dictionary<string, string>
            {
                { "Account", "Id" }
            };
            crud.FieldConstraints = new Dictionary<string, ValidationConstraint>
            {
                {
                    "Account", 
                    new ValidationConstraint()
                    {
                        NotNull = true,
                        Unique = true
                    }
                },
                {
                    "Job", 
                    new ValidationConstraint()
                    {
                        NotNull = true
                    }
                }
            };
            crud.FindAllOperation = employeeService.FindAll;
            crud.AddOperation = employeeService.Add;
            crud.UpdateOperation = employeeService.Update;
            crud.DeleteOperation = employeeService.Remove;
            crud.AddField(accountService.FindAll, "Id", "Username");
            crud.AddField(jobService.FindAll, "Id", "DisplayName");

            Controls.Add(crud);
        }
    }
}
