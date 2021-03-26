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

        public async Task<int> CreateCar(string Name, string Color, float Price, int Quantity, string Image, string Decription, int CategoryID)
        {

            var car = new Car()
            {
                Name = Name,
                Color = Color,
                Price = Price,
                Quantity = Quantity,
                Image = Image,
                Decription = Decription,
                CategoryID = CategoryID,
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

        public async Task<int> UpdateCar(int CarId, string Name, string Color, float Price, int Quantity, string Image, string Decription, int CategoryID, bool Status)
        {
            var car = await _context.Cars.FindAsync(CarId);
            if (car == null) throw new MercedesException("Cannot find a product");
            car.Name = Name;
            car.Color = Color;
            car.Price = Price;
            car.Quantity = Quantity;
            car.Image = Image;
            car.CategoryID = CategoryID;
            car.Status = Status;
            _context.Cars.Update(car);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductViewModels> FindById(int CarID)
        {
            var car = _context.Cars.Where(x => x.CarId == CarID);
            if (car == null) throw new MercedesException("Cannot find a product");
            var data = car.Select(x => new ProductViewModels()
            {
                CarId = x.CarId,
                Name = x.Name,
                Color = x.Color,
                Price = x.Price,
                Quantity = x.Quantity,
                Image = x.Image,
                CategoryID = x.CategoryID,
                Status = x.Status
            }).FirstOrDefault();
            return data;
        }
    }
}
