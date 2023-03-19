using SystemMidterm_19070006058.Context;
using SystemMidterm_19070006058.Model;

namespace SystemMidterm_19070006058.Source
{
    public class HouseService : GenericService<House>, IHouseService
    {
        public HouseService(MidtermContext context) : base(context)
        {
        }
    }
}
