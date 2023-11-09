using AuthSystem.Context;
using AuthSystem.Facade;
using AuthSystem.Util.Constants;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AuthSystem.View
{
    public partial class Register : Form
    {
        private AuthFacade authFacade;

        public Register()
        {
            authFacade = new AuthFacade();
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Account account = new Account()
            {
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Email = EmailTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text
            };

            if (!ValidateAccount(account))
            {
                return;
            }

            try
            {
                authFacade.Register(account);
            } catch (Exception)
            {
                return;
            }

            Close();
        }

        private bool ValidateAccount(Account account)
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(account.Username))
            {
                UsernameError.Text = AppConstant.GetExceptionMessage(AppConstant.USERNAME, AppConstant.NOT_BLANK);
                valid = false;
            }
            else if (authFacade.UsernameExists(account.Username))
            {
                UsernameError.Text = AppConstant.GetExceptionMessage(AppConstant.ACCOUNT.Item1, AppConstant.USERNAME, AppConstant.ALREADY_EXISTS);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(account.Password))
            {
                PasswordError.Text = AppConstant.GetExceptionMessage(AppConstant.PASSWORD, AppConstant.NOT_BLANK);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(account.FirstName))
            {
                FirstNameError.Text = AppConstant.GetExceptionMessage(AppConstant.FIRST_NAME, AppConstant.NOT_BLANK);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(account.LastName))
            {
                LastNameError.Text = AppConstant.GetExceptionMessage(AppConstant.LAST_NAME, AppConstant.NOT_BLANK);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(account.Email))
            {
                EmailError.Text = AppConstant.GetExceptionMessage(AppConstant.EMAIL, AppConstant.NOT_BLANK);
                valid = false;
            }
            else if (authFacade.EmailExists(account.Email))
            {
                EmailError.Text = AppConstant.GetExceptionMessage(AppConstant.ACCOUNT.Item1, AppConstant.EMAIL, AppConstant.ALREADY_EXISTS);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(account.PhoneNumber))
            {
                PhoneNumberError.Text = AppConstant.GetExceptionMessage(AppConstant.PHONE_NUMBER, AppConstant.NOT_BLANK);
                valid = false;
            }
            else if (authFacade.PhoneNumberExists(account.PhoneNumber))
            {
                PhoneNumberError.Text = AppConstant.GetExceptionMessage(AppConstant.ACCOUNT.Item1, AppConstant.PHONE_NUMBER, AppConstant.ALREADY_EXISTS);
                valid = false;
            }

            if (!PrivacyPolicyCheckBox.Checked)
            {
                PrivacyPolicyError.Text = AppConstant.PRIVACY_POLICY_MESSAGE;
                valid = false;
            }

            return valid;
        }

        private void PrivacyPolicyLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://s.yimg.com/ny/api/res/1.2/3G214Kmm_v_0WS9in0RjFg--/YXBwaWQ9aGlnaGxhbmRlcjt3PTY0MDtoPTQyNg--/https://media.zenfs.com/en_us/News/digitaltrends.com/you-mad-bro-625x416.png");
        }

        private void PrivacyPolicyLabel_MouseHover(object sender, EventArgs e)
        {
            PrivacyPolicyLabel.ForeColor = Color.Blue;
        }

        private void PrivacyPolicyLabel_MouseLeave(object sender, EventArgs e)
        {
            PrivacyPolicyLabel.ForeColor = Color.Black;
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            UsernameError.Text = string.Empty;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordError.Text = string.Empty;
        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FirstNameError.Text = string.Empty;
        }

        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            LastNameError.Text = string.Empty;
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            EmailError.Text = string.Empty;
        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            PhoneNumberError.Text = string.Empty;
        }

        private void PrivacyPolicyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PrivacyPolicyError.Text = string.Empty;
        }
    }
}
