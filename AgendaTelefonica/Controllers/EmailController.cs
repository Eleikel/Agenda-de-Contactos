using AgendaTelefonica.Core.Application.Interfaces.Services;
using AgendaTelefonica.Core.Application.ViewModels.Email;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaTelefonica.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;


        public EmailController(IEmailService emailService, IUserService userService)
        {
            _emailService = emailService;
            _userService = userService;
        }

        public async Task<IActionResult> Index(int UserId)
        {
            var getAllVm = await _emailService.GetAllViewModelWithInclude(UserId);
            var userById = await _userService.GetByIdSaveViewModel(UserId);
            ViewBag.Name = userById.Name +" "+ userById.LastName;
            
            return View(getAllVm);
        }

        //Create
        public  IActionResult Create(int UserId)
        {
            SaveEmailViewModel vm = new();
            vm.UserId = UserId;
            return View("SaveEmail", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Create(SaveEmailViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveEmail", vm);
            }

            await _emailService.Add(vm);

            return RedirectToRoute(new { controller = "User", action = "Index" });

        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _emailService.GetByIdSaveViewModel(id));
        }


        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _emailService.Delete(id);

            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

    }
}
