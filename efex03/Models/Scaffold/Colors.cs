using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace efex03.Models.Scaffold
{
    public partial class Colors
    {
        public Colors()
        {
            Shoes = new HashSet<Shoes>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string MainColor { get; set; }
        public string HighlightColor { get; set; }

        public virtual ICollection<Shoes> Shoes { get; set; }
    }
}
