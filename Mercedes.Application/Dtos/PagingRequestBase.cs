using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.Application.Dtos
{
    public class PagingRequestBase
    {
        public int Index { get; set; }
        public int PageSize { get; set; }

    }
}
