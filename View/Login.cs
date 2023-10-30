using AuthSystem.Context;
using AuthSystem.Facade;
using AuthSystem.Util.Constants;
using AuthSystem.View;
using System;
using System.Windows.Forms;

namespace AuthSystem
{
    public partial class LoginView : Form
    {

        private AuthFacade authFacade;

        public LoginView()
        {
            authFacade = new AuthFacade();
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Username = UsernameTextBox.Text;
            account.Password = PasswordTextBox.Text;

            if (!ValidateAccount(account))
            {
                return;
            }

            try
            {
                account = authFacade.Login(account);
            } catch (Exception ex)
            {
                UsernameError.Text = ex.Message;
                PasswordError.Text = ex.Message;
                return;
            }

            Home home = new Home(account);
            Hide();
            home.ShowDialog();
            Close();
        }

        private bool ValidateAccount(Account account)
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(account.Username))
            {
                UsernameError.Text = AppConstant.GetExceptionMessage("Username", AppConstant.NOT_BLANK);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(account.Password))
            {
                PasswordError.Text = AppConstant.GetExceptionMessage("Password", AppConstant.NOT_BLANK);
                valid = false;
            }

            return valid;
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            UsernameError.Text = string.Empty;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordError.Text = string.Empty;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Hide();
            Register register = new Register();
            register.ShowDialog();
            Show();
        }
    }
}
