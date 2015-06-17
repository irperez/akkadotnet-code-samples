using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public class SearchResult 
    {
        public long Id { get; set; }
        public long Rowid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentType { get; set; }
        public DateTime DatePublished { get; set; }
        public long PageMetadataId { get; set; }
        public string Uri { get; set; }
        public int Rank { get; set; }
        public int TotalRows { get; set; }
    }
}
