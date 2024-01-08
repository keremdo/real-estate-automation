using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Entities;

namespace Cennet_Emlak.Models
{
    public class IndexViewModel
    {
        public List<StartPage> StartPages {get;set;} = new List<StartPage>();
        public List<About> Abouts {get;set;} = new List<About>();
        public List<Portfolio> Portfolios {get;set;} = new List<Portfolio>();
        public List<Message> Messages {get;set;} = new List<Message>();
        public Message Message {get; set;} = null!;
    }
}