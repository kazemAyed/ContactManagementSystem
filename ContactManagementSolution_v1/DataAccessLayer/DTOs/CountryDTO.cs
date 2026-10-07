using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public class CountryDTO
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; } = null;
        public string Code { get; set; } = null;
        public string PhoneCode { get; set; } = null;
    }
}
