using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malfatti.Models.ViewModels
{
    public class CreateCartVMPartial
    {
        
        public IList<Shop>  Shops { get; set; }
        public IQueryable<CartVM> Carts { get; set; }
    }
}
