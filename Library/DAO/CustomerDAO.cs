using Library.DTO;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO
{
    public class CustomerDAO
    {
        book_managementContext dbcontext;
        public CustomerDAO()
        {
            dbcontext = new book_managementContext();
        }
        public List<TblCustomer> GetAllCustomer()
        {
            var customer = dbcontext.TblCustomers.ToList();
            return customer;
        }

        public TblCustomer GetCustomerByUserName(string username)
        {
            var customer = dbcontext.TblCustomers.Where (cus => cus.Username.Equals (username)).FirstOrDefault();
            return customer;
        }

        public int DeleteCustomerByUserName(string username)
        {
            var customer = GetCustomerByUserName (username);
            dbcontext.TblCustomers.Remove(customer);
            return dbcontext.SaveChanges();
        }
        public TblCustomer UpdateCustomer(CustomerUpdateRequest customerUpdateRequest)
        {
            var customerUpdate = dbcontext.TblCustomers.Where(cus => cus.Username.Equals(customerUpdateRequest.Username)).FirstOrDefault(); 
            customerUpdate.Email = customerUpdateRequest.Email;
            customerUpdate.CustomerName = customerUpdateRequest.CustomerName;
            customerUpdate.Contact = customerUpdateRequest.Contact;
            dbcontext.Update(customerUpdate);
            dbcontext.SaveChanges ();
            return customerUpdate;
        }
    }
}
