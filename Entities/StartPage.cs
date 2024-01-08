using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cennet_Emlak.Entities
{
    public class StartPage
    {
        [Key]
        public int StarPageId { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        
    }
}