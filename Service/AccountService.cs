using AuthSystem.Context;
using AuthSystem.Security;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AuthSystem
{
    public class AccountService
    {
        private AuthSystemEntities context;

        public AccountService() 
        {
            context = new AuthSystemEntities();
        }

        public List<Account> FindAll()
        {
            var accounts = context.Accounts.ToList();
            var mappedAccounts = new List<Account>();
            foreach (var account in accounts)
            {
                mappedAccounts.Add(MapAccount(account));
            }

            return mappedAccounts;
        }

        public Account FindById(int id)
        {
            Account account = context.Accounts.Find(id);

            if (account == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Account", "id", AppConstant.NOT_FOUND));
            }

            return MapAccount(account);
        }

        public Account FindByUsername(string username)
        {
            Account account = context.Accounts.FirstOrDefault(a => a.Username.Equals(username));

            if (account == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Account", "username", AppConstant.NOT_FOUND));
            }

            return MapAccount(account);
        }

        public Account FindByEmail(string email)
        {
            Account account = null;
            foreach (var a in context.Accounts)
            {
                if (SecurityService.Decrypt(a.Email).Equals(email))
                {
                    account = a;
                    break;
                }
            }

            if (account == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Account", "email", AppConstant.NOT_FOUND));
            }

            return MapAccount(account);
        }

        public Account FindByPhoneNumber(string phoneNumber)
        {
            Account account = null;
            foreach (var a in context.Accounts)
            {
                if (SecurityService.Decrypt(a.PhoneNumber).Equals(phoneNumber))
                {
                    account = a;
                    break;
                }
            }

            if (account == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Account", "phone number", AppConstant.NOT_FOUND));
            }

            return MapAccount(account);
        }

        public void Add(Account account)
        {
            account.Password = SecurityService.Encrypt(account.Password);
            account.Email = SecurityService.Encrypt(account.Email);
            account.PhoneNumber = SecurityService.Encrypt(account.PhoneNumber);

            context.Accounts.Add(account);
            context.SaveChanges();
        }

        public void Update(int id, Account account)
        {
            var existingAccount = context.Accounts.Find(id);

            if (existingAccount == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Account", "id", AppConstant.NOT_FOUND));
            }

            existingAccount.Username = account.Username;
            existingAccount.Password = SecurityService.Encrypt(account.Password);
            existingAccount.FirstName = account.FirstName;
            existingAccount.LastName = account.LastName;
            existingAccount.Email = SecurityService.Encrypt(account.Email);
            existingAccount.PhoneNumber = SecurityService.Encrypt(account.PhoneNumber);
            existingAccount.RoleId= account.RoleId != 0 ? account.RoleId : existingAccount.RoleId;

            context.SaveChanges();
        }

        public void Remove(Account account)
        {
            account = context.Accounts.Find(account.Id);

            if (account == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Account", "id", AppConstant.NOT_FOUND));
            }

            context.Accounts.Remove(account);
            context.SaveChanges();
        }

        private Account MapAccount(Account account)
        {
            Account mappedAccount = new Account();
            mappedAccount.Id = account.Id;
            mappedAccount.Username = account.Username;
            mappedAccount.Password = SecurityService.Decrypt(account.Password);
            mappedAccount.FirstName = account.FirstName;
            mappedAccount.LastName = account.LastName;
            mappedAccount.Email = SecurityService.Decrypt(account.Email);
            mappedAccount.PhoneNumber = SecurityService.Decrypt(account.PhoneNumber);
            mappedAccount.RoleId = account.RoleId;
            mappedAccount.Role = account.Role;

            return mappedAccount;
        }
    }
}
