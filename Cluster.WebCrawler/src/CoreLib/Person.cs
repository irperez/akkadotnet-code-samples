using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public class Person : Category
    {
        [MaxLength(200)]
        public string AdditionalName { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Affiliation { get; set; }

        [MaxLength(100)]
        public string AlumniOf { get; set; }

        [MaxLength(200)]
        public string Award { get; set; }
        public DateTime? BirthDate { get; set; }

        [MaxLength(200)]
        public string BirthPlace { get; set; }

        [MaxLength(100)]
        public string Brand { get; set; }
        public DateTime? DeathDate { get; set; }

        [MaxLength(200)]
        public string DeathPlace { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(100)]
        public string Nationality { get; set; }

        [MaxLength(100)]
        public string Spouse { get; set; }
    }
}
