using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
        public int billIDtemp;

        private string customerID;
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value;
                OnPropertyChanged(nameof(CustomerID)); }
        }

        private decimal priceInput;
        public decimal PriceInput
        {
            get { return priceInput; }
            set { priceInput = value; OnPropertyChanged(nameof(PriceInput));
                PriceOutput = ( (decimal)1.05 * priceInput);
            }
        }

        private decimal priceOutput;
        public decimal PriceOutput
        {
            get { return priceOutput; }
            set { priceOutput = value; OnPropertyChanged(nameof(PriceOutput)); }
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
                    PriceInput = SelectedItem.TienCam;
                    Amount = SelectedItem.SoLuong.ToString();
                    CustomerName = SelectedItem.TenKhachHang;
                    iD = SelectedItem.CMND;
                    inputDate = SelectedItem.HanChot;
                    billID = SelectedItem.MaHoaDon;
                    customerID = SelectedItem.MaKhachHang;
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

            BillID = DataProvider.Ins.DB.HOADON.OrderByDescending(x => x.MaHoaDon).Select(x => x.MaHoaDon).FirstOrDefault() + 1;

            //CustomerName = DataProvider.Ins.DB.KHACHHANG.Where(x => x.MaKhachHang == CustomerID).Select(x => x.TenKhachHang).ToString();

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(PawnName) || string.IsNullOrEmpty(PriceInput.ToString()) || string.IsNullOrEmpty(Amount) || string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(CustomerID) || string.IsNullOrEmpty(InputDate.ToString()))
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
                addPawn.MaHoaDon = BillID;
                addPawn.MaKhachHang = CustomerID;
                addPawn.TienCam = PriceInput;
                addPawn.TienChuoc = PriceOutput;
                addPawn.SoLuong = Convert.ToInt32(Amount);
                addPawn.ThanhTien = addPawn.TienChuoc * addPawn.SoLuong;
                //addPawn.CMND = DataProvider.Ins.DB.KHACHHANG.Where(x => x.MaKhachHang == CustomerID).Select(x => x.CMND).ToString();
                addPawn.TenKhachHang = CustomerName;
                addPawn.HanChot = (DateTime)inputDate;
                InputList.Add(addPawn);
                PawnName = Amount = "";
                PriceInput = 0;
                number++;
                UpdateTotalMoney();
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (InputList.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {
                foreach (var item in InputList)
                {
                    if (item == SelectedItem)
                    {
                        item.TenVatTu = PawnName;
                        item.CMND = ID;
                        item.HanChot = (DateTime)inputDate;
                        item.MaKhachHang = CustomerID;
                        item.TenKhachHang = CustomerName;
                        item.TienCam = Convert.ToDecimal(PriceInput);
                        item.SoLuong = Convert.ToInt32(Amount);
                        SelectedItem = item;
                        break;
                    }
                }
                PawnName =  Amount = "";
                PriceInput = 0;
                UpdateTotalMoney();
            });

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
                PawnName  = Amount = ID = CustomerName = "";
                PriceInput = 0;
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
            //        PawnName = PriceInput = PriceOutput = Amount = "";
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
                HOADON hoadon = new HOADON() { Ngay = DateTime.Now, MaHoaDon = BillID, MaKhachHang = CustomerID };
                List<HOADON> tempoo = DataProvider.Ins.DB.HOADON.ToList();
                foreach (var item in tempoo)
                {
                    List<HOADON> temp = DataProvider.Ins.DB.HOADON.Where(x => x.MaHoaDon == item.MaHoaDon).ToList();
                    billIDtemp = item.MaHoaDon;
                }
                
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
                        SoLuong = item.SoLuong,
                        GiaChuoc = (int?)item.TienChuoc,
                        TenVatTu = item.TenVatTu,
                        HanChot = item.HanChot
                        
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
                InputList = new ObservableCollection<AddPawn>();
                TotalMoney = 0;
                InputDate = null;
                PawnName = Amount = CustomerID = " ";
                PriceInput = 0;

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
            if (Decimal.TryParse(PriceInput.ToString(), out _) == false || Int32.TryParse(Amount, out _) == false)
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
