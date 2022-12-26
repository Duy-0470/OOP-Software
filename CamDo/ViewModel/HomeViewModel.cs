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

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SelectViewCommand { get; set; }
        public ICommand OpenAccountInfoCommand { get; set; }
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
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (User.MaVaiTro == 0)
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

            OpenAccountInfoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //AccountInformation accountInformation = new AccountInformation();
                //accountInformation.ShowDialog();
            });

            //LogoutCommand = new RelayCommand<Window>
            //(
            //    (p) => { return true; },
            //    (p) =>
            //    {
            //        MainViewModel.User = null;
            //        LoginWindow loginWindow = new LoginWindow();
            //        Application.Current.MainWindow = loginWindow;
            //        Application.Current.MainWindow.Show();
            //        p.Close();
            //    }
            //);

            CreateAccountCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CreateAccountWindow createAccountWindow = new CreateAccountWindow();
                createAccountWindow.ShowDialog();
            });

        }

       

    }
}
