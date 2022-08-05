using AgendaTelefonica.Core.Application.Interfaces.Repositories;
using AgendaTelefonica.Core.Application.Interfaces.Services;
using AgendaTelefonica.Core.Application.ViewModels.Email;
using AgendaTelefonica.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.Services
{
    public class EmailService : GenericService<SaveEmailViewModel, EmailViewModel, Email>, IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;


        public EmailService(IEmailRepository emailRepository, IMapper mapper) : base(emailRepository, mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }


        public async Task<List<EmailViewModel>> GetAllViewModelWithInclude(int userId)
        {
            var emailList = await _emailRepository.GetAllWithIncludeAsync(new List<string> { "User" });

            return emailList.Where(email => email.UserId == userId).Select(email => new EmailViewModel
            {
                Id = email.Id,
                EmailAddress = email.EmailAddress,
                UserId = email.UserId,
                UserName = email.User.Name,
                UserLastName = email.User.LastName
            }).ToList();
        }
    }
}
