using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cennet_Emlak.Entities
{
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool SaleStatus { get; set; }
    }
}