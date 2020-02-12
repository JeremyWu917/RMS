using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class OrderInfoBLL
    {
        OrderInfoDAL dal = new OrderInfoDAL();

        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool UpdateOrderInfoMoney(OrderInfo order)
        {
            return dal.UpdateOrderInfoMoney(order) > 0;
        }

        /// <summary>
        /// 根据订单查询该订单的消费金额
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public decimal GetMoneyByOrderId(int orderId)
        {
            return Convert.ToDecimal(dal.GetMoneyByOrderId(orderId));
        }

        /// <summary>
        /// 根据订单ID更新订单金额
        /// </summary>
        /// <param name="orderId"></param>
        public void UpdateMoneyByOrderId(int orderId, decimal money)
        {
            int i = dal.UpdateMoneyByOrderId(orderId, money);
        }

        /// <summary>
        /// 根据餐桌ID获取当前未关闭的订单ID
        /// </summary>
        /// <param name="deskId">餐桌ID</param>
        /// <returns></returns>
        public int GetOrderIdByDeskId(int deskId)
        {
            return Convert.ToInt32(dal.GetOrderIdByDeskId(deskId));
        }

        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="order">OrderInfo对象</param>
        /// <returns>主键ID</returns>
        public int AddOrderInfo(OrderInfo order)
        {
            return dal.AddOrderInfo(order);
        }


    }
}
