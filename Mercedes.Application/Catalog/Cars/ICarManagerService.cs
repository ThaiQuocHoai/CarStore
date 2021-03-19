using Mercedes.Application.Catalog.Cars.Dtos;
using Mercedes.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mercedes.Application.Catalog.Cars
{
    public interface ICarManagerService
    {
        Task<int> CreateCar(CreateCarRequest request);
        Task<int> UpdateCar(UpdateCarRequest request);
        Task<int> DeleteCar(int CarID);

        Task<List<ProductViewModels>> GetAllPaging(int Cate, string SearchValue, int Index, int PageSize);
    }
}
