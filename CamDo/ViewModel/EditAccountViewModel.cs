using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CamDo.ViewModel
{
    public class EditAccountViewModel: BaseViewModel
    {
        private bool enableState;

        public bool EnableState
        {
            get { return enableState; }
            set
            {
                enableState = value;
                OnPropertyChanged(nameof(EnableState));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public ICommand CloseCommand { get; set; }
        public ICommand AllowToChangeCommand { get; set; }
        public ICommand OpenChangePasswordWindowCommand { get; set; }
        public ICommand SaveChangeAccount { get; set; }

        public EditAccountViewModel()
        {
            LoadInformation();
            EnableState = false;
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); }); 
            AllowToChangeCommand = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                if (EnableState == false)
                {
                    EnableState = true;
                    p.Content = "Hủy chỉnh sửa";
                }
                else
                {
                    EnableState = false;
                    p.Content = "Chỉnh sửa";
                }
            });

            OpenChangePasswordWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
                changePasswordWindow.ShowDialog();
            });

            SaveChangeAccount = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(Name))
                    return false;
                return true;
            }, (p) =>
            {
                TAIKHOAN taikhoan = DataProvider.Ins.DB.TAIKHOAN.SingleOrDefault(x => x.MaTaiKhoan == MainViewModel.User.MaTaiKhoan);
                taikhoan.TenNhanVien = Name.Trim();

                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Chỉnh sửa thành công");
                p.Close();
            });
        }

        private void LoadInformation()
        {
            Name = MainViewModel.User.TenNhanVien.Trim();
        }
    }

}
