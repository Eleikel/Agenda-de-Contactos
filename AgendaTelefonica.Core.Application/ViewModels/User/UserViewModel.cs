using AgendaTelefonica.Core.Application.ViewModels.Email;
using AgendaTelefonica.Core.Application.ViewModels.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.ViewModels.User
{
    public class UserViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set; } 
        public string Address { get; set; }
        public bool Deleted { get; set; }

        public ICollection<PhoneViewModel> Phones { get; set; }
        public ICollection<EmailViewModel> Emails { get; set; }

        public int PhonesQuantities { get; set; }
        public int EmailQuantities { get; set; }

    }
}
