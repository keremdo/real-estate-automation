using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cennet_Emlak.Entities
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        public string? Description1 { get; set; }
        public string? Description2 { get; set; }
    }
}