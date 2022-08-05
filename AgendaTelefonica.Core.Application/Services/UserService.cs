using AgendaTelefonica.Core.Application.Interfaces.Repositories;
using AgendaTelefonica.Core.Application.Interfaces.Services;
using AgendaTelefonica.Core.Application.ViewModels.Email;
using AgendaTelefonica.Core.Application.ViewModels.Phone;
using AgendaTelefonica.Core.Application.ViewModels.User;
using AgendaTelefonica.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.Services
{
    public class UserService : GenericService<SaveUserViewModel, UserViewModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhoneRepository _phoneRepository;
        private readonly IEmailRepository _emailRepository;

        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, IMapper mapper, IPhoneRepository phoneRepository, IEmailRepository emailRepository) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _phoneRepository = phoneRepository;
            _emailRepository = emailRepository;
        }


        //GET ALL With Filter
        public async Task<List<UserViewModel>> GetAllViewModelWithFilter(FilterUserViewModel filters)
        {
            var contactList = await _userRepository.GetAllWithIncludeAsync(new List<string> { "Phones", "Emails" });

            var listViewModels = contactList.Where(contact => contact.Deleted == false).OrderByDescending(c => c.Name).Select(contact => new UserViewModel
            {
                Id = contact.Id,
                Name = contact.Name,
                LastName = contact.LastName,
                DocumentId = contact.DocumentId,
                Address = contact.Address,
                PhonesQuantities = contact.Phones.Count(),
                EmailQuantities = contact.Emails.Count()

            }).ToList();


            if (filters.Name != null)
            {
                listViewModels = listViewModels.Where(contact => contact.Name.Trim() == filters.Name.Trim() || contact.LastName == filters.Name).ToList();
            }

            return listViewModels;

        }



        public override async Task<List<UserViewModel>> GetAllViewModel()
        {
            var contactList = await _userRepository.GetAllWithIncludeAsync(new List<string> { "Phones", "Emails" });
            await base.GetAllViewModel();

            return contactList.Where(contact => contact.Deleted == false).OrderByDescending(c => c.Name).Select(contact => new UserViewModel
            {
                Id = contact.Id,
                Name = contact.Name,
                LastName = contact.LastName,
                DocumentId = contact.DocumentId,
                Address = contact.Address,
                PhonesQuantities = contact.Phones.Count(),
                EmailQuantities = contact.Emails.Count()
            }).ToList();
        }



        //Add Phone to user
        public async Task<PhoneViewModel> AddUserPhone(int userId, string phoneNumber)
        {
            Phone phone = new()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            var userPhone = await _phoneRepository.AddAsync(phone);
            return _mapper.Map<PhoneViewModel>(userPhone);
        }


        //Add Email to user
        public async Task<EmailViewModel> AddUserEmail(int userId, string email)
        {
            Email emailAddress = new()
            {
                UserId = userId,
                EmailAddress = email
            };

            var userEmail = await _emailRepository.AddAsync(emailAddress);
            return _mapper.Map<EmailViewModel>(userEmail);
        }


    }
}
