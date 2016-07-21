//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediaDatabase.Database.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Volume
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Volume()
        {
            this.ContentFiles = new HashSet<ContentFile>();
            this.IgnoredFolders = new HashSet<IgnoredFolder>();
        }
    
        public int Id { get; set; }
        public string Caption { get; set; }
        public string FileSystem { get; set; }
        public string VolumeName { get; set; }
        public string VolumeSerialNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentFile> ContentFiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IgnoredFolder> IgnoredFolders { get; set; }
        public virtual Partition Partition { get; set; }
    }
}