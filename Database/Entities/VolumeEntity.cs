using System.ComponentModel.DataAnnotations;

namespace MediaDatabase.Database.Entities
{
    [MetadataType(typeof(Metadata))]
    public partial class Volume
    {
        class Metadata
        {
            [MaxLength(64)]
            [Required]
            public string Caption
            {
                get;
                set;
            }

            [MaxLength(16)]
            [Required]
            [Display(Name = "File System")]
            public string FileSystem
            {
                get;
                set;
            }

            [MaxLength(32)]
            [Required]
            [Display(Name = "Volume")]
            public string VolumeName
            {
                get;
                set;
            }

            [MaxLength(11)]
            [Required]
            [Display(Name = "Serial Number")]
            public string VolumeSerialNumber
            {
                get;
                set;
            }
        }
    }
}
