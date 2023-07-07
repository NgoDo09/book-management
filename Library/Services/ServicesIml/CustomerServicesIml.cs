using Library.DAO;
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
    public class CustomerServicesIml : CustomerServices
    {
        CustomerRepo customerRepo;
        public CustomerServicesIml() 
        {
            customerRepo = new CustomerRepoIml();
        }
        public List<TblCustomer> GetAllCustomer()
        {
           return customerRepo.GetAllCustomer();
        }

        public TblCustomer GetCustomerByUserName(string username)
        {
            return customerRepo.GetCustomerByUserName(username);
        }
        public int DeleteCustomerByUserName(string username)
        {
            var customer = GetCustomerByUserName(username) as TblCustomer;
            if (customer == null) 
            {
                throw new Exception("UserName Not Found");
            }
            return customerRepo.DeleteCustomerByUserName(username);
        }

        public TblCustomer UpdateCustomer(CustomerUpdateRequest customerUpdateRequest)
        {
            var customer = customerRepo.UpdateCustomer(customerUpdateRequest);
            if (customer == null)
            {
                throw new Exception("Username Not Found");
            }
            return customerRepo.UpdateCustomer(customerUpdateRequest);
        }
    }
}
