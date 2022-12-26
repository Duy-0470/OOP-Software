using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CamDo.ViewModel
{
    public class PawnViewModel: BaseViewModel
    {

        private int number = 1;
        private string pawnName;
        public string PawnName
        {
            get { return pawnName; }
            set { pawnName = value; OnPropertyChanged(nameof(PawnName)); }
        }

        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; OnPropertyChanged(nameof(CustomerName)); }
        }

        private string iD;
        public string ID
        {
            get { return iD; }
            set { iD = value; OnPropertyChanged(nameof(ID)); }
        }

        private int billID;
        public int BillID
        {
            get { return billID; }
            set { billID = value; OnPropertyChanged(nameof(BillID)); }
        }

        private string priceInput;
        public string PriceInput
        {
            get { return priceInput; }
            set { priceInput = value; OnPropertyChanged(nameof(PriceInput)); }
        }

        private string priceOutputRecommended;
        public string PriceOutputRecommended
        {
            get { return priceOutputRecommended; }
            set { priceOutputRecommended = value; OnPropertyChanged(nameof(PriceOutputRecommended)); }
        }

        private string amount;
        public string Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged(nameof(Amount)); }
        }

        private decimal totalMoney;
        public decimal TotalMoney
        {
            get { return totalMoney; }
            set { totalMoney = value; OnPropertyChanged(); }
        }

        private DateTime? inputDate;
        public DateTime? InputDate
        {
            get { return inputDate; }
            set { inputDate = value; OnPropertyChanged(); }
        }

        private AddPawn selectedItem;
        public AddPawn SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    PawnName = SelectedItem.TenVatTu;
                    PriceInput = Convert.ToInt32(SelectedItem.TienCam).ToString();
                    PriceOutputRecommended = Convert.ToInt32(SelectedItem.TienChuoc).ToString();
                    Amount = SelectedItem.SoLuong.ToString();
                    CustomerName = SelectedItem.TenKhachHang;
                    iD = SelectedItem.CMND;
                    inputDate = SelectedItem.HanChot;
                }
            }
        }

        private ObservableCollection<AddPawn> inputList;
        public ObservableCollection<AddPawn> InputList
        {
            get { return inputList; }
            set { inputList = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddBillList { get; set; }
        public ICommand RefreshCommand { get; set; }
        public PawnViewModel()
        {
            Refresh();

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(PawnName) || string.IsNullOrEmpty(PriceInput) || string.IsNullOrEmpty(Amount))
                    return false;
                if (CheckValidNumber() == false)
                    return false;
                if (CheckInputName() == false)
                    return false;
                return true;

            }, (p) =>
            {
                AddPawn addPawn = new AddPawn();
                addPawn.Number = number;
                addPawn.TenVatTu = PawnName.Trim();
                addPawn.TienCam = Convert.ToDecimal(PriceInput);
                addPawn.TienChuoc = addPawn.TienCam * (decimal)(5 / 100);
                addPawn.SoLuong = Convert.ToInt32(Amount);
                addPawn.ThanhTien = addPawn.TienChuoc * addPawn.SoLuong;
                addPawn.CMND = ID;
                addPawn.TenKhachHang = CustomerName;
                addPawn.HanChot = (DateTime)inputDate;
                InputList.Add(addPawn);
                PawnName = PriceInput = PriceOutputRecommended = Amount = "";
                number++;
                UpdateTotalMoney();
            });

            //    EditCommand = new RelayCommand<object>((p) =>
            //    {
            //        if (SelectedItem == null)
            //            return false;
            //        if (CheckValidNumber() == false)
            //            return false;
            //        return true;
            //    }, (p) =>
            //    {
            //        foreach (var item in InputList)
            //        {
            //            if (item == SelectedItem)
            //            {
            //                item.TenVatTu = PawnName;
            //                item.TienCam = Convert.ToDecimal(PriceInput);
            //                item.TienChuoc = item.TienCam * (decimal)(1 + percentage);
            //                item.SoLuong = Convert.ToInt32(Amount);
            //                item.ThanhTien = item.TienCam * item.SoLuong;
            //                SelectedItem = item;
            //                break;
            //            }
            //        }
            //        PawnName = PriceInput = PriceOutputRecommended = Amount = "";
            //        UpdateTotalMoney();
            //    });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                int i = 1;
                foreach (var item in InputList)
                {
                    if (item == SelectedItem)
                    {
                        InputList.Remove(item);
                        break;
                    }
                }
                number--;
                foreach (var item in InputList)
                {
                    item.Number = i;
                    i++;
                }
                PawnName = PriceInput = PriceOutputRecommended = Amount = ID = CustomerName = "";
                UpdateTotalMoney();
            });

            #region
            //    DeSelectedItemCommand = new RelayCommand<object>((p) =>
            //    {
            //        if (SelectedItem == null)
            //            return false;
            //        return true;
            //    }, (p) =>
            //    {
            //        SelectedItem = null;
            //        PawnName = PriceInput = PriceOutputRecommended = Amount = "";
            //    });
            #endregion

            AddBillList = new RelayCommand<object>((p) =>
            {
                if (InputList.Count < 1)
                    return false;
                return true;
            }, (p) =>
            {
                List<CT_HOADON> detailList = new List<CT_HOADON>();
                HOADON hoadon = new HOADON() { Ngay = InputDate  /*, ThanhTien = TotalMoney*/ };
                DataProvider.Ins.DB.HOADON.Add(hoadon);
                DataProvider.Ins.DB.SaveChanges();

                int id = hoadon.MaHoaDon;
                foreach (var item in InputList)
                {
                        DataProvider.Ins.DB.SaveChanges();
                    CT_HOADON ct_hoadon = new CT_HOADON()
                    {
                        MaHoaDon = BillID,
                        GiaCam = (int?)item.TienCam,
                        LaiSuat = 5 / 100,
                        SoLuong = item.SoLuong,
                        //ThanhTien = item.ThanhTien
                        
                        };
                        detailList.Add(ct_hoadon);
                    
                    
                }
                DataProvider.Ins.DB.CT_HOADON.AddRange(detailList);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Thêm thành công");
                //CreateFirstReports();
            });

            RefreshCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                InputDate = DateTime.Now;
                InputList = new ObservableCollection<AddPawn>();
                TotalMoney = 0;
            });
        }

        private bool CheckInputName()
        {
            foreach (var item in InputList)
            {
                if (string.Compare(item.TenVatTu, PawnName) == 0)
                    return false;
            }
            return true;
        }

        private bool CheckValidNumber()
        {
            if (Decimal.TryParse(PriceInput, out _) == false || Int32.TryParse(Amount, out _) == false)
                return false;
            if (Convert.ToDecimal(PriceInput) <= 0 || Convert.ToInt32(Amount) <= 0)
                return false;

            return true;
        }
        private void UpdateTotalMoney()
        {
            foreach (var item in InputList)
            {
                TotalMoney += item.ThanhTien;
            }
        }
        private void Refresh()
        {
            InputDate = DateTime.Now;
            InputList = new ObservableCollection<AddPawn>();
        }

        //private void CreateFirstReports()
        //{
        //    #region lần đầu lập báo cáo tồn và báo cáo doanh số
        //    var thamso = DataProvider.Instance.DB.THAMSOes.First();
        //    if (thamso.ThangBaoCao == null)
        //    {
        //        thamso.ThangBaoCao = DateTime.Now.Month;
        //        List<BAOCAOTON> baocaotonList = new List<BAOCAOTON>();
        //        var VatTuList = DataProvider.Instance.DB.VATTUs.ToList();
        //        foreach (var vattu in VatTuList)
        //        {
        //            BAOCAOTON baocaoton = new BAOCAOTON()
        //            {
        //                MaVatTu = vattu.MaVatTu,
        //                ThoiGian = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
        //                TonDau = vattu.SoLuongTon,
        //                PhatSinh = 0,
        //                TonCuoi = vattu.SoLuongTon,
        //                VATTU = vattu
        //            };
        //            baocaotonList.Add(baocaoton);
        //        }

        //        DataProvider.Instance.DB.BAOCAOTONs.AddRange(baocaotonList);
        //        BAOCAODOANHSO baocaodoanhso = new BAOCAODOANHSO()
        //        {
        //            ThoiGian = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
        //            TongDoanhThu = 0
        //        };
        //        var hieuxeList = DataProvider.Instance.DB.HIEUXEs.ToArray();
        //        foreach (var hieuxe in hieuxeList)
        //        {
        //            CT_BCDS baocao = new CT_BCDS()
        //            {
        //                MaHieuXe = hieuxe.MaHieuXe,
        //                HIEUXE = hieuxe,
        //                BAOCAODOANHSO = baocaodoanhso,
        //                ThanhTien = 0,
        //                SoLuotSua = 0,
        //            };
        //            DataProvider.Instance.DB.CT_BCDS.Add(baocao);
        //        }
        //        DataProvider.Instance.DB.BAOCAODOANHSOes.Add(baocaodoanhso);

        //        DataProvider.Instance.DB.SaveChanges();

        //    }
        //    #endregion
        //}

    }
}
