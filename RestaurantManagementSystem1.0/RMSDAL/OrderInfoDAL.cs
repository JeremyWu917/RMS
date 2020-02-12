using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using RMS.Model;

namespace RMS.DAL
{
    public class OrderInfoDAL
    {

        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int UpdateOrderInfoMoney(OrderInfo order)
        {
            string sql = "update OrderInfo set OrderState=2, OrderMemId=@OrderMemId,EndTime=@EndTime,OrderMoney=@OrderMoney,DisCount=@DisCount where OrderId=@OrderId";

            SQLiteParameter[] ps = {
                new SQLiteParameter("@OrderMemId",order.OrderMemId),
                new SQLiteParameter("@EndTime",order.EndTime),
                new SQLiteParameter("@OrderMoney",order.OrderMoney),
                new SQLiteParameter("@DisCount",order.DisCount),
                new SQLiteParameter("@OrderId",order.OrderId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        /// <summary>
        /// 根据订单查询该订单的消费金额
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public object GetMoneyByOrderId(int orderId)
        {
            string sql = "select OrderMoney from OrderInfo where DelFlag=0 and OrderState=1 and OrderId=" + orderId;
            return SqliteHelper.ExecuteScalar(sql);
        }

        /// <summary>
        /// 根据订单ID更新订单金额
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int UpdateMoneyByOrderId(int orderId, decimal money)
        {
            string sql = "update OrderInfo set OrderMoney=" + money + " where DelFlag=0 and OrderId=" + orderId;
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据餐桌ID获取当前未关闭的订单ID
        /// </summary>
        /// <param name="deskId">餐桌ID</param>
        /// <returns></returns>
        public Object GetOrderIdByDeskId(int deskId)
        {
            string sql = "select t.OrderId from OrderInfo t, R_Order_Desk tt where t.OrderId = tt.OrderId and t.OrderState=1 and tt.DeskId=@DeskId";
            return SqliteHelper.ExecuteScalar(sql, new SQLiteParameter("@DeskId", deskId));
        }

        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="order">OrderInfo对象</param>
        /// <returns>主键ID</returns>
        public int AddOrderInfo(OrderInfo order)
        {
            string sql = "insert into OrderInfo(SubTime,Remark,OrderState,DelFlag,SubBy,OrderMoney) values(@SubTime,@Remark,@OrderState,@DelFlag,@SubBy,@OrderMoney);select last_insert_rowid();";
            SQLiteParameter[] ps = {
                     new SQLiteParameter("@SubTime",order.SubTime),
                        new SQLiteParameter("@Remark",order.Remark),
                           new SQLiteParameter("@OrderState",order.OrderState),
                              new SQLiteParameter("@DelFlag",order.DelFlag),
                                 new SQLiteParameter("@SubBy",order.SubBy),
                                   new SQLiteParameter("@OrderMoney",order.OrderMoney)
                                   };

            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sql, ps));
        }



    }
}
