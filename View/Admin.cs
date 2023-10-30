using AuthSystem.Context;
using AuthSystem.Facade;
using AuthSystem.Service;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthSystem.View
{
    public partial class Admin : Form
    {
        private AuthFacade authFacade;

        private AccountService accountService;

        private RoleService roleService;

        private Account selectedAccount = new Account();

        private bool GridEventEnabled = true;

        public Admin()
        {
            authFacade = new AuthFacade();
            accountService = new AccountService();
            roleService = new RoleService();
            InitializeComponent();
            SetDataSource();
            InitializeRoles();
            SaveMode(false);
            UpdateMode(false);
            ResetAccount();
            FillForm();
            DeleteButton.Enabled = false;
            UpdateButton.Enabled = false;
        }

        private void SetDataSource()
        {
            Grid.DataSource = (from account in accountService.FindAll()
                               select new
                               {
                                   account.Username,
                                   account.Password,
                                   account.FirstName,
                                   account.LastName,
                                   account.Email,
                                   account.PhoneNumber,
                                   Role = account.Role1.Name
                               }).ToList();
        }

        private void FillForm()
        {
            UsernameTextBox.Text = selectedAccount.Username;
            PasswordTextBox.Text = selectedAccount.Password;
            FirstNameTextBox.Text = selectedAccount.FirstName;
            LastNameTextBox.Text = selectedAccount.LastName;
            EmailTextBox.Text = selectedAccount.Email;
            PhoneNumberTextBox.Text = selectedAccount.PhoneNumber;
            RoleComboBox.SelectedValue = selectedAccount.Role;
        }

        private void InitializeRoles()
        {
            RoleComboBox.DataSource = roleService.FindAll();
            RoleComboBox.DisplayMember = "Name";
            RoleComboBox.ValueMember = "Id";
            RoleComboBox.SelectedIndex = 1;
        }

        private void ResetAccount()
        {
            selectedAccount = new Account();
        }

        private void SaveMode(bool saveMode)
        {
            if (saveMode)
            {
                UsernameTextBox.Enabled = true;
                PasswordTextBox.Enabled = true;
                FirstNameTextBox.Enabled = true;
                LastNameTextBox.Enabled = true;
                EmailTextBox.Enabled = true;
                PhoneNumberTextBox.Enabled = true;
                RoleComboBox.Enabled = true;
                UpdateButton.Enabled = false;
                DeleteButton.Enabled = false;
                GridEventEnabled = false;
                AddButton.Hide();
                SaveNewButton.Show();
                CancelSaveButton.Show();
            }
            else
            {
                UsernameTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
                FirstNameTextBox.Enabled = false;
                LastNameTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                PhoneNumberTextBox.Enabled = false;
                RoleComboBox.Enabled = false;
                UpdateButton.Enabled = false;
                DeleteButton.Enabled = false;
                GridEventEnabled = true;
                AddButton.Show();
                SaveNewButton.Hide();
                CancelSaveButton.Hide();
                ClearErrors();
            }
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
                RoleComboBox.Enabled = true;
                AddButton.Enabled = false;
                DeleteButton.Enabled = false;
                GridEventEnabled = false;
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
                RoleComboBox.Enabled = false;
                AddButton.Enabled = true;
                DeleteButton.Enabled = true;
                GridEventEnabled = true;
                UpdateButton.Show();
                SaveButton.Hide();
                CancelButton.Hide();
                ClearErrors();
            }
        }

        private bool ValidateAccount(Account newAccount)
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(newAccount.Username))
            {
                UsernameError.Text = AppConstant.GetExceptionMessage("Username", AppConstant.NOT_BLANK);
                valid = false;
            }
            else
            {
                try
                {
                    if (selectedAccount.Id != accountService.FindByUsername(newAccount.Username).Id)
                    {
                        UsernameError.Text = AppConstant.GetExceptionMessage("Account", "username", AppConstant.ALREADY_EXISTS);
                        valid = false;
                    }
                }
                catch { }
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
                    if (selectedAccount.Id != accountService.FindByEmail(newAccount.Email).Id)
                    {
                        EmailError.Text = AppConstant.GetExceptionMessage("Account", "email", AppConstant.ALREADY_EXISTS);
                        valid = false;
                    }
                }
                catch { }
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
                    if (selectedAccount.Id != accountService.FindByPhoneNumber(newAccount.PhoneNumber).Id)
                    {
                        PhoneNumberError.Text = AppConstant.GetExceptionMessage("Account", "phone number", AppConstant.ALREADY_EXISTS);
                        valid = false;
                    }
                }
                catch { }
            }

            if (newAccount.Role <= 0)
            {
                RoleError.Text = AppConstant.GetExceptionMessage("Role", AppConstant.NOT_NULL);
                valid = false;
            }

            return valid;
        }

        private Account GetAccountFromForm()
        {
            Account account = new Account()
            {
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Email = EmailTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Role = RoleComboBox.SelectedValue != null ? (int)RoleComboBox.SelectedValue : 0
            };

            return account;
        }

        private void ClearErrors()
        {
            UsernameError.Text = string.Empty;
            PasswordError.Text = string.Empty;
            FirstNameError.Text = string.Empty;
            LastNameError.Text = string.Empty;
            EmailError.Text = string.Empty;
            PhoneNumberError.Text = string.Empty;
            RoleError.Text = string.Empty;
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridEventEnabled) 
            {
                selectedAccount = accountService.FindByUsername(
                    Grid.Rows[e.RowIndex >= 0 ? e.RowIndex : 0].Cells[0].Value.ToString()
                );

                DeleteButton.Enabled = true;
                UpdateButton.Enabled = true;

                FillForm();
            }
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            SetDataSource();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ResetAccount();
            FillForm();
            SaveMode(true);
        }

        private void CancelSaveButton_Click(object sender, EventArgs e)
        {
            SaveMode(false);
            FillForm();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateMode(true);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            UpdateMode(false);
            FillForm();
        }

        private void SaveNewButton_Click(object sender, EventArgs e)
        {
            Account account = GetAccountFromForm();
            
            if (!ValidateAccount(account))
            {
                return;
            }
            accountService.Add(account);

            /*try
            {
                accountService.Add(account);
            } catch (Exception)
            {
                MessageBox.Show("Something went wrong");
                return;
            }*/

            SetDataSource();
            SaveMode(false);
            ResetAccount();
            FillForm();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Account account = GetAccountFromForm();

            if (!ValidateAccount(account))
            {
                return;
            }

            try
            {
                accountService.Update(selectedAccount.Id, account);
            } catch (Exception)
            {
                MessageBox.Show("Something went wrong");
                return;
            }

            SetDataSource();
            UpdateMode(false);
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

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoleError.Text = string.Empty;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this account?", "Sure?", MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            try
            {
                accountService.Remove(selectedAccount);
            } catch (Exception) 
            {
                MessageBox.Show("Something went wrong");
                return;
            }

            SetDataSource();
            ResetAccount();
            FillForm();
            SaveMode(false);
        }
    }
}
