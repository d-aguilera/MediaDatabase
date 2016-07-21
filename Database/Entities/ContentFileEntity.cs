using MediaDatabase.Common;

using System;
using System.ComponentModel.DataAnnotations;

namespace MediaDatabase.Database.Entities
{
    [MetadataType(typeof(Metadata))]
    public partial class ContentFile
    {
        [Display(Name = "Full Name")]
        public string FullName => System.IO.Path.Combine(Path, Name);

        [Display(Name = "Path")]
        public string CompactPath => Helpers.CompactPath(Path, 64);

        [Display(Name = "Full Name")]
        public string CompactFullName => Helpers.CompactPath(FullName, 80);

        class Metadata
        {
            [MaxLength(256)]
            [Required]
            public string Path
            {
                get;
                set;
            }

            [MaxLength(128)]
            [Required]
            public string Name
            {
                get;
                set;
            }

            [Display(Name = "Created")]
            [DisplayFormat(DataFormatString = "{0:MMM d yyyy}")]
            public DateTime CreationTimeUtc
            {
                get;
                set;
            }

            [Display(Name = "Last Updated")]
            [DisplayFormat(DataFormatString = "{0:MMM d yyyy}")]
            public DateTime LastWriteTimeUtc
            {
                get;
                set;
            }
        }
    }
}
