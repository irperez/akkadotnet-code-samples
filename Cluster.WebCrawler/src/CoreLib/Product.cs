using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public class Product : Category
    {
        [MaxLength(20)]
        public string ManufacturerPartNumber { get; set; }

        [MaxLength(50)]
        public string Brand { get; set; }

        [MaxLength(20)]
        public string Price { get; set; }

        [MaxLength(20)]
        public string Color { get; set; }

        [MaxLength(50)]
        public string Model { get; set; }

        [MaxLength(20)]
        public string ProductId { get; set; }
        public DateTime ReleaseDate { get; set; }

        [MaxLength(20)]
        public string Sku { get; set; }

        [MaxLength(1024)]
        public string LogoUrl { get; set; }
    }
}
