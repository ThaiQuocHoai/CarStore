using Mercedes.Application.Catalog.Cars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercedes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarViewService _carViewService;
        public CarController(ICarViewService carViewService)
        {
            _carViewService = carViewService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cars = await _carViewService.GetAll();
            return Ok(cars);
        }
    }
}
