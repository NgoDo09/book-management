using Library.DTO;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface CustomerServices 
    {
        public List<TblCustomer> GetAllCustomer();
        public TblCustomer GetCustomerByUserName(string username);
        public int DeleteCustomerByUserName(String username);
        public TblCustomer UpdateCustomer(CustomerUpdateRequest customerUpdateRequest);
    }
}
