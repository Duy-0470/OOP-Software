using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace CamDo.ViewModel
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        private string currentPassword;
        public string CurrentPassword
        {
            get { return currentPassword; }
            set { currentPassword = value; }
        }

        private string newPassword;
        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value; }
        }

        private string rePassword;
        public string RePassword
        {
            get { return rePassword; }
            set { rePassword = value; }
        }
        public ICommand CloseCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand SaveChangePasswordCommand { get; set; }
        public ChangePasswordViewModel()
        {
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                switch (p.Name)
                {
                    case "txbPasswordCurent":
                        {
                            CurrentPassword = p.Password;
                            break;
                        }
                    case "txbNewPassword":
                        {
                            NewPassword = p.Password;
                            break;
                        }
                    case "txbNewRepassword":
                        {
                            RePassword = p.Password;
                            break;
                        }
                }
            });

            SaveChangePasswordCommand = new RelayCommand<Window>(p =>
            {
                if (string.IsNullOrEmpty(CurrentPassword) || string.IsNullOrEmpty(NewPassword) || string.IsNullOrEmpty(RePassword))
                    return false;
                return true;
            }, (p) =>
            {
                if (NewPassword != RePassword)
                {
                    MessageBox.Show("Mật khẩu mới không khớp với mật khẩu nhập lại!");
                    return;
                }
                if (string.Compare(CurrentPassword, MainViewModel.User.MatKhau) != 0)
                {
                    MessageBox.Show("Mật khẩu đang dùng không trùng khớp!");
                    return;
                }

                MainViewModel.User.MatKhau = NewPassword;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Cập nhật mật khẩu thành công.");
                p.Close();
            });
        }
    }
}
