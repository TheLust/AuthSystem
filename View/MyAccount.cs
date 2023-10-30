using AuthSystem.Context;
using AuthSystem.Util.Constants;
using System;
using System.Windows.Forms;

namespace AuthSystem.View
{
    public partial class MyAccount : Form
    {
        private Account account;

        private AccountService accountService;

        public MyAccount(Account account)
        {
            accountService = new AccountService();
            this.account = account;
            InitializeComponent();
            FillForm();
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateMode(true);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Account newAccount = CollectData();
            if (!ValidateAccount(newAccount))
            {
                return;
            }

            accountService.Update(account.Id, newAccount);
            account = accountService.FindById(account.Id);
            FillForm();
            UpdateMode(false);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            FillForm();
            UpdateMode(false);
        }

        private void UpdateMode(bool updateMode)
        {
            if (updateMode)
            {
                UsernameTextBox.Enabled = true;
                PasswordTextBox.Enabled = true;
                FirstNameTextBox.Enabled = true;
                LastNameTextBox.Enabled = true;
                EmailTextBox.Enabled = true;
                PhoneNumberTextBox.Enabled = true;
                UpdateButton.Hide();
                SaveButton.Show();
                CancelButton.Show();
            }
            else
            {
                UsernameTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
                FirstNameTextBox.Enabled = false;
                LastNameTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                PhoneNumberTextBox.Enabled = false;
                UpdateButton.Show();
                SaveButton.Hide();
                CancelButton.Hide();
            }
        }

        private void FillForm()
        {
            UsernameTextBox.Text = account.Username;
            PasswordTextBox.Text = account.Password;
            FirstNameTextBox.Text = account.FirstName;
            LastNameTextBox.Text = account.LastName;
            EmailTextBox.Text = account.Email;
            PhoneNumberTextBox.Text = account.PhoneNumber;
        }

        private Account CollectData()
        {
            Account newAccount = new Account();

            newAccount.Username = UsernameTextBox.Text;
            newAccount.Password = PasswordTextBox.Text;
            newAccount.FirstName = FirstNameTextBox.Text;
            newAccount.LastName = LastNameTextBox.Text;
            newAccount.Email = EmailTextBox.Text;
            newAccount.PhoneNumber = PhoneNumberTextBox.Text;

            return newAccount;
        }

        private bool ValidateAccount(Account newAccount)
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(newAccount.Username))
            {
                UsernameError.Text = AppConstant.GetExceptionMessage("Username", AppConstant.NOT_BLANK);
                valid = false;
            } else
            {
                try
                {
                    if (account.Id != accountService.FindByUsername(newAccount.Username).Id)
                    {
                        UsernameError.Text = AppConstant.GetExceptionMessage("Account", "username", AppConstant.ALREADY_EXISTS);
                        valid = false;
                    }
                } catch{}
            }

            if (string.IsNullOrWhiteSpace(newAccount.Password))
            {
                PasswordError.Text = AppConstant.GetExceptionMessage("Password", AppConstant.NOT_BLANK);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(newAccount.FirstName))
            {
                FirstNameError.Text = AppConstant.GetExceptionMessage("First name", AppConstant.NOT_BLANK);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(newAccount.LastName))
            {
                LastNameError.Text = AppConstant.GetExceptionMessage("Last name", AppConstant.NOT_BLANK);
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(newAccount.Email))
            {
                EmailError.Text = AppConstant.GetExceptionMessage("Email", AppConstant.NOT_BLANK);
                valid = false;
            }
            else
            {
                try
                {
                    if (account.Id != accountService.FindByEmail(newAccount.Email).Id)
                    {
                        EmailError.Text = AppConstant.GetExceptionMessage("Account", "email", AppConstant.ALREADY_EXISTS);
                        valid = false;
                    }
                }
                catch{}
            }

            if (string.IsNullOrWhiteSpace(newAccount.PhoneNumber))
            {
                PhoneNumberError.Text = AppConstant.GetExceptionMessage("Phone number", AppConstant.NOT_BLANK);
                valid = false;
            }
            else
            {
                try
                {
                    if (account.Id != accountService.FindByPhoneNumber(newAccount.PhoneNumber).Id)
                    {
                        PhoneNumberError.Text = AppConstant.GetExceptionMessage("Account", "phone number", AppConstant.ALREADY_EXISTS);
                        valid = false;
                    }
                }
                catch{}
            }

            return valid;
        }
    }
}
