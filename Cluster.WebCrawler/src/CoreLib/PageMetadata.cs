namespace CoreLib
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PageMetadata")]
    public partial class PageMetadata : IMongoEntity
    {
        public PageMetadata()
        {
            _links = new List<PageLink>();
        }

        //[Key]
        //public long Id { get; set; }
        [BsonId]
        public ObjectId Id { get; set; }

        [StringLength(50)]
        public string Charset { get; set; }

        [StringLength(50)]
        public string Encoding { get; set; }

        [Required]
        [StringLength(2083)]
        public string Uri { get; set; }

        [Required]
        [StringLength(2083)]
        public string ParentUri { get; set; }

        public virtual PageContent Content { get; set; }

        private IList<PageLink> _links;
        public virtual IList<PageLink> Links
        {
            get { return _links;}
            set { _links = value; }
        }

        public DateTime CreatedDate { get; set; }

        [BsonIgnore]
        public IndexedContent Index {get;set;}
    }
}
