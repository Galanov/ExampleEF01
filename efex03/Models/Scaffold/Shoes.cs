using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
        public long? FittingId { get; set; }

        public virtual Colors Color { get; set; }
        public virtual Fittings Fitting { get; set; }
        public virtual SalesCampaigns SalesCampaigns { get; set; }
        public virtual ICollection<ShoeCategoryJunction> ShoeCategoryJunction { get; set; }
    }
}
