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
        public async Task<List<ProductViewModels>> GetAllCarPaging(int Cate, string SearchValue, int Index, int PageSize)
        {
            var query = _context.Cars.Where(x => x.Status == true && x.CategoryID == Cate && x.Name.Contains(SearchValue));
            if (query == null) throw new MercedesException("Cannot find a product");
            var data = await query.Skip((Index-1)*PageSize).Take(PageSize)
                .Select(x => new ProductViewModels()
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


    }
}
