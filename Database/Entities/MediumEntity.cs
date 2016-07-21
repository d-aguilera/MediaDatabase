using MediaDatabase.Common;

using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MediaDatabase.Database.Entities
{
    [MetadataType(typeof(Metadata))]
    public partial class Medium
    {
        [Display(Name = "Size")]
        public string PrintableSize
        {
            get
            {
                var tuple = Helpers.FormatBytes(Size);
                var number = tuple.Item1;
                var unit = tuple.Item2;
                return string.Format(CultureInfo.InvariantCulture, "{0:0.00} {1}", number, unit);
            }
        }

        class Metadata
        {
            [MaxLength(64)]
            [Required]
            public string Caption
            {
                get;
                set;
            }

            [MaxLength(64)]
            [Required]
            [Display(Name = "Serial Number")]
            public string SerialNumber
            {
                get;
                set;
            }
        }
    }
}
