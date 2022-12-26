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
    public class MainViewModel : BaseViewModel
    {
        public static TAIKHOAN User;

        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
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
        public ICommand SelectViewCommand { get; set; }
        private BaseViewModel _selectedViewModel = new SwitchViewHome();  // Bien cuc bo // De SwitchViewHome de mo len no qua UC Home
        public BaseViewModel SelectedViewModel   // Bien de chua nhung SwitchView Class
        {
            get
            {
                return _selectedViewModel;
            }

            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }

        }
       

        public MainViewModel()
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

            SelectViewCommand = new RelayCommand<ListViewItem>((p) => { return true; }, (p) => { SelectView(p); });

        }

        private void SelectView(ListViewItem p)
        {
            if (p != null && p.Tag != null)
            {
                string tag = p.Tag.ToString();

                switch (tag)
                {
                    case "Home":
                        {
                            SelectedViewModel = new SwitchViewHome();
                            break;
                        }
                    case "Customer":
                        {
                            SelectedViewModel = new SwitchViewCustomer();
                            break;
                        }
                    case "Search":
                        {
                            SelectedViewModel = new SwitchViewSearch();
                            break;
                        }
                    case "Expense":
                        {
                            SelectedViewModel = new SwitchViewExpense();
                            break;
                        }
                    case "Management":
                        {
                            SelectedViewModel = new SwitchViewManagement();
                            break;
                        }
                    case "Pawn":
                        {
                            SelectedViewModel = new SwitchViewPawn();
                            break;
                        }
                    case "Remind":
                        {
                            SelectedViewModel = new SwitchViewRemind();
                            break;
                        }
                    default:
                        break;
                }

            }

        }
    }
}
