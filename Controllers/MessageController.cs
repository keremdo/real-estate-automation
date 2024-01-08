using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Data.Abstract;
using Cennet_Emlak.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cennet_Emlak.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageRepository _messageRepo;
        public MessageController(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }
        public IActionResult Index()
        {
            var messages = _messageRepo.Values.ToList();
            return View(messages);
        }

        public IActionResult Details(int id)
        {
            var model = _messageRepo.Values.FirstOrDefault(m => m.MessageId == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _messageRepo.Delete(id);
            return Json(new {success = true});
        }

        [HttpPost]
        public IActionResult Create(Message model)
        {
          _messageRepo.Create(model);
          return RedirectToAction("Index","Home");
        }
    }
}