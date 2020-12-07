using System;
using System.Collections.Generic;
using System.Text;
using ZenGym.Domain.Common;
using ZenGym.Domain.Entities.Model;

namespace ZenGym.Domain.Entities.Model
{
    public class SellItem : BaseEntity
    {

        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
