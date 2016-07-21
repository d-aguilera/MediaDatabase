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
    
    public partial class ContentFile
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public System.DateTime CreationTimeUtc { get; set; }
        public System.DateTime LastWriteTimeUtc { get; set; }
        public System.DateTimeOffset Created { get; set; }
        public Nullable<System.DateTimeOffset> LastUpdated { get; set; }
    
        public virtual Content Content { get; set; }
        public virtual Volume Volume { get; set; }
    }
}
