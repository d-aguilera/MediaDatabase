using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MediaDatabase.Database.Entities
{
    [MetadataType(typeof(Metadata))]
    public partial class ScanRequest
    {
        [Display(Name = "Status")]
        public string StatusName => ((TaskStatus)Status).ToString();

        class Metadata
        {
            [MaxLength(32)]
            [Required]
            [Display(Name = "Volume")]
            public string VolumeName
            {
                get;
                set;
            }

            [Display(Name = "Status Code")]
            public int Status
            {
                get;
                set;
            }
        }
    }
}
