using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SystemMidterm_19070006058.Model;
using SystemMidterm_19070006058.Model.Dto;
using SystemMidterm_19070006058.Source;

namespace SystemMidterm_19070006058.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HouseController : ControllerBase
    {
        private IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
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
        [HttpPost("{term}")]
        public List<HouseDto> SearchHouse([Required]string term)
        {
            var houses= _houseService.TGetAll().AsQueryable();
            if (!string.IsNullOrEmpty(term))
            {
                houses = houses.Where(c =>
                c.Name.Contains(term) ||
                c.Description.Contains(term)
                );
            }
            var houseDtos = new List<HouseDto>();
            houses.ForEachAsync(house => houseDtos.Add(createHouseDto(house)));
            return houseDtos;
        }

        private HouseDto createHouseDto(House house)
        {
            HouseDto ret = new HouseDto()
            {
                Id = house.Id,
                Name= house.Name,
                Description = house.Description,
                City = house.City,
                MaxCustomerCount= house.MaxCustomerCount,
            };
            return ret;
        }
        private House createHouse(HouseDto houseDto)
        {
            House house = new House()
            {
                Id = houseDto.Id,
                Name = houseDto.Name,
                Description= houseDto.Description,
                City = houseDto.City,
                MaxCustomerCount= houseDto.MaxCustomerCount,
                Amenities= houseDto.Amenities,
                Bookings= houseDto.Bookings,

            };
            return house;
        }
    }
}
