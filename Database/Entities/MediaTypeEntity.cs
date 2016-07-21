using System.ComponentModel.DataAnnotations;

namespace MediaDatabase.Database.Entities
{
    [MetadataType(typeof(Metadata))]
    public partial class MediaType
    {
        class Metadata
        {
            [MaxLength(64)]
            [Required]
            [Display(Name = "Media Type")]
            public string Name
            {
                get;
                set;
            }
        }
    }
}
