using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efex03.Models.Manual
{
    [Table("Colors")]
    public class Style
    {
        [Key]
        [Column("Id")]
        public long UniqueIdent { get; set; }
        [Column("Name")]
        public string StyleName { get; set; }
        public string MainColor { get; set; }
        public string HighlightColor { get; set; }
    }
}
