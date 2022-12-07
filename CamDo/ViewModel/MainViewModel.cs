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

namespace CamDo.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }

        public ICommand SelectViewCommand { get; set; }
        private BaseViewModel _selectedViewModel;  // Bien cuc bo
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
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;

                if (loginVM.IsLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
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
