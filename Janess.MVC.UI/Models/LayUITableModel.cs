using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Janess.MVC.UI.Models
{
    /// <summary>
    /// layui table对应的实体类
    /// </summary>
    public class LayUITableModel
    {
        public LayUITableModel()
        {
            //默认 200 成功状态
            code = 200;
        }
        public LayUITableModel(int count, object data)
        {
            this.count = count;
            this.data = data;
        }

        /// <summary>
        /// 数据总数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 数据项
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 状态信息
        /// </summary>
        public string msg { get; set; }
    }
}