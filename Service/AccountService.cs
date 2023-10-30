using AuthSystem.Context;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return context.Accounts.ToList();
        }

        public Account FindById(int id)
        {
            Account account = context.Accounts.Find(id);

            if (account == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Account", "id", AppConstant.NOT_FOUND));
            }

            return account;
        }

        public Account FindByUsername(string username)
        {
            Account account = context.Accounts.FirstOrDefault(a => a.Username.Equals(username));

            if (account == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Account", "username", AppConstant.NOT_FOUND));
            }

            return account;
        }

        public Account FindByEmail(string email)
        {
            Account account = context.Accounts.FirstOrDefault(a => a.Email.Equals(email));

            if (account == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Account", "email", AppConstant.NOT_FOUND));
            }

            return account;
        }

        public Account FindByPhoneNumber(string phoneNumber)
        {
            Account account = context.Accounts.FirstOrDefault(a => a.PhoneNumber.Equals(phoneNumber));

            if (account == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Account", "phone number", AppConstant.NOT_FOUND));
            }

            return account;
        }

        public void Add(Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }

        public void Update(int id, Account account)
        {
            var existingAccount = FindById(id);
            existingAccount.Username = account.Username;
            existingAccount.Password = account.Password;
            existingAccount.FirstName = account.FirstName;
            existingAccount.LastName = account.LastName;
            existingAccount.Email = account.Email;
            existingAccount.PhoneNumber = account.PhoneNumber;
            existingAccount.Role = account.Role != 0 ? account.Role : existingAccount.Role;

            context.SaveChanges();
        }

        public void Remove(Account account)
        {
            context.Accounts.Remove(account);
            context.SaveChanges();
        }
    }
}
