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
        Task<int> CreateCar(string Name, string Color, float Price, int Quantity, string Image, string Decription, int CategoryID);
        Task<int> UpdateCar(int CarId, string Name, string Color, float Price, int Quantity, string Image, string Decription, int CategoryID, bool Status);
        Task<int> DeleteCar(int CarID);

        Task<ProductViewModels> FindById(int CarID);
        Task<List<ProductViewModels>> GetAllPaging(int Cate, string SearchValue, int Index, int PageSize);
    }
}
