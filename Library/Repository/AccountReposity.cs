﻿using Library.DTO;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface AccountRepository
    {
        public TblAccount checkLogin(string username, string password);
        public TblAccount FindAccountByUserName(string username);
        public TblAccount Register(RegisterRequest registerRequest);

    }
}
