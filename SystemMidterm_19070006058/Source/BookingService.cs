using SystemMidterm_19070006058.Context;
using SystemMidterm_19070006058.Model;

namespace SystemMidterm_19070006058.Source
{
    public class BookingService : GenericService<Booking>, IBookingService
    {
        public BookingService(MidtermContext context) : base(context)
        {
        }
    }
}
