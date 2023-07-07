using Library.DTO;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface AccountServices
    {
        public TblAccount checkLogin(string username, string password);

        public TblAccount FindAccountByUserName(string userName);
        public TblAccount Register(RegisterRequest registerRequest);
    }
}
