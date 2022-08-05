using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "The contact's name is required in this field")]

        public string Name { get; set; }
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Document's number is required in this field")]
        [DataType(DataType.Text)]
        public string DocumentId { get; set; } //Cedula

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public bool Deleted { get; set; } = false;

        [Required(ErrorMessage = "The Phone number is required in this field")]
        [DataType(DataType.PhoneNumber)]

        public string Phone { get; set; }
        [Required(ErrorMessage = "The Email is required in this field")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
