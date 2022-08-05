using AgendaTelefonica.Core.Application.Interfaces.Services;
using AgendaTelefonica.Core.Application.ViewModels.Email;
using AgendaTelefonica.Core.Application.ViewModels.Phone;
using AgendaTelefonica.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPhoneService _phoneService;
        private readonly IEmailService _emailService;


        public UserController(IUserService userService, IPhoneService phoneService, IEmailService emailService)
        {
            _userService = userService;
            _phoneService = phoneService;
            _emailService = emailService;
        }


        public async Task<IActionResult> Index(FilterUserViewModel vm)
        {
            var contacts = await _userService.GetAllViewModelWithFilter(vm);
            var phones = await _phoneService.GetAllViewModel();
            var emails = await _emailService.GetAllViewModel();

            foreach (var contact in contacts)
            {
                contact.Phones = phones;
                contact.Emails = emails;
            }


            return View(contacts);
        }


        public IActionResult Create()
        {
            SaveUserViewModel userVm = new();
            return View("SaveUser", userVm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveUser", vm);
            }

            SaveUserViewModel addUser = await _userService.Add(vm);
            if (addUser != null)
            {
                await _userService.AddUserPhone(addUser.Id, vm.Phone);
                await _userService.AddUserEmail(addUser.Id, vm.Email);
            }        

            return RedirectToRoute(new { controller = "User", action = "Index" });
        }





        public async Task<IActionResult> Edit(int id)
        {
            SaveUserViewModel vm = await _userService.GetByIdSaveViewModel(id);
            return View("SaveUser", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(SaveUserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveUser", vm);
            }

            await _userService.Update(vm, vm.Id);
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }




        public async Task<IActionResult> Delete(int id)
        {
            return View(await _userService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            SaveUserViewModel contact = await _userService.GetByIdSaveViewModel(id);

            if (contact.Deleted == false)
            {
                contact.Deleted = true;
            }

            await _userService.Update(contact, id);

            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
    }
}
