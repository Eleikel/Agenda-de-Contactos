using AgendaTelefonica.Core.Application.ViewModels.Email;
using AgendaTelefonica.Core.Application.ViewModels.Phone;
using AgendaTelefonica.Core.Application.ViewModels.User;
using AgendaTelefonica.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel, User>
    {
        Task<EmailViewModel> AddUserEmail(int userId, string email);
        Task<PhoneViewModel> AddUserPhone(int userId, string phoneNumber);
        Task<List<UserViewModel>> GetAllViewModelWithFilter(FilterUserViewModel filters);
    }
}
