using Janess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janess.DAL
{
    public class UserDao
    {
        #region Buyer
        /// <summary>
        /// 买家注册
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public static int AddBuyer(TB_BUYER buyer)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var entity = new TB_BUYER();
                entity.ACCOUNT = buyer.ACCOUNT;
                entity.BUYER_NAME = buyer.BUYER_NAME;
                entity.PWD = buyer.PWD;               
                context.TB_BUYER.Add(entity);
                int res = context.SaveChanges();
                return res;
            }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static TB_BUYER LoginBuyer(string account, string pwd)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var obj = context.TB_BUYER.FirstOrDefault(t => t.ACCOUNT == account && t.PWD == pwd);
                //TB_BUYER entity = context.TB_BUYER.SqlQuery("SELECT * FROM TB_BUYER WHERE ACCOUNT='account' AND PWD='pwd'", account, pwd).FirstOrDefault();
                //return entity;
                return obj;
            }
        }
        /// <summary>
        /// 检查用户账号是否已经注册
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static int CheckBuyer(string account)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                //var p_account = new SqlParameter("@ACCOUNT", account);
                //var res = context.Database.SqlQuery(@"SELECT COUNT(*) FROM TB_BUYER WHERE ACCOUNT=@ACCOUNT",new SqlParameter[] {
                //    p_account
                //});
                //return res;
                //List<int> res = context.Database.SqlQuery<int>(@"SELECT count(*) FROM TB_BUYER  WHERE ACCOUNT = @ACCOUNT", sqlps).ToList()

                var res = context.TB_BUYER.Count(t => t.ACCOUNT == account);
                var sqls = new SqlParameter[] {
                    new SqlParameter("@ACCOUNT",account)
                };
                return res;
            }
        }
        #endregion

        #region Seller
        /// <summary>
        /// 卖家注册
        /// </summary>
        /// <param name="seller"></param>
        /// <returns></returns>
        public static int AddSeller(TB_SELLER seller)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var entity = new TB_SELLER();
                entity.ACCOUNT = seller.ACCOUNT;
                entity.SELLER_NAME = seller.SELLER_NAME;
                entity.PWD = seller.PWD;
                context.TB_SELLER.Add(entity);
                int res = context.SaveChanges();
                return res;
            }
        }
        /// <summary>
        /// 卖家登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static TB_SELLER LoginSeller(string account,string pwd)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var obj = context.TB_SELLER.FirstOrDefault(t => t.ACCOUNT == account && t.PWD == pwd);
                return obj;
            }
        }
        /// <summary>
        /// 检查用户账号是否已经注册
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static int CheckSeller(string account)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var res = context.TB_SELLER.Count(t => t.ACCOUNT == account);
                var sqls = new SqlParameter[] {
                    new SqlParameter("@ACCOUNT",account)
                };
                return res;
            }
        }

        #endregion
        #region Buyer
        /// <summary>
        /// 骑手注册
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public static int AddRider(TB_RIDER rider)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var entity = new TB_RIDER();
                entity.ACCOUNT = rider.ACCOUNT;
                entity.RIDER_NAME = rider.RIDER_NAME;
                entity.PWD = rider.PWD;
                context.TB_RIDER.Add(entity);
                int res = context.SaveChanges();
                return res;
            }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static TB_RIDER LoginRider(string account, string pwd)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var obj = context.TB_RIDER.FirstOrDefault(t => t.ACCOUNT == account && t.PWD == pwd);
                //TB_BUYER entity = context.TB_BUYER.SqlQuery("SELECT * FROM TB_BUYER WHERE ACCOUNT='account' AND PWD='pwd'", account, pwd).FirstOrDefault();
                //return entity;
                return obj;
            }
        }
        /// <summary>
        /// 检查用户账号是否已经注册
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static int CheckRider(string account)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                //var p_account = new SqlParameter("@ACCOUNT", account);
                //var res = context.Database.SqlQuery(@"SELECT COUNT(*) FROM TB_BUYER WHERE ACCOUNT=@ACCOUNT",new SqlParameter[] {
                //    p_account
                //});
                //return res;
                //List<int> res = context.Database.SqlQuery<int>(@"SELECT count(*) FROM TB_BUYER  WHERE ACCOUNT = @ACCOUNT", sqlps).ToList()

                var res = context.TB_RIDER.Count(t => t.ACCOUNT == account);
                var sqls = new SqlParameter[] {
                    new SqlParameter("@ACCOUNT",account)
                };
                return res;
            }
        }
        /// <summary>
        /// 检查卖家账号是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int CheckSellerName(string name)
        {
            using (JANESS_SYSTEM_DBEntities context = new JANESS_SYSTEM_DBEntities())
            {
                var res = context.TB_SELLER.Count(t => t.SELLER_NAME == name);
                var sqls = new SqlParameter[] {
                    new SqlParameter("@SELLER_NAME",name)
                };
                return res;
            }
        }
        #endregion
    }
}
