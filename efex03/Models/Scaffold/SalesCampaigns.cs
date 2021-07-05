using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace efex03.Models.Scaffold
{
    public partial class SalesCampaigns
    {
        public long Id { get; set; }
        public string Slogan { get; set; }
        public int? MaxDiscount { get; set; }
        public DateTime? LaunchDate { get; set; }
        public long ShoeId { get; set; }

        public virtual Shoes Shoe { get; set; }
    }
}
