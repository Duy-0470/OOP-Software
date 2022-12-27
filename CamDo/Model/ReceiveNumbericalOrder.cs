using CamDo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamDo.Model
{
    public class ReceiveNumbericalOrder:BaseViewModel
    {
        private int _Number;
        public int Number { get => _Number; set { _Number = value; OnPropertyChanged(); } }

        private KHACHHANG kH;
        public KHACHHANG KH { get => kH; set { kH = value; OnPropertyChanged(); } }
    }
}
