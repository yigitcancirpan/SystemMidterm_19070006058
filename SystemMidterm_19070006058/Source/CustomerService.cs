using Microsoft.IdentityModel.Tokens;
using SystemMidterm_19070006058.Context;
using SystemMidterm_19070006058.Model;

namespace SystemMidterm_19070006058.Source
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        public CustomerService(MidtermContext context) : base(context)
        {
        }
    }
}
