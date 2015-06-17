namespace CoreLib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PageContent
    {
        //[Key, ForeignKey("Metadata")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        //[Required]
        //public string Content { get; set; }

        [Required]
        public byte[] Content { get; set; }

        //public string ArticleContent { get; set; }

        //public virtual PageMetadata Metadata { get; set; }

        //[Required]
        //public long PageMetadataId { get; set; }

        protected string _unzippedContents;
        public string UnzipContents()
        {
            if (this.Content != null)
            {
                if (string.IsNullOrWhiteSpace(_unzippedContents))
                {
                    _unzippedContents = Utilities.Compression.Unzip(this.Content);                    
                }

                return _unzippedContents;
            }
            else
            {
                return null;
            }
        }

        public void ZipContents(string data)
        {
            this.Content = Utilities.Compression.Zip(data);
        }
    }
}
