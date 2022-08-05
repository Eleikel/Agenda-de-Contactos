using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application.ViewModels.Phone
{
    public class SavePhoneViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "The Phone number is required in this field")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        //public UserViewModel User { get; set; }
    }
}
