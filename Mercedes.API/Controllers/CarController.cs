using Mercedes.Application.Catalog.Cars;
using Mercedes.Application.Catalog.Cars.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercedes.API.Controllers
{
    [EnableCors("MyPolicy")]
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
        public async Task<IActionResult> Get(int Cate, int Index = 1, int PageSize = 10, string SearchValue = "")
        {
            var cars = await _carViewService.GetAllCarPaging(Cate, SearchValue, Index, PageSize);
            return Ok(cars.ToList());
        }

        [HttpGet("get-car-search-filer-admin-page")]
        public async Task<IActionResult> GetCarAdmin(int Cate, int Index = 1, int PageSize = 10, string SearchValue = "")
        {
            var cars = await _carManagerService.GetAllPaging(Cate, SearchValue, Index, PageSize);
            return Ok(cars.ToList());
        }

        [HttpPost("create-new-car")]
        public async Task<IActionResult> CreateCar(string Name, string Color, float Price, int Quantity, string Image, string Decription, int CategoryID)
        {
            var car = await _carManagerService.CreateCar(Name, Color, Price, Quantity, Image, Decription, CategoryID);
            if (car == 0)
            {
                return BadRequest();
            }
            return Ok(car);
        }

        [HttpPut("Update-car")]
        public async Task<IActionResult> UpdateCar(int CarId, string Name, string Color, float Price, int Quantity, string Image, string Decription, int CategoryID, bool Status)
        {
            var car = await _carManagerService.UpdateCar(CarId, Name, Color, Price, Quantity, Image, Decription, CategoryID, Status);
            if (car == 0)
            {
                return BadRequest();
            }
            return Ok(car);
        }

        [HttpPut("Delete-car")]
        public async Task<IActionResult> DeleteCar(int CarID)
        {
            var car = await _carManagerService.DeleteCar(CarID);
            if (car == 0)
            {
                return BadRequest();
            }
            return Ok(car);
        }

        [HttpGet("find-by-id")]
        public async Task<IActionResult> FindById(int CarID)
        {
            var car = await _carManagerService.FindById(CarID);
            if (car == null)
            {
                return BadRequest("Cannot find car");
            }
            return Ok(car);
        }
    }
}
