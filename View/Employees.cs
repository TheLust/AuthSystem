using AuthSystem.Component;
using AuthSystem.Context;
using AuthSystem.Service;
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

        public Employees()
        {
            employeeService = new EmployeeService();
            InitializeComponent();
            LoadCrud();
        }

        private void LoadCrud()
        {
            Crud<Employee> crud = new Crud<Employee>();
            crud.FindAllOperation = employeeService.FindAll;
            crud.HiddenFields = new List<string>() { "Id", "JobId", "Assignments", "ExtraPayments" };
            Controls.Add(crud);
        }
    }
}
