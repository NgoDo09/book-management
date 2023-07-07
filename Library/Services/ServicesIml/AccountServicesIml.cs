using Library.DTO;
using Library.Model;
using Library.Repository;
using Library.Repository.RepositoryIml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ServicesIml
{
    public class AccountServicesIml : AccountServices
    {
        AccountRepository accountRepository;
        public AccountServicesIml() 
        { 
            accountRepository = new AccountRepositoryIml();
        }

        public TblAccount checkLogin(string username, string password)
        {
            return accountRepository.checkLogin(username, password);
        }

        public TblAccount FindAccountByUserName(string username)
        {
            return accountRepository.FindAccountByUserName(username);
        }

        public TblAccount Register(RegisterRequest registerRequest)
        {
            return accountRepository.Register(registerRequest);
        }
    }
}
