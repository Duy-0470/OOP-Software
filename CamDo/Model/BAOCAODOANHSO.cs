//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CamDo.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BAOCAODOANHSO
    {
        public int MaBCDS { get; set; }
        public Nullable<System.DateTime> ThoiGian { get; set; }
        public Nullable<decimal> TongDoanhThu { get; set; }
    
        public virtual CT_BCDS CT_BCDS { get; set; }
    }
}
