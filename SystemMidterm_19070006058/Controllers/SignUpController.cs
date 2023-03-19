using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemMidterm_19070006058.Model.Dto;
using SystemMidterm_19070006058.Model;
using SystemMidterm_19070006058.Source;
using Microsoft.AspNetCore.Authorization;

namespace SystemMidterm_19070006058.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SignUpController : ControllerBase
    {
        private IUserService _userService;
        private ICustomerService _customerService;

        public SignUpController(IUserService userService, ICustomerService customerService)
        {
            _userService = userService;
            _customerService = customerService;
        }
        [HttpPost]       
        public IActionResult SignUp(UserSignUpDto userSignUpDto)
        {
            if(ModelState.IsValid) 
            {
                UserModel user = new UserModel();
                user.GivenName = userSignUpDto.GivenName;
                user.Password = userSignUpDto.Password;
                user.Surname = userSignUpDto.Surname;
                user.Username = userSignUpDto.Username;
                user.EmailAddress = userSignUpDto.EmailAddress;
                user.Role = "NormalUser";

                Customer customer=new Customer();
                customer.FullName=userSignUpDto.GivenName+" "+userSignUpDto.Surname;
                customer.Email = userSignUpDto.EmailAddress;
                customer.Address = " ";
                customer.PhoneNumber = " ";
                customer.CustomerStatus = true;
                customer.City = " ";
                
                _customerService.TAdd(customer);
                _userService.TAdd(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
            
        }
    }
}
