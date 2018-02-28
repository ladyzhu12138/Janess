using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Janess.DAL;
using Janess.Model;

namespace Janess.BLL
{
    public class UserMgrProxy : IUserMgr
    {
        UserMgr mgr = null;
        public UserMgrProxy()
        {
            mgr = new UserMgr();
        }
        #region 注册
        public bool AddBuyer(TB_BUYER buyer)
        {
            return mgr.AddBuyer(buyer);
        }

        public bool AddRider(TB_RIDER rider)
        {
            return mgr.AddRider(rider);
        }

        public bool AddSeller(TB_SELLER seller)
        {
            return mgr.AddSeller(seller);
        }
        #endregion
        #region 登录
        public TB_BUYER LoginBuyer(string account, string pwd)
        {
            return mgr.LoginBuyer(account, pwd);
        }

        public TB_RIDER LoginRider(string account, string pwd)
        {
            return mgr.LoginRider(account, pwd);
        }

        public TB_SELLER LoginSeller(string account, string pwd)
        {
            return mgr.LoginSeller(account, pwd);
        }
        #endregion

        public bool CheckSellerName(string name)
        {
            return mgr.CheckSellerName(name);
        }

        public bool CheckBuyer(string account)
        {
            return mgr.CheckBuyer(account);
        }
        public bool CheckSeller(string account)
        {
            return mgr.CheckSeller(account);
        }

        public bool CheckRider(string account)
        {
            return mgr.CheckRider(account);
        }
    }
}
