using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CamDo.ViewModel
{
    public class LoginViewModel
    {
        public ICommand ClosingWindowCommand { get; set; }

        public LoginViewModel()
        {
            ClosingWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                Application.Current.Shutdown();
                App.Current.Shutdown();
            });
        }
    }
}
