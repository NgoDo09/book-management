using Library.DTO;
using Library.Services;
using Library.Services.ServicesIml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerServices customerServices;
        public CustomerController()
        {
            customerServices = new CustomerServicesIml();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllCustomer()
        {
            var customer = customerServices.GetAllCustomer();
            CustomerResponse customerResponse = new CustomerResponse();
            if (customerResponse == null) 
            {
                customerResponse.StatusCode = StatusCodes.Status400BadRequest;
                customerResponse.Message = "Customer Invalid";
                return new ObjectResult(customerResponse);
            }
            customerResponse.StatusCode = StatusCodes.Status200OK;
            customerResponse.Message = "Success";
            customerResponse.Data = customer;
            return new ObjectResult(customerResponse);
        }

        [HttpGet("GetUserName")]
        public IActionResult GetCustomerByUserName(string username)
        {
            var customer = customerServices.GetCustomerByUserName(username);
            CustomerResponse customerResponse = new CustomerResponse();
            if (customer == null)
            {
                customerResponse.StatusCode = StatusCodes.Status400BadRequest;
                customerResponse.Message = "Customer Not Found";
                return new ObjectResult(customerResponse);
            }
            customerResponse.StatusCode= StatusCodes.Status200OK;
            customerResponse.Message = "Success";
            customerResponse.Data= customer;
            return new ObjectResult(customerResponse);
        }

        [HttpDelete("UserName")]

        public IActionResult DeleteCustomerByUserName(string username)
        {
            CustomerResponse customerResponse = new CustomerResponse();
            try
            {
                var result = customerServices.DeleteCustomerByUserName(username);
                customerResponse.StatusCode = StatusCodes.Status200OK;
                customerResponse.Message = "Delete Success";
                customerResponse.Data = result;
                return new ObjectResult(customerResponse);
            }
            catch (Exception ex)
            {
                customerResponse.StatusCode = StatusCodes.Status400BadRequest;
                customerResponse.Message = ex.Message;
                return new ObjectResult(customerResponse);  
            }
        }
        [HttpPut("Update")]
        
        public IActionResult UpdateCustomer(CustomerUpdateRequest customerUpdateRequest)
        {
            CustomerResponse customerResponse= new CustomerResponse();
            try
            {
                var customer = customerServices.UpdateCustomer(customerUpdateRequest);
                customerResponse.StatusCode = StatusCodes.Status200OK;
                customerResponse.Message = "Update Success";
                customerResponse.Data = customer;
                return new ObjectResult(customerResponse);
            }
            catch (Exception ex)
            {
                customerResponse.StatusCode = StatusCodes.Status400BadRequest;
                customerResponse.Message = ex.Message;
                return new ObjectResult(customerResponse);
            }
            
        }
    }
}
