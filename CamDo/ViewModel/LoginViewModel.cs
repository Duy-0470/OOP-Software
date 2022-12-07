using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
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

            //DataProvider.Ins.DB.TAIKHOANs.Where( x => x. == Username );

            IsLogin = true;
            p.Close();
        }
    }
}
