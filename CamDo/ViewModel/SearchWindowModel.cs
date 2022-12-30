using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CamDo.ViewModel
{
    public class SearchWindowModel : BaseViewModel
    {
        public List<string> Option { get; set; }
        private string selectedItem;
        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        private string tenKH;
        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; OnPropertyChanged(); }
        }

        private string customerID;
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; OnPropertyChanged(); }
        }

        private string billID;
        public string BillID
        {
            get { return billID; }
            set { billID = value; OnPropertyChanged(); }
        }

        private string pawnName;
        public string PawnName
        {
            get { return pawnName; }
            set { pawnName = value; OnPropertyChanged(); }
        }

        private string cMND;
        public string CMND
        {
            get { return cMND; }
            set { cMND = value; OnPropertyChanged(); }
        }

        private string inputedItem;
        public string InputedItem
        {
            get { return inputedItem; }
            set
            {
                inputedItem = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ObjectNumbericalOrder> ctHoaDonList;
        public ObservableCollection<ObjectNumbericalOrder> CTHoaDonList
        {
            get { return ctHoaDonList; }
            set { ctHoaDonList = value; OnPropertyChanged(nameof(CTHoaDonList)); }
        }
        public ICommand SearchCommand { get; set; }
        public SearchWindowModel()
        {
            this.Option = new List<string>() { "Tên hàng hóa", "Mã hóa đơn", "Tên khách hàng","CMND" };
            SearchCommand = new RelayCommand<object>((p) =>
            {
                if (/*string.IsNullOrEmpty(InputedItem) ||*/ string.IsNullOrEmpty(SelectedItem))
                    return false;
                else return true;
            }
            , (p) =>
            {
                CTHoaDonList = new ObservableCollection<ObjectNumbericalOrder>();
                List<CT_HOADON> list = new List<CT_HOADON>();
                switch (SelectedItem)
                {
                    case "Tên hàng hóa":
                        list = SearchByObjectName();
                        break;
                    case "Mã hóa đơn":
                        list = SeachByBill();
                        break;
                    case "Tên khách hàng":
                        list = SearchByCustomerName();
                        break;
                    case "CMND":
                        list = SearchByCMND();
                        break;
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("Không có đối tượng bạn cần tìm");
                    return;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ObjectNumbericalOrder objectNumbericalOrder = new ObjectNumbericalOrder();
                    objectNumbericalOrder.Number = i + 1;
                    objectNumbericalOrder.CT_HOADON = list[i];
                    objectNumbericalOrder.CustomerName = TenKH;
                    objectNumbericalOrder.CT_HOADON.TongTien = objectNumbericalOrder.CT_HOADON.SoLuong * objectNumbericalOrder.CT_HOADON.GiaChuoc;
                    CTHoaDonList.Add(objectNumbericalOrder);
                }
            }
            );
        }

        private List<CT_HOADON> SearchByObjectName()
        {
            List<CT_HOADON> result = DataProvider.Ins.DB.CT_HOADON.Where(x => x.TenVatTu.Contains(InputedItem) ).ToList();
            BillID = DataProvider.Ins.DB.CT_HOADON.Where(x => x.TenVatTu.Contains(InputedItem)).Select(x => x.MaHoaDon).FirstOrDefault().ToString();
            CustomerID = DataProvider.Ins.DB.HOADON.Where(x => x.MaHoaDon.ToString() == BillID).Select(x => x.MaKhachHang).FirstOrDefault().ToString();
            TenKH = DataProvider.Ins.DB.KHACHHANG.Where(x => x.MaKhachHang == CustomerID).Select(x => x.TenKhachHang).FirstOrDefault();
            return result;

        }
        private List<CT_HOADON> SeachByBill()
        {
            List<CT_HOADON> result = DataProvider.Ins.DB.CT_HOADON.Where(x => x.MaHoaDon.ToString() == InputedItem).ToList();

            BillID = DataProvider.Ins.DB.CT_HOADON.Where(x => x.MaHoaDon.ToString().Contains(InputedItem)).Select(x => x.MaHoaDon).FirstOrDefault().ToString();
            CustomerID = DataProvider.Ins.DB.HOADON.Where(x => x.MaHoaDon.ToString() == BillID).Select(x => x.MaKhachHang).FirstOrDefault().ToString();
            TenKH = DataProvider.Ins.DB.KHACHHANG.Where(x => x.MaKhachHang == CustomerID).Select(x => x.TenKhachHang).FirstOrDefault();
            return result;

        }
        private List<CT_HOADON> SearchByCustomerName()
        {
            List<CT_HOADON> result = new List<CT_HOADON>();
            List<KHACHHANG> kH = DataProvider.Ins.DB.KHACHHANG.Where(x => x.TenKhachHang.Contains(InputedItem)).ToList();
            
            if ( kH.Count > 0)
            {
                foreach (var TenKH in kH)
                {
                    List<HOADON> hDon = DataProvider.Ins.DB.HOADON.Where(x => x.MaKhachHang == TenKH.MaKhachHang).ToList();
                    tenKH = TenKH.TenKhachHang;
                    foreach (var item in hDon)
                    {
                        var ctHoaDon = DataProvider.Ins.DB.CT_HOADON.Where(x => x.MaHoaDon == item.MaHoaDon).ToList();
                        result.AddRange(ctHoaDon);
                    }
                }
                
            }
            
            return result;
        }
        private List<CT_HOADON> SearchByCMND()
        {
            List<CT_HOADON> result = new List<CT_HOADON>();

            CMND = DataProvider.Ins.DB.KHACHHANG.Where(x => x.CMND.Contains(InputedItem.ToString())).Select(x => x.CMND).FirstOrDefault().ToString();
            TenKH = DataProvider.Ins.DB.KHACHHANG.Where(x => x.CMND == CMND).Select(x => x.TenKhachHang).FirstOrDefault();
            List<KHACHHANG> kH = DataProvider.Ins.DB.KHACHHANG.Where(x => x.CMND.Contains(InputedItem)).ToList();
            if (kH.Count > 0)
            {
                foreach (var CMND in kH)
                {
                    List<HOADON> hDon = DataProvider.Ins.DB.HOADON.Where(x => x.MaKhachHang == CMND.MaKhachHang).ToList();
                    foreach (var item in hDon)
                    {
                        var ctHoaDon = DataProvider.Ins.DB.CT_HOADON.Where(x => x.MaHoaDon == item.MaHoaDon).ToList();
                        result.AddRange(ctHoaDon);
                    }
                }

            }

            return result;
        }


    }
    }
