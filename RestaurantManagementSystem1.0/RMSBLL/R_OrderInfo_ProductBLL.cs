using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class R_OrderInfo_ProductBLL
    {
        R_OrderInfo_ProductDAL dal = new R_OrderInfo_ProductDAL();

        /// <summary>
        /// 根据中间表ID更新中间表状态
        /// </summary>
        /// <param name="rOrderProId">中间表ID</param>
        /// <returns></returns>
        public bool SoftDeleteROrderInfoProductByROrderProId(int rOrderProId)
        {
            return dal.SoftDeleteROrderInfoProductByROrderProId(rOrderProId) > 0;
        }

        /// <summary>
        /// 添加一条数据到点菜中间表
        /// </summary>
        /// <param name="rop">点菜中间表对象</param>
        /// <returns></returns>
        public bool AddROrderInfoProduct(R_OrderInfo_Product rop)
        {
            return dal.AddROrderInfoProduct(rop) > 0;
        }

        /// <summary>
        /// 根据订单ID查询该订单的总金额和数量
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public R_OrderInfo_Product GetMoneyAndCount(int orderId)
        {
            return dal.GetMoneyAndCount(orderId);
        }

        /// <summary>
        /// 根据订单ID获取点菜信息
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public List<R_OrderInfo_Product> GetROrderInfoProduct(int orderId)
        {
            return dal.GetROrderInfoProduct(orderId);
        }
    }
}
