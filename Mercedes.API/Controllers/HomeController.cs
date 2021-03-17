using Mercedes.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercedes.API.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("Home")]
        public IEnumerable<TblCar> GetAll()
        {
            using (var context = new MercedesStoreContext())
            {
                return context.TblCars.Where<TblCar>(x => x.Status == true).ToList();
            }
        }

        //public ActionResult Home()
        //{
        //    using (var context = new MercedesStoreContext())
        //    {
        //        var list =  context.TblCars.Where<TblCar>(x => x.Status == true).ToList();
        //        if (list != null)
        //        {
        //            List<TblCar> listCar = new List<TblCar>();
        //            foreach (var item in list)
        //            {
        //                listCar.Add(new TblCar(item.CarId, item.Name, item.Color, item.Price, item.Quantity, item.Image, item.Description, item.CategoryId, item.Status, null, null));
        //            }
        //            return Json(listCar, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(null, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //}

        [HttpGet]
        [Route("Home/GetColor")]
        public IEnumerable<TblCar> GetColor()
        {
            using (var context = new MercedesStoreContext())
            {
                return context.TblCars.Where<TblCar>(x => x.Color == "dark").ToList();
            }
        }
    }
}
