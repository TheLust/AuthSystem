using AuthSystem.Context;
using AuthSystem.Util.Constants;
using System.Windows.Forms;
using System.Drawing;

namespace AuthSystem.View
{
    public partial class Home : Form
    {

        private static Account account;

        public Home(Account account)
        {
            Home.account = account;
            InitializeComponent();
            WelcomeMessage.Text = AppConstant.WELCOME + account.FirstName;

            if (account.Role.Name.Equals("Admin"))
            {
                ToolStripMenuItem adminLink = new ToolStripMenuItem(AppConstant.ADMIN);
                ToolStripItem accountLink = adminLink.DropDownItems.Add(AppConstant.ACCOUNT.Item2);
                accountLink.Click += AccountLink_Click;
                ToolStripItem employeeLink = adminLink.DropDownItems.Add(AppConstant.EMPLOYEE.Item2);
                employeeLink.Click += EmployeeLink_Click;
                ToolStripItem projectLink = adminLink.DropDownItems.Add(AppConstant.PROJECT.Item2);
                projectLink.Click += ProjectLink_Click;
                ToolStripItem jobLink = adminLink.DropDownItems.Add(AppConstant.JOB.Item2);
                jobLink.Click += JobLink_Click;
                ToolStripItem assignmentLink = adminLink.DropDownItems.Add(AppConstant.ASSIGNEMNT.Item2);
                assignmentLink.Click += AssignmentLink_Click;
                ToolStripItem wageLink = adminLink.DropDownItems.Add(AppConstant.WAGE.Item2);
                wageLink.Click += WageLink_Click;
                ToolStripItem bonusLink = adminLink.DropDownItems.Add(AppConstant.BONUS.Item2);
                bonusLink.Click += BonusLink_Click;
                ToolStripItem sessionLink = adminLink.DropDownItems.Add(AppConstant.SESSION.Item2);
                sessionLink.Click += SessionLink_Click;
                Menu.Items.Add(adminLink);
            }

            ToolStripItem myAccount = Menu.Items.Add(AppConstant.MY_ACCOUNT);
            myAccount.Click += MyAccount_Click;

            ToolStripItem myHub = Menu.Items.Add(AppConstant.SESSION.Item2);
            myHub.Click += MyHubLink_Click;
        }

        private void MyHubLink_Click(object sender, System.EventArgs e)
        {
            MyHub myHubView = new MyHub(account);
            Hide();
            myHubView.ShowDialog();
            Show();
        }

        private void SessionLink_Click(object sender, System.EventArgs e)
        {
            Sessions sessionView = new Sessions();
            Hide();
            sessionView.ShowDialog();
            Show();
        }

        private void BonusLink_Click(object sender, System.EventArgs e)
        {
            Bonuses bonusView = new Bonuses();
            Hide();
            bonusView.ShowDialog();
            Show();
        }

        private void WageLink_Click(object sender, System.EventArgs e)
        {
            Wages wageView = new Wages();
            Hide();
            wageView.ShowDialog();
            Show();
        }

        private void AssignmentLink_Click(object sender, System.EventArgs e)
        {
            Assignments assignmentView = new Assignments();
            Hide();
            assignmentView.ShowDialog();
            Show();
        }

        private void JobLink_Click(object sender, System.EventArgs e)
        {
            Jobs jobView = new Jobs();
            Hide();
            jobView.ShowDialog();
            Show();
        }

        private void ProjectLink_Click(object sender, System.EventArgs e)
        {
            Projects projectView = new Projects();
            Hide();
            projectView.ShowDialog();
            Show();
        }

        private void EmployeeLink_Click(object sender, System.EventArgs e)
        {
            Employees employeeView = new Employees();
            Hide();
            employeeView.ShowDialog();
            Show();
        }

        private void AccountLink_Click(object sender, System.EventArgs e)
        {
            Accounts accountView = new Accounts();
            Hide();
            accountView.ShowDialog();
            Show();
        }

        private void MyAccount_Click(object sender, System.EventArgs e)
        {
            MyAccount myAccount = new MyAccount(account);
            Hide();
            myAccount.ShowDialog();
            Show();
        }

        private void MenuButton_Click(object sender, System.EventArgs e)
        {
            Menu.Show(PointToScreen(new Point(0, 0)));
        }

        public static void SetAccount(Account account)
        {
            Home.account = account;
        }
    }
}
