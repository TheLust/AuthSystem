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
    public partial class MySalary : Form
    {
        private SessionService sessionService;
        private EmployeeService employeeService;
        private WageService wageService;
        private Account account;
        public MySalary(Account account)
        {
            sessionService = new SessionService();
            employeeService = new EmployeeService();
            wageService = new WageService();
            this.account = account;
            InitializeComponent();
        }

        private Wage FindWage(int jobId, int projectId)
        {
            var wage = wageService.FindAll().FirstOrDefault(w => w.JobId == jobId && w.ProjectId == projectId);

            return wage != null ? wage : wageService.FindAllIncludingDefaults().FirstOrDefault(w => w.JobId == jobId && w.ProjectId is null);
        }

        private double CalculateSalary(double hours, int jobId, int projectId)
        {
            var wage = FindWage(jobId, projectId);
            return hours * wage.Amount;
        }

        private void SetDataSource()
        {
            var workedHoursAtProjects = (from session in sessionService.FindSessionsByAccount(account).Where(s => s.End != null).ToList()
                                         group session by new { session.Start.Year, session.Start.Month, session.Assignment.Project } into grouped
                                         select new
                                         {
                                             Year = grouped.Key.Year,
                                             Month = grouped.Key.Month,
                                             Project = grouped.Key.Project,
                                             Duration = grouped.Sum(s => (s.End - s.Start).Value.TotalHours)
                                         }).ToList();

            Employee employee = employeeService.FindById(account.Id);

            Grid.DataSource = (from record in workedHoursAtProjects
                               select new
                               {
                                   record.Year,
                                   record.Month,
                                   record.Project,
                                   record.Duration,
                                   Earned = CalculateSalary(record.Duration, employee.JobId, record.Project.Id)
                               }).ToList();
        }

        private void MySalary_Load(object sender, EventArgs e)
        {
            SetDataSource();
        }
    }
}
