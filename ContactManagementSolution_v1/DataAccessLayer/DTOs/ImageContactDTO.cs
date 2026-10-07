using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{

    public class ImageContactDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageContentType { get; set; }
    }

}
