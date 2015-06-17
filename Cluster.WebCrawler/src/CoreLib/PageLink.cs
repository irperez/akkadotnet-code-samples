namespace CoreLib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PageLink
    {
        [Key]
        public long Id { get; set; }

        public long PageMetadataId { get; set; }

        [Required]
        [StringLength(2083)]
        public string Uri { get; set; }
    }
}
