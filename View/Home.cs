using AuthSystem.Context;
using AuthSystem.Util.Constants;
using System.Windows.Forms;
using System.Drawing;

namespace AuthSystem.View
{
    public partial class Home : Form
    {

        private Account account;

        public Home(Account account)
        {
            this.account = account;
            InitializeComponent();
            WelcomeMessage.Text = AppConstant.WELCOME + account.FirstName;

            if (account.Role1.Name.Equals("Admin"))
            {
                ToolStripItem adminLink = Menu.Items.Add("Admin");
                adminLink.Click += AdminLink_Click;
            }

            ToolStripItem myAccount = Menu.Items.Add("My Account");
            myAccount.Click += MyAccount_Click;
        }

        private void MyAccount_Click(object sender, System.EventArgs e)
        {
            MyAccount myAccount = new MyAccount(account);
            Hide();
            myAccount.ShowDialog();
            Show();
        }

        private void AdminLink_Click(object sender, System.EventArgs e)
        {
            Admin adminView = new Admin();
            Hide();
            adminView.ShowDialog();
            Show();
        }

        private void MenuButton_Click(object sender, System.EventArgs e)
        {
            Menu.Show(PointToScreen(new Point(0, 0)));
        }
    }
}
