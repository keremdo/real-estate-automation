using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Cennet_Emlak.Entities
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Fullname {get;set;} = string.Empty;
    }
}