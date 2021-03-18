using Mercedes.Application.Catalog.Cars.Dtos;
using Mercedes.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mercedes.Application.Catalog.Cars
{
    public interface ICarViewService
    {
        Task<CarViewModels<ProductViewModels>> GetAllCarPaging(int Cate, string SearchValue, int Index, int PageSize);

    }
}
