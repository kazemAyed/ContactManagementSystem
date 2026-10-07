using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public class ContactDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string Email { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Address { get; set; } = null;
        public int CountryID { get; set; }
        public int ImageID { get; set; }
        public DateTime? DateOfBirth { get; set; } 
    }
}
