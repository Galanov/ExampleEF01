﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace efex03.Models.Scaffold
{
    public partial class ShoeCategoryJunction
    {
        public long Id { get; set; }
        public long ShoeId { get; set; }
        public long CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Shoes Shoe { get; set; }
    }
}
