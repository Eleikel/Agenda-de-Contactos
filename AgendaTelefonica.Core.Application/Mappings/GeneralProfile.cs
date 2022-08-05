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

namespace AgendaTelefonica.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.PhonesQuantities, opt => opt.Ignore())
                .ForMember(x => x.EmailQuantities, opt => opt.Ignore())
                .ReverseMap()
                //.ForMember(x => x.Phones, opt => opt.Ignore())
                .ForMember(x => x.Emails, opt => opt.Ignore());

            CreateMap<User, SaveUserViewModel>()
                .ForMember(x => x.Phone, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Phones, opt => opt.Ignore())
                .ForMember(x => x.Emails, opt => opt.Ignore());

            CreateMap<UserViewModel, SaveUserViewModel>()
                .ForMember(x => x.Phone, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.EmailQuantities, opt => opt.Ignore())
                .ForMember(x => x.PhonesQuantities, opt => opt.Ignore())
                .ForMember(x => x.Emails, opt => opt.Ignore())
                .ForMember(x => x.Phones, opt => opt.Ignore());


            CreateMap<Email, EmailViewModel>()
                .ForMember(x => x.UserName, opt => opt.Ignore())
                .ForMember(x => x.UserLastName, opt => opt.Ignore())

                .ReverseMap();


            CreateMap<Email, SaveEmailViewModel>()
                .ReverseMap();


            CreateMap<SaveEmailViewModel, EmailViewModel>()
                .ForMember(x => x.UserName, opt => opt.Ignore())
                .ForMember(x => x.UserLastName, opt => opt.Ignore())
                .ReverseMap();




            CreateMap<Phone, PhoneViewModel>()
                .ForMember(x => x.UserName, opt => opt.Ignore())
                .ForMember(x => x.UserLastName, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<Phone, SavePhoneViewModel>()
                .ReverseMap();


            CreateMap<SavePhoneViewModel, PhoneViewModel>()
                .ForMember(x => x.UserName, opt => opt.Ignore())
                .ForMember(x => x.UserLastName, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
