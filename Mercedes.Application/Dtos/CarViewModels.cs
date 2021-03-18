using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.Application.Dtos
{
    public class CarViewModels<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
