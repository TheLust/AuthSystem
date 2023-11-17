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
        private BonusService bonusService;
        private Account account;
        public MySalary(Account account)
        {
            sessionService = new SessionService();
            employeeService = new EmployeeService();
            wageService = new WageService();
            bonusService = new BonusService();
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
                                             grouped.Key.Year,
                                             grouped.Key.Month,
                                             grouped.Key.Project,
                                             Duration = grouped.Sum(s => (s.End - s.Start).Value.TotalHours)
                                         }).ToList();

            Employee employee;
            try
            {
                employee = employeeService.FindById(account.Id);
            } catch (Exception) 
            {
                MessageBox.Show("Please contact an admin to create you an employee account", "Error");
                this.Close();
                return;
            }

            var moneyFormProjects =  (from record in workedHoursAtProjects
                                      select new
                                      {
                                          record.Year,
                                          record.Month,
                                          record.Project,
                                          record.Duration,
                                          Earned = CalculateSalary(record.Duration, employee.JobId, record.Project.Id)
                                      }).ToList();
            Grid.DataSource = moneyFormProjects;

            var bonuses = (from bonus in bonusService.FindAll().Where(b => b.EmployeeId == account.Id).ToList()
                           select new
                           {
                               bonus.Type,
                               bonus.Amount,
                               bonus.Month,
                               bonus.Achievement
                           }).ToList();
            BonusGrid.DataSource = bonuses;

            var total = (from record in moneyFormProjects
                         group record by new { record.Year, record.Month } into grouped
                         select new
                         {
                             grouped.Key.Year,
                             grouped.Key.Month,
                             FromProjects =  grouped.Sum(s => s.Earned),
                             employee.Job.BaseSalary,
                             Bonus = bonuses.Sum(b =>
                             {
                                 if (b.Type.Equals("MONTHLY"))
                                 {
                                     return b.Amount;
                                 }
                                 else if (b.Type.Equals("PRIZE"))
                                 {
                                     if (b.Month.Value.Year == grouped.Key.Year && b.Month.Value.Month == grouped.Key.Month)
                                     {
                                         return b.Amount;
                                     }
                                 }

                                 return 0;
                             })
                         }).ToList();

            SalaryGrid.DataSource = (from gigel in total
                                     select new
                                     {
                                         gigel.Year,
                                         gigel.Month,
                                         gigel.FromProjects,
                                         gigel.BaseSalary,
                                         gigel.Bonus,
                                         Total = (gigel.FromProjects + gigel.BaseSalary + gigel.Bonus)
                                     }).ToList();
        }

        private void MySalary_Load(object sender, EventArgs e)
        {
            SetDataSource();
        }
    }
}
