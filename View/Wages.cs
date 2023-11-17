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
    public partial class Wages : Form
    {
        private WageService wageService;
        private JobService jobService;
        private ProjectService projectService;

        public Wages()
        {
            wageService = new WageService();
            jobService = new JobService();
            projectService = new ProjectService();
            InitializeComponent();
            LoadCrud();
        }

        private void LoadCrud()
        {
            Crud<Wage> crud = new Crud<Wage>();
            crud.Fields = new List<string>()
            {
                "Job",
                "Project",
                "Amount"
            };
            crud.FieldConstraints = new Dictionary<string, ValidationConstraint>
            {
                {
                    "Job",
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
                },
                {
                    "Amount",
                    new ValidationConstraint()
                    {
                        Min = 0,
                        Max = 100
                    }
                }
            };
            crud.FindAllOperation = wageService.FindAll;
            crud.AddOperation = wageService.Add;
            crud.UpdateOperation = wageService.Update;
            crud.DeleteOperation = wageService.Remove;
            crud.AddField(jobService.FindAll, "Id", "DisplayName");
            crud.AddField(projectService.FindAll, "Id", "Name");

            Controls.Add(crud);
        }
    }
}
