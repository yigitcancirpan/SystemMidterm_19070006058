using System.ComponentModel.DataAnnotations;
using SystemMidterm_19070006058.Model;

namespace SystemMidterm_19070006058.Source
{
    public interface IBookingService:IGenericService<Booking>
    {
        public bool IsHouseAvailable(int id, [DataType(DataType.Date)] DateTime from, [DataType(DataType.Date)] DateTime to);
    }
}
