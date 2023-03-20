using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemMidterm_19070006058.Context;
using SystemMidterm_19070006058.Model;
using SystemMidterm_19070006058.Model.Dto;
using SystemMidterm_19070006058.Source;

namespace SystemMidterm_19070006058.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AmenityController : ControllerBase
    {
        private IAmenityService _amenityService;

        public AmenityController(IAmenityService amenityService)
        {
            _amenityService = amenityService;
        }
        [HttpGet("GetAll")]
        public List<Amenity> GetAll()
        {
            var houses = _amenityService.TGetAll();           
            return houses;
        }
        [HttpPost("PostAmenity")]
        public Amenity PostAmenity(Amenity amenity)
        {
            if(ModelState.IsValid)
            {
                _amenityService.TAdd(amenity);
                return amenity;
            }
            else
            {
                return null;
            }
            
        }


    }
}
