using CamDo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamDo.Model
{
    public class AccountNumbericalOrder: BaseViewModel
    {
        public int Number { get; set; }
        public TAIKHOAN TaiKhoan { get; set; }
    }
}
