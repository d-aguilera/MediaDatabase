using System.ComponentModel.DataAnnotations;

namespace MediaDatabase.Database.Entities
{
    [MetadataType(typeof(Metadata))]
    public partial class Partition
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

            [Display(Name = "Disk #")]
            public int DiskIndex
            {
                get;
                set;
            }

            [Display(Name = "Partition #")]
            public int PartitionIndex
            {
                get;
                set;
            }
        }
    }
}
