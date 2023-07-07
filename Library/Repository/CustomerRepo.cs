using Library.DTO;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface CustomerRepo
    {
        public List<TblCustomer> GetAllCustomer();
        public TblCustomer GetCustomerByUserName(string username);
        public int DeleteCustomerByUserName(string username);
        public TblCustomer UpdateCustomer(CustomerUpdateRequest customerUpdateRequest);
    }
}
