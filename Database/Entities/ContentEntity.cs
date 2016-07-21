using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MediaDatabase.Database.Entities
{
    [MetadataType(typeof(Metadata))]
    public partial class Content
    {
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "Does not apply.")]
        [Display(Name = "Hash")]
        public string HashLowercase => Hash.ToLowerInvariant();

        class Metadata
        {
            [MaxLength(128)]
            [Display(Name = "Content Type")]
            public string ContentType
            {
                get;
                set;
            }

            [MaxLength(32)]
            public string Hash
            {
                get;
                set;
            }
        }
    }
}
