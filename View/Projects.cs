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
    public partial class Projects : Form
    {
        private ProjectService projectService;

        public Projects()
        {
            projectService = new ProjectService();
            InitializeComponent();
            LoadCrud();
        }
        private void LoadCrud()
        {
            Crud<Project> crud = new Crud<Project>();
            crud.Fields = new List<string>()
            {
                "Name"
            };

            crud.FieldConstraints = new Dictionary<string, ValidationConstraint>
            {
                {
                    "Name",
                    new ValidationConstraint()
                    {
                        Unique = true,
                        NotBlank = true,
                        Length = true,
                        Min = 5,
                        Max = 30
                    }
                }
            };
            crud.FindAllOperation = projectService.FindAll;
            crud.AddOperation = projectService.Add;
            crud.UpdateOperation = projectService.Update;
            crud.DeleteOperation = projectService.Remove;

            Controls.Add(crud);
        }
    }
}
