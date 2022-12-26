using CamDo.ViewModel;
using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CamDo.Model
{
    public class CreateAccountViewModel: BaseViewModel
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(); }
        }

        private string password = "12345";
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        public ICommand CloseCommand { get; set; }
        public ICommand CreateAccountCommand { get; set; }
        public ICommand ShowAccountListCommand { get; set; }
        public CreateAccountViewModel()
        {
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            CreateAccountCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                    return false;
                if (DataProvider.Ins.DB.TAIKHOAN.Any(x => x.TenTaiKhoan == UserName) == true)
                    return false;
                return true;
            }, (p) =>
            {
                //string passEncode = Encryptor.CreateMD5(Encryptor.Base64Encode(Password.Trim()));
                VAITRO vaitro = DataProvider.Ins.DB.VAITRO.FirstOrDefault(x => x.MaVaiTro == 0);
                TAIKHOAN taikhoan = new TAIKHOAN() { TenTaiKhoan = UserName.Trim(), MatKhau = Password.Trim(), MaVaiTro = vaitro.MaVaiTro, VAITRO = vaitro };
                DataProvider.Ins.DB.TAIKHOAN.Add(taikhoan);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Tạo tài khoản thành công!");
            });

            //ShowAccountListCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ShowAccountListWindow showAccountListWindow = new ShowAccountListWindow(); showAccountListWindow.Show(); });

        }

    }
}
