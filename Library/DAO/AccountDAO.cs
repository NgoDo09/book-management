using Library.DTO;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO
{
    public class AccountDAO
    {
        book_managementContext dbcontext;
        public AccountDAO()
        {
            dbcontext = new book_managementContext();
        }
        public TblAccount checkLogin(string username , string password)
        {
            var account = dbcontext.TblAccounts.Where (acc => acc.Username.Equals(username) && acc.Password.Equals(password)).FirstOrDefault();
            return account;
        }

        public TblAccount Register(RegisterRequest registerRequest) 
        {
            var account = new TblAccount();
            account.Username = registerRequest.Username;
            account.Password = registerRequest.Password;
            account.Role = "User";
            dbcontext.Add(account);
            dbcontext.SaveChanges();
            var Customer = new TblCustomer();
            Customer.Username = account.Username;
            Customer.CustomerName = registerRequest.CustomerName;
            Customer.Email = registerRequest.Email;
            Customer.Contact = registerRequest.Contact;
            dbcontext.TblCustomers.Add(Customer);
            dbcontext.SaveChanges();
            return account;
        }

        public TblAccount FindAccountByUserName(string username)
        {
            var account = dbcontext.TblAccounts.Where (acc => acc.Username.Equals (username)).FirstOrDefault();
            return account;
        }
    }
}
