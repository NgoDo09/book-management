using Library.DAO;
using Library.DTO;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository.RepositoryIml
{
    public class AccountRepositoryIml : AccountRepository
    {
        AccountDAO accountDAO;
        public AccountRepositoryIml()
        {
            accountDAO = new AccountDAO();
        }
        public TblAccount checkLogin(string username, string password)
        {
            return accountDAO.checkLogin(username, password);
        }

        public TblAccount FindAccountByUserName(string username)
        {
            return accountDAO.FindAccountByUserName(username);
        }

        public TblAccount Register(RegisterRequest registerRequest)
        {
            return accountDAO.Register(registerRequest);
        }
    }
}
