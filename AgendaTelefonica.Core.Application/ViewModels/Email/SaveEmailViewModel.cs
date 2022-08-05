using AgendaTelefonica.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.ViewModels.Email
{
    public class SaveEmailViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Email is required in this field")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }
    }
}
