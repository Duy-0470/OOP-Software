using CamDo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamDo.Model
{
    public class ObjectNumbericalOrder: BaseViewModel
    {
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; OnPropertyChanged(); }
        }
        public CT_HOADON CT_HOADON { get; set;}

        public string CustomerName { get; set; }
        public string CMND { get; set; }
        public string AmountTemp { get; set; }
    }
}
