using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cennet_Emlak.Models
{
    public class EditViewModel
    {
        public string Id {get;set;} = string.Empty;
        public string? Fullname { get; set; } 
        public string? Email { get; set; }  
        [DataType(DataType.Password)]
        public string? Password { get; set; }   
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Parola Eşleşmiyor")]
        public string? ConfirmPassword { get; set; } 
        public IList<string>? SelectedRoles {get;set;}
    }
}