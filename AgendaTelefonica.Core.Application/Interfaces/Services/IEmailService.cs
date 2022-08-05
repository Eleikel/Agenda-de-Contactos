using AgendaTelefonica.Core.Application.ViewModels.Email;
using AgendaTelefonica.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.Interfaces.Services
{
    public interface IEmailService : IGenericService<SaveEmailViewModel, EmailViewModel, Email>
    {
        Task<List<EmailViewModel>> GetAllViewModelWithInclude(int userId);
    }
}
