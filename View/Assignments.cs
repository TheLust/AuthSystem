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
    public partial class Assignments : Form
    {
        private AssignmentService assignmentService;
        private EmployeeService employeeService;
        private ProjectService projectService;

        public Assignments()
        {
            assignmentService = new AssignmentService();
            employeeService = new EmployeeService();
            projectService = new ProjectService();
            InitializeComponent();
            LoadCrud();
        }

        private void LoadCrud()
        {
            Crud<Assignment> crud = new Crud<Assignment>();
            crud.Fields = new List<string>()
            {
                "Employee",
                "Project"
            };
            crud.FieldConstraints = new Dictionary<string, ValidationConstraint>
            {
                {
                    "Employee",
                    new ValidationConstraint()
                    {
                        NotNull = true
                    }
                },
                {
                    "Project",
                    new ValidationConstraint()
                    {
                        NotNull = true
                    }
                }
            };
            crud.FindAllOperation = assignmentService.FindAll;
            crud.AddOperation = assignmentService.Add;
            crud.UpdateOperation = assignmentService.Update;
            crud.DeleteOperation = assignmentService.Remove;
            crud.AddField(employeeService.FindAll, "Id", "Account");
            crud.AddField(projectService.FindAll, "Id", "DisplayName");

            Controls.Add(crud);
        }
    }
}
