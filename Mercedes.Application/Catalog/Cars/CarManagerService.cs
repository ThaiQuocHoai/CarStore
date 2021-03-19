using Mercedes.Application.Catalog.Cars.Dtos;
using Mercedes.Application.Dtos;
using Mercedes.DataService.Entities;
using Mercedes.DataService.EntityFramework;
using Mercedes.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercedes.Application.Catalog.Cars
{
    public class CarManagerService : ICarManagerService
    {
        private readonly MercedesDbContext _context;

        public CarManagerService(MercedesDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCar(CreateCarRequest request)
        {

            var car = new Car()
            {
                Name = request.Name,
                Color = request.Color,
                Price = request.Price,
                Quantity = request.Quantity,
                Image = request.Image,
                Decription = request.Decription,
                CategoryID = request.CategoryID,
                Status = true,

            };
            _context.Cars.Add(car);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCar(int CarID)
        {
            var car = await _context.Cars.FindAsync(CarID);
            if (car == null) throw new MercedesException("Cannot find a product");
            car.Status = false;
            _context.Cars.Update(car);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModels>> GetAllPaging(int Cate, string SearchValue, int Index, int PageSize)
        {
            var query = _context.Cars.Where(c => c.CategoryID == Cate && c.Name.Contains(SearchValue));
            if (query == null) throw new MercedesException("Cannot find a product");
            int total = await query.CountAsync();
            int EndPage = total / PageSize;
            if (total % PageSize != 0)
            {
                EndPage++;
            }
            var data = await query.Skip((Index - 1) * PageSize).Take(PageSize).Select(x =>new ProductViewModels()
            {
                CarId = x.CarId,
                Name = x.Name,
                Color = x.Color,
                Price = x.Price,
                Quantity = x.Quantity,
                Image = x.Image,
                CategoryID = x.CategoryID,
                Status = x.Status
            }).ToListAsync();
            return data;
        }

        public async Task<int> UpdateCar(UpdateCarRequest request)
        {
            var car = await _context.Cars.FindAsync(request.CarId);
            if(car == null) throw new MercedesException("Cannot find a product");
            car.Name = request.Name;
            car.Color = request.Color;
            car.Price = request.Price;
            car.Quantity = request.Quantity;
            car.Image = request.Image;
            car.CategoryID = request.CategoryID;
            car.Status = request.Status;
            _context.Cars.Update(car);
            return await _context.SaveChangesAsync();
        }
    }
}
