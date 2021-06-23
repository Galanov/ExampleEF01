using System;
using System.Collections.Generic;

namespace efex03.Models.Scaffold
{
    public partial class Shoes
    {
        public Shoes()
        {
            ShoeCategoryJunction = new HashSet<ShoeCategoryJunction>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long ColorId { get; set; }
        public decimal Price { get; set; }

        public virtual Colors Color { get; set; }
        public virtual SalesCampaigns SalesCampaigns { get; set; }
        public virtual ICollection<ShoeCategoryJunction> ShoeCategoryJunction { get; set; }
    }
}
