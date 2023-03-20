using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using SystemMidterm_19070006058.Model;
using SystemMidterm_19070006058.Model.Dto;
using SystemMidterm_19070006058.Source;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SystemMidterm_19070006058.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HouseController : ControllerBase
    {
        private IHouseService _houseService;
        private IBookingService _bookingService;

        public HouseController(IHouseService houseService, IBookingService bookingService)
        {
            _houseService = houseService;
            _bookingService = bookingService;
        }
        [HttpGet("GetAll")]
        public List<HouseDto> GetAll()
        {
            var houses = _houseService.TGetAll();
            var houseDtos = new List<HouseDto>();
            houses.ForEach(house => houseDtos.Add(createHouseDto(house)));

            return houseDtos;


        }
        [HttpPost("InsertHouse")]
        public HouseResultDto InsertHouse(HouseDto house)
        {
            HouseResultDto ret = new HouseResultDto();
            if (!ModelState.IsValid)
            {
                ret.Status = "FAILURE";
                ret.Message = "Invalid Model";
                return ret;
            }
            try
            {
                _houseService.TAdd(createHouse(house));

            }
            catch (Exception ex)
            {
                ret.Status = "FAILURE";
                ret.Message = ex.Message;
            }
            return ret;
        }
        [HttpPost("SearchHouse/{term}")]
        public List<HouseDto> SearchHouse([Required] string term)
        {
            var houses = _houseService.TGetAll().AsQueryable();
            if (!string.IsNullOrEmpty(term))
            {
                houses = houses.Where(c =>
                c.Name.Contains(term) ||
                c.Description.Contains(term)
                );
            }
            var houseDtos = new List<HouseDto>();

            foreach (var house in houses)
            {
                var houseDto = new HouseDto();
                houseDto.Id = house.Id;
                houseDto.Name = house.Name;
                houseDto.Description = house.Description;
                houseDto.City = house.City;
                houseDto.MaxCustomerCount = house.MaxCustomerCount;
                houseDtos.Add(houseDto);
            }

            return houseDtos;
        }
        [HttpPost]
        public List<HouseDto> QueryHouse(int countOfPeople, [Required]string DateFrom, [Required] string DateTo, QueryWithPagingDto query)
        {
            var houses = _houseService.TGetAll();
            List<House> datasFiltered = houses.Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize).ToList();
            var date1=DateTime.Parse(DateFrom);
            var date2=DateTime.Parse(DateTo);
            var houseDtos = new List<HouseDto>();

            foreach (var house in datasFiltered)
            {
                if ((house.MaxCustomerCount >= countOfPeople ) && _bookingService.IsHouseAvailable(house.Id, date1, date2))
                {
                    var model = new HouseDto();
                    model.Id = house.Id;
                    model.Name = house.Name;
                    model.Description = house.Description;
                    model.City = house.City;
                    model.MaxCustomerCount= house.MaxCustomerCount;
                    houseDtos.Add(model);
                }


            }
            
            return houseDtos;

        }

        private HouseDto createHouseDto(House house)
        {
            HouseDto ret = new HouseDto()
            {
                Id = house.Id,
                Name = house.Name,
                Description = house.Description,
                City = house.City,
                MaxCustomerCount = house.MaxCustomerCount,
                IsAvailable = house.IsAvaiable
            };
            return ret;
        }
        private House createHouse(HouseDto houseDto)
        {
            House house = new House()
            {
                Id = houseDto.Id,
                Name = houseDto.Name,
                Description = houseDto.Description,
                City = houseDto.City,
                MaxCustomerCount = houseDto.MaxCustomerCount,
                IsAvaiable = true

            };
            return house;
        }
    }
}
