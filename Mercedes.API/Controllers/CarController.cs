using Mercedes.Application.Catalog.Cars;
using Mercedes.Application.Catalog.Cars.Dtos;
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
        private readonly ICarManagerService _carManagerService;

        public CarController(ICarViewService carViewService, ICarManagerService carManagerService)
        {
            _carViewService = carViewService;
            _carManagerService = carManagerService;
        }

        [HttpGet("get-car-search-filer")]
        public async Task<IActionResult> Get(int Cate, int Index=1, int PageSize=10, string SearchValue="")
        {
            var cars = await _carViewService.GetAllCarPaging(Cate, SearchValue, Index, PageSize);
            return Ok(cars.ToList());
        }

        [HttpPost("create-new-car")]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarRequest request)
        {
            var car = await _carManagerService.CreateCar(request);
            if(car == 0)
            {
                return BadRequest();
            }
            return Ok(car);
        }
    }
}
