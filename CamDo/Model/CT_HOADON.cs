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
    
    public partial class CT_HOADON
    {
        public int MaCT_HoaDon { get; set; }
        public Nullable<int> MaHoaDon { get; set; }
        public string TenVatTu { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> GiaCam { get; set; }
        public Nullable<int> GiaChuoc { get; set; }
        public Nullable<System.DateTime> HanChot { get; set; }
        public Nullable<int> TongTien { get; set; }
        public string TrangThai { get; set; }
    
        public virtual HOADON HOADON { get; set; }
    }
}
