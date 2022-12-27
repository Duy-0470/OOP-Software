using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CamDo.ViewModel
{
    public class CustomerViewModel: BaseViewModel
    {
        private List<KHACHHANG> _ListKhachHang;
        public List<KHACHHANG> ListKhachHang { get { return _ListKhachHang; } set { _ListKhachHang = value; OnPropertyChanged(); } }

        private string _HoTen;
        public string HoTen { get => _HoTen; set { _HoTen = value; OnPropertyChanged(); } }

        private string _SoDienThoai;
        public string SoDienThoai { get => _SoDienThoai; set { _SoDienThoai = value; OnPropertyChanged(); } }

        private string _MaKhachHang;
        public string MaKhachHang { get => _MaKhachHang; set { _MaKhachHang = value; OnPropertyChanged(); } }

        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }

        private bool _EditTextboxEnable = true;
        public bool EditTextboxEnable { get => _EditTextboxEnable; set { _EditTextboxEnable = value; OnPropertyChanged(); } }

        private ReceiveNumbericalOrder _SelectedItem;
        public ReceiveNumbericalOrder SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    EditTextboxEnable = false;
                    SoDienThoai = SelectedItem.KH.SDT;
                    HoTen = SelectedItem.KH.TenKhachHang;
                    CMND = SelectedItem.KH.CMND;
                    MaKhachHang = SelectedItem.KH.MaKhachHang;
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DeSelectedItemCommand { get; set; }

        private ObservableCollection<ReceiveNumbericalOrder> _ListTiepNhanKhachHang;
        public ObservableCollection<ReceiveNumbericalOrder> ListTiepNhanKhachHang { get => _ListTiepNhanKhachHang; set { _ListTiepNhanKhachHang = value; OnPropertyChanged(); } }
        public CustomerViewModel()
        {
            LoadInputList();

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(HoTen))
                    return false;
                if (string.IsNullOrEmpty(SoDienThoai))
                    return false;
                if(string.IsNullOrEmpty(CMND))
                    return false;
                if (string.IsNullOrEmpty(MaKhachHang))
                    return false;
                return true;
            }, (p) =>
            {
                if (DataProvider.Ins.DB.KHACHHANG.Any(x => x.MaKhachHang == MaKhachHang) == true)
                {
                    MessageBox.Show("Đã có mã khách hàng trùng với mã bạn đã nhập!");
                    return;
                }
                var kh = new KHACHHANG() { SDT = SoDienThoai.Trim(),  TenKhachHang = HoTen.Trim(), MaKhachHang = MaKhachHang.Trim(), CMND = CMND.Trim()  };

                ReceiveNumbericalOrder receiveNumbericalOrder = new ReceiveNumbericalOrder();
                receiveNumbericalOrder.KH = kh;
                receiveNumbericalOrder.Number = ListKhachHang.Count + 1;
                ListTiepNhanKhachHang.Add(receiveNumbericalOrder);
                DataProvider.Ins.DB.KHACHHANG.Add(kh);
                DataProvider.Ins.DB.SaveChanges();

                HoTen =  SoDienThoai = CMND = MaKhachHang =  "";
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                var khtemp = DataProvider.Ins.DB.KHACHHANG.Where(x => x.MaKhachHang == SelectedItem.KH.MaKhachHang).FirstOrDefault();
                khtemp.MaKhachHang = MaKhachHang;
                khtemp.TenKhachHang = HoTen;
                khtemp.CMND = CMND;
                khtemp.SDT = SoDienThoai;
                DataProvider.Ins.DB.SaveChanges();
                for (int i = 0; i < ListTiepNhanKhachHang.Count; i++)
                {
                    if (SelectedItem.KH.MaKhachHang == ListTiepNhanKhachHang[i].KH.MaKhachHang)
                    {
                        ListTiepNhanKhachHang[i].KH = khtemp;
                        break;
                    }
                }
                EditTextboxEnable = true;
                HoTen = CMND = MaKhachHang = SoDienThoai = "";
                SelectedItem = null;
            });

            DeSelectedItemCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                HoTen = "";
                SoDienThoai = "";
                CMND = "";
                MaKhachHang = "";
                SelectedItem = null;
                EditTextboxEnable = true;
            });
        }

        private void LoadInputList()
        {
            ListKhachHang = DataProvider.Ins.DB.KHACHHANG.ToList();
            ListTiepNhanKhachHang = new ObservableCollection<ReceiveNumbericalOrder>();
            var Khs = DataProvider.Ins.DB.KHACHHANG.ToList();
            for (int i = 0; i < Khs.Count; i++)
            {
                ReceiveNumbericalOrder receiveNumbericalOrder = new ReceiveNumbericalOrder();
                receiveNumbericalOrder.KH = Khs[i];
                receiveNumbericalOrder.Number = i + 1;
                ListTiepNhanKhachHang.Add(receiveNumbericalOrder);
            }
        }
    }
}
