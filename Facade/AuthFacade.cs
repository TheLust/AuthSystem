using AuthSystem.Context;
using AuthSystem.Security;
using AuthSystem.Service;
using AuthSystem.Util.Constants;
using System;

namespace AuthSystem.Facade
{
    public class AuthFacade
    {
        private AccountService accountService;
        private RoleService roleService;

        public AuthFacade()
        {
            accountService = new AccountService();
            roleService = new RoleService();
        }

        public Account Login(Account account)
        {
            Account foundAccount;

            try
            {
                foundAccount = accountService.FindByUsername(account.Username);
            } catch (Exception)
            {
                throw new Exception(AppConstant.BAD_CREDENTIALS);
            }

            if (!foundAccount.Password.Equals(account.Password)) 
            {
                throw new Exception(AppConstant.BAD_CREDENTIALS);
            }

            return foundAccount;
        }

        public void Register(Account account)
        {
            account.RoleId = roleService.FindUserRole().Id;
            accountService.Add(account);
        }

        public bool UsernameExists(string username)
        {
            try
            {
                accountService.FindByUsername(username);
            } catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool EmailExists(string email)
        {
            try
            {
                accountService.FindByEmail(email);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool PhoneNumberExists(string phoneNumber)
        {
            try
            {
                accountService.FindByPhoneNumber(phoneNumber);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
