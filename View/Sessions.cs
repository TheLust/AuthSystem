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
    public partial class Sessions : Form
    {
        private SessionService sessionService;
        private AssignmentService assignmentService;

        public Sessions()
        {
            sessionService = new SessionService();
            assignmentService = new AssignmentService();
            InitializeComponent();
            LoadCrud();
        }

        private void LoadCrud()
        {
            Crud<Session> crud = new Crud<Session>();
            crud.Fields = new List<string>()
            {
                "Assignment",
                "Start",
                "End"
            };

            crud.FieldConstraints = new Dictionary<string, ValidationConstraint>
            {
                {
                    "Assignment",
                    new ValidationConstraint()
                    {
                        NotNull = true
                    }
                },
                {
                    "Start",
                    new ValidationConstraint()
                    {
                        PastOrPresent = true
                    }
                },
                {
                    "End",
                    new ValidationConstraint()
                    {
                        PastOrPresent = true,
                        IsLaterThan = "Start"
                    }
                }
            };

            crud.FindAllOperation = sessionService.FindAll;
            crud.AddOperation = sessionService.Add;
            crud.UpdateOperation = sessionService.Update;
            crud.DeleteOperation = sessionService.Remove;

            crud.AddField(assignmentService.FindAll, "Id", "DisplayName");

            Controls.Add(crud);
        }
    }
}
