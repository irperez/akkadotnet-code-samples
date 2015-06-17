using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CoreLib
{
    public partial class IndexedContent
    {
        public IndexedContent() {
        }
        public IndexedContent(long id)
        {
            //this.Id = id;
            //this.PageMetadataId = id;
        }
        //[Key, ForeignKey("Metadata")]
        //public long Id { get; set; }

        //[BsonId]
        //public ObjectId Id { get; set; }

        [BsonId]
        public string Uri { get; set; }

        [MaxLength(1024)]
        public string Title { get; set; }

        [Required]
        public string WordData { get; set; }

        //public virtual PageMetadata Metadata { get; set; }
        public ObjectId Metadata { get; set; }

        [Required]
        public long PageMetadataId { get; set; }

        [MaxLength(1100)]
        public string ImageUrl { get; set; }

        [MaxLength(1100)]
        public string ThumbnailUrl { get; set; }
        
        public string Description { get; set; }

        [MaxLength(8000)]
        public string Keywords { get; set; }

        [MaxLength(200)]
        public string Author { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime? DateModified { get; set; }

        [MaxLength(100)]
        public string Genre { get; set; }

        [MaxLength(100)]
        public string Language { get; set; }
        public int? InteractionCount { get; set; }

        [MaxLength(50)]
        public string DocumentType { get; set; }
        public DateTime? LastIndexedDate { get; set; }
    }
}
