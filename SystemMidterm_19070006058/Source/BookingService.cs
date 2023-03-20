using SystemMidterm_19070006058.Context;
using SystemMidterm_19070006058.Model;

namespace SystemMidterm_19070006058.Source
{
    public class BookingService : GenericService<Booking>, IBookingService
    {
        public BookingService(MidtermContext context) : base(context)
        {
        }

        public bool IsHouseAvailable(int id, DateTime from, DateTime to)
        {
            var bookings=_context.Booking.Where(x=>x.HouseId==id).ToList();
            foreach(var booking in bookings)
            {
                if ((booking.DateFrom >= from && booking.DateFrom<=to) || (booking.DateTo>=from && booking.DateTo <= to))
                {
                    return false;
                }
              
            }
            return true;

            //return !bookings.Any(m=>
            //(m.DateFrom<from && 
            //from < m.DateTo) 
            //||
            //(m.DateFrom < to) && 
            //(to <= m.DateTo) 
            //|| 
            //(from < m.DateFrom && 
            //m.DateFrom < to) 
            //||
            //(from < m.DateTo && 
            //m.DateTo <= to)
            //);
        }
    }
}
