using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemMidterm_19070006058.Model;
using SystemMidterm_19070006058.Model.Dto;
using SystemMidterm_19070006058.Source;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SystemMidterm_19070006058.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;
        private IHouseService _houseService;

        public BookingController(IHouseService houseService, IBookingService bookingService)
        {
            _houseService = houseService;
            _bookingService = bookingService;
        }
        [HttpGet("GetAll")]
        public List<Booking> GetAll()
        {
            var bookings = _bookingService.TGetAll();
            return bookings;
        }

        [HttpPost("InsertBooking")]
        [Authorize]
        public BookingResultDto InsertBooking(Booking booking)
        {
            var houses = _houseService.TGetAll();

            BookingResultDto ret = new BookingResultDto();
            if (!ModelState.IsValid)
            {
                ret.Status = "FAILURE";
                ret.Message = "Invalid Model";
                return ret;
            }
            try
            {
                foreach (var house in houses)
                {
                    if ((house.MaxCustomerCount >= booking.CustomerCount) && _bookingService.IsHouseAvailable(house.Id, booking.DateFrom, booking.DateTo) && booking.HouseId==house.Id)
                    {
                        _bookingService.TAdd(booking);
                        ret.Status = "SUCCESS";
                        ret.Message = "Enjoy your holiday";
                        return ret;
                    }
                    else
                    {
                        ret.Status = "FAILURE";
                        ret.Message = "The house is not empty";
                    }
                }
            }
            catch (Exception ex)
            {
                ret.Status = "FAILURE";
                ret.Message = ex.Message;
            }
            return ret;
        }


    }
}
