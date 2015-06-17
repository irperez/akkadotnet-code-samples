using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using System.ComponentModel.DataAnnotations;

namespace CoreLib
{
    public class Place : Category
    {
        [MaxLength(50)]
        public string AddressCountry { get; set; }//We need to think about how to express this one.

        [MaxLength(100)]
        public string AddressLocality { get; set; }

        [MaxLength(100)]
        public string AddressRegion { get; set; }

        [MaxLength(20)]
        public string PostOfficeBoxNumber { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(50)]
        public string StreetAddress { get; set; }

        public float? AverageRating { get; set; }
        public int? RatingCount { get; set; }
        public int? BestRating { get; set; }
        public int? WorstRating { get; set; }

        [MaxLength(20)]
        public string FaxNumber { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(13)]
        public string GlobalLocationNumber { get; set; }

        [MaxLength(1024)]
        public string MapUrl { get; set; }

        public int? InteractionCount { get; set; }

        [MaxLength(50)]
        public string IsicV4 { get; set; }

        [MaxLength(1024)]
        public string LogoUrl { get; set; }

        [MaxLength(1024)]
        public string PhotoUrl { get; set; }

        [MaxLength(20)]
        public string GeoElevation { get; set; }

        [MaxLength(20)]
        public string GeoLatitude { get; set; }

        [MaxLength(20)]
        public string GeoLongitude { get; set; }

        [MaxLength(10)]
        public string Closes { get; set; }

        [MaxLength(10)]
        public string Opens { get; set; }

        [MaxLength(500)]
        public string DaysOfWeek { get; set; }
    }
}
