using AgendaTelefonica.Core.Application.ViewModels.Phone;
using AgendaTelefonica.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.Interfaces.Services
{
    public interface IPhoneService : IGenericService<SavePhoneViewModel, PhoneViewModel, Phone>
    {
        Task<List<PhoneViewModel>> GetAllViewModelWithInclude(int userId);
    }
}
