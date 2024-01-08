using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cennet_Emlak.Models
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Email {get;set;} = null!;
        [DataType(DataType.Password)]
        public string Password {get;set;} = null!;
    }
}