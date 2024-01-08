using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cennet_Emlak.Entities
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? MessageText { get; set; }
    }
}