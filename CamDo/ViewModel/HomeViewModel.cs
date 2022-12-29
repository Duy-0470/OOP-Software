using CamDo.Model;
using CamDo.UC.SwitchViewClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Configuration;

namespace CamDo.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public static TAIKHOAN User;
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        private string role;
        public string Role
        {
            get { return role; }
            set { role = value; OnPropertyChanged(); }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(); }
        }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SelectViewCommand { get; set; }
        public ICommand EditAccountInfoCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand CreateAccountCommand { get; set; }
        private Visibility updateVisibility;
        public Visibility UpdateVisibility
        {
            get { return updateVisibility; }
            set
            {
                updateVisibility = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            LoadInformation();

            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (MainViewModel.User.MaVaiTro == 0)
                {
                    UpdateVisibility = Visibility.Hidden;
                }
                else
                {
                    UpdateVisibility = Visibility.Visible;
                }

                #region  
                //Isloaded = true;
                //if (p == null)
                //    return;
                //p.Hide();
                //LoginWindow loginWindow = new LoginWindow();
                //loginWindow.ShowDialog();

                //if (loginWindow.DataContext == null)
                //    return;
                //var loginVM = loginWindow.DataContext as LoginViewModel;

                //if (loginVM.IsLogin)
                //{
                //    p.Show();
                //}
                //else
                //{
                //    p.Close();
                //}

                //MessageBox.Show(User.MaVaiTro.ToString());
                #endregion
            });

            EditAccountInfoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                EditAccountWindow editAccountWindow = new EditAccountWindow();
                editAccountWindow.ShowDialog();
            });

            LogoutCommand = new RelayCommand<Window>
            (
                (p) => { return true; },
                (p) =>
                {
                    MainViewModel.User = null;
                    LoginWindow loginWindow = new LoginWindow();
                    Application.Current.MainWindow = loginWindow;
                    Application.Current.MainWindow.Show();
                    p.Close();
                }
            );

            CreateAccountCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CreateAccountWindow createAccountWindow = new CreateAccountWindow();
                createAccountWindow.ShowDialog();
            });

            

        }

        private void LoadInformation()
        {
            Name = MainViewModel.User.TenNhanVien.Trim();
            UserName = MainViewModel.User.TenTaiKhoan.Trim();
            if (MainViewModel.User.MaVaiTro == 1)
            {
                Role = "Admin";
            }
            else Role = "Staff";
        }

    }
}
