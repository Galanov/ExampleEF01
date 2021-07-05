using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace efex03.Models.Scaffold
{
    public partial class Categories
    {
        public Categories()
        {
            ShoeCategoryJunction = new HashSet<ShoeCategoryJunction>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ShoeCategoryJunction> ShoeCategoryJunction { get; set; }
    }
}
