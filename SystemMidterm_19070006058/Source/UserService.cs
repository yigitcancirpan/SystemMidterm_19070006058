using SystemMidterm_19070006058.Context;
using SystemMidterm_19070006058.Model;

namespace SystemMidterm_19070006058.Source
{
    public class UserService : GenericService<UserModel>, IUserService
    {
        public UserService(MidtermContext context) : base(context)
        {
        }
    }
}
