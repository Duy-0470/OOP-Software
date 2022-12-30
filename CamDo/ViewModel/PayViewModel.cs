using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CamDo.ViewModel
{
    public class PayViewModel: BaseViewModel
    {
        private int contentID = 1;
        private int itemID = 0;
        private string selectedAmount;
        public string SelectedAmount
        {
            get { return selectedAmount; }
            set { selectedAmount = value; OnPropertyChanged(); }
        }

        public List<string> Option { get; set; }

        private ObjectNumbericalOrder selectedItem;
        public ObjectNumbericalOrder SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        private ObjectNumbericalOrder selectedContent;
        public ObjectNumbericalOrder SelectedContent
        {
            get { return selectedContent; }
            set
            {
                selectedContent = value;
                OnPropertyChanged();
            }
        }
        private DateTime? selectedDate;
        public DateTime? SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; OnPropertyChanged(); }
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
        private ObservableCollection<ObjectNumbericalOrder> contentList;
        public ObservableCollection<ObjectNumbericalOrder> ContentList
        {
            get { return contentList; }
            set { contentList = value; OnPropertyChanged(); }
        }


        public ICommand ShowDataCommand { get; set; }

        public ICommand AddContentCommand { get; set; }
        public ICommand DeleteContentCommand { get; set; }
        public ICommand RefreshContentCommand { get; set; }
        public ICommand MakeReceiptCommand { get; set; }
        public ICommand RefreshCommand { get; set; }


        public PayViewModel()
        {
            ContentList = new ObservableCollection<ObjectNumbericalOrder>();
            CTHoaDonList = new ObservableCollection<ObjectNumbericalOrder>();
            SelectedDate = DateTime.Now;
            
            ShowDataCommand = new RelayCommand<Button>((p) =>
            {
                if (String.IsNullOrEmpty(InputedItem))
                    return false;
                else return true;
            }
            , (p) =>
            {
                Refresh();

                var temp = DataProvider.Ins.DB.CT_HOADON.FirstOrDefault(x => x.MaHoaDon.ToString() == InputedItem);
                if (SelectedDate > temp.HanChot)
                {
                    MessageBox.Show("Đã quá hạn để chuộc");
                    return;
                }
                List<CT_HOADON> list = new List<CT_HOADON>();
                list = SearchByBill();
                
                if (list.Count == 0)
                {
                    MessageBox.Show("Không có đối tượng bạn cần tìm");
                    return;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ObjectNumbericalOrder objectNumbericalOrder = new ObjectNumbericalOrder();
                    objectNumbericalOrder.Number = i + 1;
                    itemID = i + 1;
                    objectNumbericalOrder.CT_HOADON = list[i];
                    CTHoaDonList.Add(objectNumbericalOrder);
                }
            });

            AddContentCommand = new RelayCommand<object>((p) =>
            {
                if (CTHoaDonList.Count() == 0)
                    return false;
                else return true;
            }, (p) =>
            {
                if ( CTHoaDonList.Count() == 0)
                {
                    MessageBox.Show("Không có vật tư bạn cần thanh toán");
                }

                if(SelectedItem.CT_HOADON.TrangThai == "Chuoc")
                {
                    MessageBox.Show("Đồ đã được chuộc");
                    return;
                }

                ContentList.Add(SelectedItem);
                ContentList[contentID - 1].Number = contentID;
                contentID = +1;
                CTHoaDonList.Remove(SelectedItem);
                SelectedItem = null;

                for ( int i = 0; i < CTHoaDonList.Count; i++)
                {
                    CTHoaDonList[i].Number = i +1;
                }

                for (int i = 0; i < ContentList.Count; i++)
                {
                    ContentList[i].Number = i + 1;
                }
            });

            DeleteContentCommand = new RelayCommand<object>((p) =>
            {
                if (ContentList.Count() == 0)
                    return false;
                else return true;
            }, (p) =>
            {
                if (ContentList.Count() == 0)
                {
                    MessageBox.Show("Không có vật tư bạn muốn xóa");
                }

                CTHoaDonList.Add(SelectedContent);
                CTHoaDonList[contentID - 1].Number = contentID;
                contentID = +1;
                ContentList.Remove(SelectedContent);
                SelectedContent = null;

                for (int i = 0; i < ContentList.Count; i++)
                {
                    ContentList[i].Number = i + 1;
                }

                for (int i = 0; i < CTHoaDonList.Count; i++)
                {
                    CTHoaDonList[i].Number = i + 1;
                }


            });

            RefreshContentCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SelectedDate = DateTime.Now;
                CTHoaDonList = new ObservableCollection<ObjectNumbericalOrder>();
                ContentList = new ObservableCollection<ObjectNumbericalOrder>();
                SelectedContent = null;
                SelectedItem = null;
                InputedItem = null;
            });

            RefreshCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SelectedDate = DateTime.Now;
                CTHoaDonList = new ObservableCollection<ObjectNumbericalOrder>();
                ContentList = new ObservableCollection<ObjectNumbericalOrder>();
                SelectedContent = null;
                SelectedItem = null;
                InputedItem = null;
            });

            MakeReceiptCommand = new RelayCommand<object>((p) =>
            {
                if (ContentList.Count() == 0)
                    return false;
                else return true;
            }, (p) =>
            {
                if (ContentList.Count() == 0)
                {
                    MessageBox.Show("Không có vật tư bạn muốn thanh toán");
                }

                List<CT_THUTIEN> detaillist = new List<CT_THUTIEN>();
                THUTIEN thutien = new THUTIEN() { MaHoaDon = Convert.ToInt32(InputedItem), NgayThuTien = DateTime.Now, SoTienThu = 0 };
                
                DataProvider.Ins.DB.THUTIEN.Add(thutien);
                DataProvider.Ins.DB.SaveChanges();
                foreach (var item in ContentList)
                {
                    CT_THUTIEN detailitem = new CT_THUTIEN();
                    detailitem.TenVatTu = item.CT_HOADON.TenVatTu;
                    detailitem.SoLuong = item.CT_HOADON.SoLuong;
                    detailitem.GiaChuoc = item.CT_HOADON.GiaChuoc;
                    detailitem.ThanhTien = item.CT_HOADON.TongTien;
                    detailitem.MaThuTien = thutien.MaThuTien;
                    detailitem.THUTIEN = thutien;
                    thutien.SoTienThu += detailitem.ThanhTien;
                    detaillist.Add(detailitem);
                }

                DataProvider.Ins.DB.CT_THUTIEN.AddRange(detaillist);
                DataProvider.Ins.DB.SaveChanges();

                foreach( var item in ContentList)
                {
                    var idtemp = DataProvider.Ins.DB.CT_HOADON.Where(x => x.MaHoaDon.ToString() == InputedItem).FirstOrDefault();
                    idtemp.TrangThai = "Chuoc";
                }

                DataProvider.Ins.DB.SaveChanges();

                Refresh();

                MessageBox.Show("Thu tiền thành công");

            });
        }

        private List<CT_HOADON> SearchByBill()
        {
            List<CT_HOADON> result = DataProvider.Ins.DB.CT_HOADON.Where(x => x.MaHoaDon.ToString() == InputedItem).ToList();
            return result;
        }

        private void Refresh()
        {
            CTHoaDonList = new ObservableCollection<ObjectNumbericalOrder>();
            ContentList = new ObservableCollection<ObjectNumbericalOrder>();
            SelectedContent = null;
        }
    }
}
