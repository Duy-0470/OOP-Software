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
    
    public partial class CT_THUTIEN
    {
        public int MaCT_ThuTien { get; set; }
        public Nullable<int> MaThuTien { get; set; }
        public string TenVatTu { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> GiaChuoc { get; set; }
        public Nullable<int> ThanhTien { get; set; }
    
        public virtual THUTIEN THUTIEN { get; set; }
    }
}
