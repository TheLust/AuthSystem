using AuthSystem.Component;
using AuthSystem.Context;
using AuthSystem.Service;
using AuthSystem.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthSystem.View
{
    public partial class MyHub : Form
    {
        private SessionService sessionService;
        private AssignmentService assignmentService;
        private Account account;

        public MyHub(Account account)
        {
            sessionService = new SessionService();
            assignmentService = new AssignmentService();
            this.account = account;
            InitializeComponent();
        }

        private void MyHub_Load(object sender, EventArgs e)
        {
            SetDataSource();
            Grid.Columns["Id"].Visible = false;
            Grid.Columns["AssignmentId"].Visible = false;
            foreach (DataGridViewColumn item in Grid.Columns)
            {
                item.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            ComboField<Assignment> assignmentComboField = new ComboField<Assignment>(FindAccountAssignments, "Id", "Project");
            assignmentComboField.Name = "Assignment";
            assignmentComboField.Label = "Project";
            assignmentComboField.NotNull = true;
            AssignmentPanel.Controls.Add(assignmentComboField);
            assignmentComboField.Error = string.Empty;

            if (sessionService.FindSessionsByAccount(account).FirstOrDefault(s => s.End == null) != null)
            {
                StartButton.Visible = false;
                StopButton.Visible = true;
                AssignmentPanel.Enabled = false;
            }
            else
            {
                StartButton.Visible = true;
                StopButton.Visible = false;
                AssignmentPanel.Enabled = true;
            }
        }

        private List<Assignment> FindAccountAssignments()
        {
            return assignmentService.FindAll().Where(a => a.EmployeeId == account.Id).ToList();
        }

        private void SetDataSource()
        {
            Grid.DataSource = sessionService.FindSessionsByAccount(account).Where(s => s.Start.Date.CompareTo(CurrentDate.Value.Date) == 0).ToList();
        }

        private void CurrentDate_ValueChanged(object sender, EventArgs e)
        {
            SetDataSource();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                Session session = new Session()
                {
                    AssignmentId = Convert.ToInt32(GenericUtils.GetPropertyValue(AssignmentPanel.Controls["Assignment"], "FieldValue")),
                    Start = DateTime.Now,
                    End = null
                };

                sessionService.Add(session);
            } catch (ValidationException) {
                return;
            }

            SetDataSource();
            StartButton.Visible = false;
            StopButton.Visible = true;
            AssignmentPanel.Enabled = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Session session = sessionService.FindSessionsByAccount(account).FirstOrDefault(s => s.End == null);
            try
            {
                session.End = DateTime.Now;
                sessionService.Update(session.Id, session);
            } catch (Exception)
            {
                return;
            }

            SetDataSource();
            StartButton.Visible = true;
            StopButton.Visible = false;
            AssignmentPanel.Enabled = true;
        }
    }
}
