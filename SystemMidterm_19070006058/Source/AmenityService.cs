using SystemMidterm_19070006058.Context;
using SystemMidterm_19070006058.Model;

namespace SystemMidterm_19070006058.Source
{
    public class AmenityService : GenericService<Amenity>, IAmenityService
    {
        public AmenityService(MidtermContext context) : base(context)
        {
        }
    }
}
