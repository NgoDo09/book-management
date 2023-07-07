using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Services.ServicesIml;
using Library.DTO;
using Library.Services;

namespace book_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountServices accountService;
        public AccountController()
        {
            accountService = new AccountServicesIml();
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var account = accountService.checkLogin(loginRequest.Username, loginRequest.Password);
            LoginResponse loginResponse = new LoginResponse();
            if (account == null)
            {
                loginResponse.StatusCode = StatusCodes.Status401Unauthorized;
                loginResponse.Message = "Account Invalid";
                return new ObjectResult(loginResponse);
            }
            loginResponse.StatusCode = StatusCodes.Status200OK;
            loginResponse.Message = "Login Success";
            loginResponse.Data = account;
            return new ObjectResult(loginResponse);
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            try
            {
                var account = accountService.Register(registerRequest);
                RegisterResponse registerResponse = new RegisterResponse();
                registerResponse.StatusCode = StatusCodes.Status200OK;
                registerResponse.Message = "Register Success";
                registerResponse.Data = account;
                return new ObjectResult(registerResponse);
            }
            catch (Exception ex)
            {
                RegisterResponse registerResponse = new RegisterResponse();
                registerResponse.StatusCode = StatusCodes.Status400BadRequest;
                registerResponse.Message = ex.Message;
                return new ObjectResult(registerResponse);
            }
        }
    }
}
