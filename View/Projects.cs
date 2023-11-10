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
            crud.FindAllOperation = projectService.FindAll;
            crud.AddOperation = projectService.Add;
            crud.UpdateOperation = projectService.Update;
            crud.DeleteOperation = projectService.Remove;
            crud.HiddenFields = new List<string>() { "Id", "Assignments", "Wages" };
            crud.FieldsConstraints = new Dictionary<string, ValidationConstraint> {
                {
                    "Name",
                    new ValidationConstraint(
                        true,
                        false,
                        true,
                        true,
                        5,
                        100
                    )
                }
            };

            Controls.Add(crud);
        }

    }
}
