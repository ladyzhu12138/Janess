using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Janess.DAL;
using Janess.Model;

namespace Janess.BLL
{
    public class UserMgr : IUserMgr
    {
        #region 买家 Buyer
        public bool AddBuyer(TB_BUYER buyer)
        {
            int res = UserDao.AddBuyer(buyer);
            return res>0;
        }
        public TB_BUYER LoginBuyer(string account, string pwd)
        {
            TB_BUYER buyer = UserDao.LoginBuyer(account, pwd);
            return buyer;
        }
        public bool CheckBuyer(string account)
        {
            int res = UserDao.CheckBuyer(account);
            return res > 0;
        }
        #endregion

        #region 卖家 Seller
        public bool AddSeller(TB_SELLER seller)
        {
            int res = UserDao.AddSeller(seller);
            return res > 0;
        }
        public TB_SELLER LoginSeller(string account, string pwd)
        {
            TB_SELLER seller = UserDao.LoginSeller(account,pwd);
            return seller;
        }
        public bool CheckSeller(string account)
        {
            int res = UserDao.CheckSeller(account);
            return res > 0;
        }
        #endregion

        #region 骑手 Rider
        public bool AddRider(TB_RIDER rider)
        {
            int res = UserDao.AddRider(rider);
            return res > 0;
        }
        public TB_RIDER LoginRider(string account, string pwd)
        {
            TB_RIDER rider = UserDao.LoginRider(account,pwd);
            return rider;
        }
        public bool CheckRider(string account)
        {
            int res = UserDao.CheckRider(account);
            return res > 0;
        }

        #endregion

        #region 公有方法
        public bool CheckSellerName(string name)
        {
            int res = UserDao.CheckSellerName(name);
            return res > 0;
        }
        //public bool Check(string account)
        //{
        //    int res = UserDao.Check(account);
        //    return res > 0;
        //}
        #endregion
    }
}
