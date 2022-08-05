using AgendaTelefonica.Core.Application.Interfaces.Services;
using AgendaTelefonica.Core.Application.ViewModels.Phone;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgendaTelefonica.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IPhoneService _phoneService;
        private readonly IUserService _userService;



        public PhoneController(IPhoneService phoneService, IUserService userService)
        {
            _phoneService = phoneService;
            _userService = userService;
        }


        public async Task<IActionResult> Index(int UserId)
        {
            var getAllVm = await _phoneService.GetAllViewModelWithInclude(UserId);

            var userById = await _userService.GetByIdSaveViewModel(UserId);
            ViewBag.Name = userById.Name + " " + userById.LastName;

            return View(getAllVm);
        }

        //Create
        public IActionResult Create(int UserId)
        {
            SavePhoneViewModel vm = new();
            vm.UserId = UserId;
            return View("SavePhone", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Create(SavePhoneViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePhone", vm);
            }

            await _phoneService.Add(vm);

            return RedirectToRoute(new { controller = "User", action = "Index" });
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _phoneService.GetByIdSaveViewModel(id));
        }


        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _phoneService.Delete(id);

            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
    }
}
