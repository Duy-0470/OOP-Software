using CamDo.ViewModel;
using CamDo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CamDo.Model
{
    public class ShowAccountListViewModel: BaseViewModel
    {
        private ObservableCollection<AccountNumbericalOrder> accountList;
        public ObservableCollection<AccountNumbericalOrder> AccountList
        {
            get { return accountList; }
            set { accountList = value; }
        }
        public ShowAccountListViewModel()
        {
            AccountList = new ObservableCollection<AccountNumbericalOrder>();
            List<TAIKHOAN> TaiKhoan = DataProvider.Ins.DB.TAIKHOAN.Where(x => x.MaVaiTro == 0).ToList();
            for (int i = 0; i < TaiKhoan.Count; i++)
            {
                AccountNumbericalOrder accountNumbericalOrder = new AccountNumbericalOrder();
                accountNumbericalOrder.Number = i + 1;
                accountNumbericalOrder.TaiKhoan = TaiKhoan[i];
                AccountList.Add(accountNumbericalOrder);
            }
        }
    }
}
