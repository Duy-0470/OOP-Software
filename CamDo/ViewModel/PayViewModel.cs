using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommand MakeReceiptCommand { get; set; }
        public ICommand RefreshCommand { get; set; }


        public PayViewModel()
        {
            ContentList = new ObservableCollection<ObjectNumbericalOrder>();
            SelectedDate = DateTime.Now;

            ShowDataCommand = new RelayCommand<Button>((p) =>
            {
                if (String.IsNullOrEmpty(InputedItem))
                    return false;
                else return true;
            }
            , (p) =>
            {
                CTHoaDonList = new ObservableCollection<ObjectNumbericalOrder>();
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

                ContentList.Add(SelectedItem);
                ContentList[contentID - 1].Number = contentID;
                ContentList[contentID - 1].CT_HOADON.TongTien = (SelectedItem.CT_HOADON.GiaChuoc * SelectedItem.CT_HOADON.SoLuong);
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

                
            });

            RefreshCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SelectedDate = DateTime.Now;
                CTHoaDonList = new ObservableCollection<ObjectNumbericalOrder>();
                ContentList = new ObservableCollection<ObjectNumbericalOrder>();
                SelectedContent = null;
                SelectedItem = null;
            });
        }

        private List<CT_HOADON> SearchByBill()
        {
            List<CT_HOADON> result = DataProvider.Ins.DB.CT_HOADON.Where(x => x.MaHoaDon.ToString() == InputedItem).ToList();
            return result;
        }
    }
}
