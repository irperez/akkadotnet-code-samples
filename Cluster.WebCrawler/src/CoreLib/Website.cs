using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public class Website
    {

        public int Id { get; set; }

        [MaxLength(1100)]
        public string Url { get; set; }

        public DateTime? LastCrawlDate { get; set; }
    }
}
