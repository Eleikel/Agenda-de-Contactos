using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set; } //Cedula
        public string Address { get; set; }
        public bool Deleted { get; set; }

        //Navigation Properties
        public ICollection<Phone> Phones { get; set; }
        public ICollection<Email> Emails { get; set; }

    }
}
