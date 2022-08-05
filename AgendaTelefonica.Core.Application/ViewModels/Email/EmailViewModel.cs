using AgendaTelefonica.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.ViewModels.Email
{
    public class EmailViewModel
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }

        public string UserName { get; set; }
        public string UserLastName { get; set; }

    }
}
