using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CamDo.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        public bool IsLogin { get; set; }
        public string _Username;
        public string Username { get=> _Username; set { _Username = value; OnPropertyChanged(); } }
        public string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }


        public LoginViewModel()
        {
            IsLogin = false;
            Password = "";
            Username = "";
            LoginCommand = new RelayCommand<Window>((p) => { return EnableLoginButtonChecker(); }, (p) =>
            {
                Login(p);
            });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
            });
        }

        void Login(Window p)
        {
            if (p == null)
                return;

            TAIKHOAN user = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenTaiKhoan == Username && x.MatKhau == Password).FirstOrDefault();
            if (user != null)
            {
                MainViewModel.User = user;
                MainWindow mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                Application.Current.MainWindow.Show();
                p.Close();
            }
            else
            {
                MessageBox.Show("Sai Tai khoan hoac Mat khau");
            }

            #region
            //var accCount = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenTaiKhoan == Username && x.MatKhau == Password).Count();

            //if (accCount > 0)
            //{
            //    IsLogin = true;

            //    p.Close();
            //}
            //else
            //{
            //    IsLogin = false;
            //    MessageBox.Show("Sai Tai khoan hoac Mat khau");

            //}
            #endregion

        }

        bool EnableLoginButtonChecker()
        {
            if (string.IsNullOrEmpty(Username) == false && string.IsNullOrEmpty(Password) == false)
                return true;
            else
                return false;
        }
    }
}
