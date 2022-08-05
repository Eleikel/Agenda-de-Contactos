using AgendaTelefonica.Core.Application.Interfaces.Repositories;
using AgendaTelefonica.Core.Application.Interfaces.Services;
using AgendaTelefonica.Core.Application.ViewModels.Phone;
using AgendaTelefonica.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.Services
{
    public class PhoneService : GenericService<SavePhoneViewModel, PhoneViewModel, Phone>, IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IMapper _mapper;


        public PhoneService(IPhoneRepository phoneRepository, IMapper mapper) : base(phoneRepository, mapper)
        {
            _phoneRepository = phoneRepository;
            _mapper = mapper;
        }




        public async Task<List<PhoneViewModel>> GetAllViewModelWithInclude(int userId)
        {
            var phoneList = await _phoneRepository.GetAllWithIncludeAsync(new List<string> { "User" });

            return phoneList.Where(phone => phone.UserId == userId).Select(phone => new PhoneViewModel
            {
                Id = phone.Id,
                PhoneNumber = phone.PhoneNumber,
                UserId = phone.UserId,
                UserName = phone.User.Name,
                UserLastName = phone.User.LastName
            }).ToList();
        }


    }
}
