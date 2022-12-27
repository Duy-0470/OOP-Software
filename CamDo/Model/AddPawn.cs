using CamDo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamDo.Model
{
    public class AddPawn: BaseViewModel
    {
        private int number;
        public int Number { get => number; set { number = value; OnPropertyChanged(); } }

        private string tenVatTu;
        public string TenVatTu { get => tenVatTu; set { tenVatTu = value; OnPropertyChanged(); } }

        private string tenKhachHang;
        public string TenKhachHang { get => tenKhachHang; set { tenKhachHang = value; OnPropertyChanged(); } }

        private string cmnd;
        public string CMND { get => cmnd; set { cmnd = value; OnPropertyChanged(); } }

        private int soLuong;
        public int SoLuong { get => soLuong; set { soLuong = value; OnPropertyChanged(); } }

        private decimal thanhTien;
        public decimal ThanhTien { get => thanhTien; set { thanhTien = value; OnPropertyChanged(); } }

        private decimal tienCam;
        public decimal TienCam { get => tienCam; set { tienCam = value; OnPropertyChanged(); } }

        private decimal tienChuoc;
        public decimal TienChuoc { get => tienChuoc; set { tienChuoc = value; OnPropertyChanged(); } }

        private DateTime hanChot;
        public DateTime HanChot { get => hanChot; set { hanChot = value; OnPropertyChanged(); } }

        public int maHoaDon;
        public int MaHoaDon { get => maHoaDon; set { maHoaDon = value; OnPropertyChanged(); }}

        public string maKhachHang;
        public string MaKhachHang { get => maKhachHang; set { maKhachHang = value; OnPropertyChanged(); } }
    }
}
