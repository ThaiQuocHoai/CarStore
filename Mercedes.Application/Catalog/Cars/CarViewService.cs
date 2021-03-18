using Mercedes.Application.Catalog.Cars.Dtos;
using Mercedes.Application.Dtos;
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
    public class CarViewService : ICarViewService
    {
        private readonly MercedesDbContext _context;

        public CarViewService(MercedesDbContext context)
        {
            _context = context;
        }

        public Task<List<ProductViewModels>> GetAll()
        {
            var query = _context.Cars.Where(c => c.Status == true);
            var data = query.Select(x => new ProductViewModels()
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

        public async Task<CarViewModels<ProductViewModels>> GetAllCarPaging(int Cate, string SearchValue, int Index, int PageSize)
        {
            var query = _context.Cars.Where(c => c.CategoryID == Cate && c.Name.Contains(SearchValue) && c.Status == true);
            if (query == null) throw new MercedesException("Cannot find a product");
            int total = await query.CountAsync();
            int EndPage = total / PageSize;
            if (total % PageSize != 0)
            {
                EndPage++;
            }
            var data = await query.Skip((Index - 1) * PageSize).Take(PageSize).Select(x => new ProductViewModels()
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
            var result = new CarViewModels<ProductViewModels>()
            {
                TotalRecord = EndPage,
                Items = data,
            };
            return result;
        }


    }
}
