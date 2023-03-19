using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using SystemMidterm_19070006058.Model;
using SystemMidterm_19070006058.Model.Dto;
using SystemMidterm_19070006058.Source;

namespace SystemMidterm_19070006058.Controllers
{
    //[Route("api/[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        public List<CustomerDto> GetAll()
        {
            var customers=_customerService.TGetAll();
            
            var customerDtos=new List<CustomerDto>();
            customers.ForEach(customer => customerDtos.Add(createCustomerDto(customer)));
            
           
            return customerDtos;
            
           
        }

        [HttpPost("GetAllWithPaging")]
        public List<CustomerDto> GetWithPaging(QueryWithPagingDto query)
        {
            List<Customer> datas = _customerService.TGetAll();
            List<Customer> datasFiltered = datas.Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize).ToList();

            List<CustomerDto> ret = new List<CustomerDto>();
            datasFiltered.ForEach(data => ret.Add(createCustomerDto(data)));
            return ret;
        }
        [HttpGet("{id}")]
        public CustomerDto GetCustomer(int id)
        {
            Customer customer=_customerService.TGetById(id);
            return createCustomerDto(customer);
        }
        [HttpPost("InsertCustomer")]
        public CustomerResultDto InsertCustomer([FromBody] CustomerDto customer)
        {

            CustomerResultDto ret = new CustomerResultDto();
            if (!ModelState.IsValid)
            {
                ret.Status = "FAILURE";
                ret.Message = "Invalid Model";
                return ret;
            }
            try
            {
                _customerService.TAdd(createCustomer(customer));
                
            }
            catch (Exception ex)
            {
                ret.Status = "FAILURE";
                ret.Message = ex.Message;
            }
            return ret;
        }
        [HttpGet("UpdateCustomer/{id}")]
        [Authorize]
        public IActionResult UpdateCustomer([Required]int id)
        {
            var cust=_customerService.TGetById(id);
            CustomerDto customerDto = new CustomerDto()
            {
                Id = cust.Id,
                NameSurname = cust.FullName,
                Address = cust.Address,
                City = cust.City,
                Email = cust.Email,
                PhoneNumber = cust.PhoneNumber,
                IsActive=cust.CustomerStatus
            };
            return Ok(customerDto);
        }
        [HttpPatch("UpdateCustomer")]
        public CustomerResultDto UpdateCustomer([FromBody] CustomerDto customer)
        {
            CustomerResultDto ret = new CustomerResultDto();
            if (!ModelState.IsValid)
            {
                ret.Status = "FAILURE";
                ret.Message = "Invalid Model";
                return ret;
            }
            try
            {
                _customerService.TUpdate(createCustomer(customer));
            }
            catch (Exception ex)
            {
                ret.Status = "FAILURE";
                ret.Message = ex.Message;
            }
            return ret;
        }
        private CustomerDto createCustomerDto(Customer customer)
        {
            CustomerDto ret = new CustomerDto()
            {
                Id = customer.Id,
                NameSurname = customer.FullName,
                Address = customer.Address,
                City = customer.City,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                IsActive=customer.CustomerStatus
            };
            return ret;
        }
        private Customer createCustomer(CustomerDto customerDto)
        {
            Customer customer = new Customer()
            {
                Id = customerDto.Id,
                FullName = customerDto.NameSurname,
                Address = customerDto.Address,
                City = customerDto.City,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,

            };
            return customer;
        }
    }
}
