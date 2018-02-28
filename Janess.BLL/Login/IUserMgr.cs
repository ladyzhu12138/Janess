using Janess.DAL;
using Janess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.BLL
{
    public interface IUserMgr
    {
        #region Buyer 买家
        /// <summary>
        /// 买家注册
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        bool AddBuyer(TB_BUYER buyer);

        /// <summary>
        /// 登录验证，是否存在该用户
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        TB_BUYER LoginBuyer(string account,string pwd);

        /// <summary>
        /// 注册验证，账号是否重复
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        bool CheckBuyer(string account);
        #endregion

        #region Seller 卖家
        /// <summary>
        /// 卖家注册
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        bool AddSeller(TB_SELLER seller);

        /// <summary>
        /// 登录验证，是否存在该用户
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        TB_SELLER LoginSeller(string account, string pwd);

        /// <summary>
        /// 注册验证，账号是否重复
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        bool CheckSeller(string account);
        #endregion

        #region Rider 骑手
        /// <summary>
        /// 骑手注册
        /// </summary>
        /// <param name="rider"></param>
        /// <returns></returns>
        bool AddRider(TB_RIDER rider);

        /// <summary>
        /// 登录验证，是否有该用户
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        TB_RIDER LoginRider(string account, string pwd);
        /// <summary>
        /// 检查该用户名是否存在
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        bool CheckRider(string account);
        #endregion

        #region 公有方法
        /// <summary>
        /// 检查该用户名是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool CheckSellerName(string name);
        #endregion
    }
}
