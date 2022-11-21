using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CamDo.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public bool IsLoaded { get; set; }

        public MainViewModel()
        {
            if (!IsLoaded)
            {
                IsLoaded = true;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
        }
    }
}
