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
    public class CustomerRepoIml : CustomerRepo
    {
        CustomerDAO customerDAO;
        public CustomerRepoIml()
        {
            customerDAO = new CustomerDAO();    
        }
        public List<TblCustomer> GetAllCustomer()
        {
           return customerDAO.GetAllCustomer();
        }
        public TblCustomer GetCustomerByUserName(string username)
        {
            return customerDAO.GetCustomerByUserName(username);
        }
        public int DeleteCustomerByUserName(string username)
        {
            return customerDAO.DeleteCustomerByUserName(username);
        }
        public TblCustomer UpdateCustomer(CustomerUpdateRequest customerUpdateRequest)
        {
            return customerDAO.UpdateCustomer(customerUpdateRequest);
        }
    }
}
