using eShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Core.ViewModels
{
    public class BasketItem : BaseEntity
    {
        public string BasketID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
    }
}