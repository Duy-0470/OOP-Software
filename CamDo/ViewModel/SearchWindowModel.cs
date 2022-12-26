using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public string tenKH; 

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
                if (Check() == true || String.IsNullOrEmpty(InputedItem))
                    return true;
                else return false;
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
                    CTHoaDonList.Add(objectNumbericalOrder);
                }
            }
            );
        }

        private bool Check()
        {
            if (SelectedItem == "Tiền nợ")
                return Decimal.TryParse(InputedItem, out _);
            return true;
        }
        private List<CT_HOADON> SearchByObjectName()
        {
            List<CT_HOADON> result = DataProvider.Ins.DB.CT_HOADON.Where(x => x.TenVatTu.Contains(InputedItem) ).ToList();
            return result;

        }
        private List<CT_HOADON> SeachByBill()
        {
            List<CT_HOADON> result = DataProvider.Ins.DB.CT_HOADON.Where(x => x.MaHoaDon.ToString() == InputedItem).ToList();
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
