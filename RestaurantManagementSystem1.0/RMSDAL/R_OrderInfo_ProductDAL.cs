using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using RMS.Model;

namespace RMS.DAL
{
    public class R_OrderInfo_ProductDAL
    {
        /// <summary>
        /// 根据中间表ID更新中间表状态
        /// </summary>
        /// <param name="rOrderProId">中间表ID</param>
        /// <returns></returns>
        public int SoftDeleteROrderInfoProductByROrderProId(int rOrderProId)
        {
            string sql = "update R_OrderInfo_Product set DelFlag=1 where ROrderProId =" + rOrderProId;
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 添加一条数据到点菜中间表
        /// </summary>
        /// <param name="rop">点菜中间表对象</param>
        /// <returns></returns>
        public int AddROrderInfoProduct(R_OrderInfo_Product rop)
        {
            string sql = "insert into R_OrderInfo_Product(OrderId,ProId,DelFlag,SubTime,State,UnitCount) values(@OrderId,@ProId,@DelFlag,@SubTime,@State,@UnitCount)";
            SQLiteParameter[] ps = {
                new SQLiteParameter("@OrderId",rop.OrderId),
                new SQLiteParameter("@ProId",rop.ProId),//冗余属性
                new SQLiteParameter("@DelFlag",rop.DelFlag),
                new SQLiteParameter("@SubTime",rop.SubTime),
                new SQLiteParameter("@State",rop.State),
                new SQLiteParameter("@UnitCount",rop.UnitCount)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        /// <summary>
        /// 根据订单ID查询该订单的总金额和数量
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public R_OrderInfo_Product GetMoneyAndCount(int orderId)
        {
            string sql = "select count(*),sum(ProPrice*UnitCount) from R_OrderInfo_Product a, ProductInfo b where a.ProId = b.ProId and a.DelFlag = 0 and OrderId=" + orderId;
            R_OrderInfo_Product rop = null;
            using (SQLiteDataReader reader = SqliteHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rop = new R_OrderInfo_Product();
                        rop.CT = Convert.ToInt32(reader[0]);//点单数量
                        if (DBNull.Value == reader[1])//未点单时
                        {
                            rop.MONEY = 0;
                        }
                        else
                        {
                            rop.MONEY = Convert.ToDecimal(reader[1]);//合计金额
                        }
                    }
                }
            }
            return rop;
        }

        /// <summary>
        /// 根据订单ID获取点菜信息
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public List<R_OrderInfo_Product> GetROrderInfoProduct(int orderId)
        {
            string sql = "select ROrderProId,ProName,ProPrice,UnitCount,ProUnit,CatName,C.SubTime from CategoryInfo A, ProductInfo B, R_OrderInfo_Product C where A.CatId = B.CatId and B.ProId = C.ProId and C.DelFlag = 0 and C.OrderId = @OrderId";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@OrderId", orderId));
            List<R_OrderInfo_Product> list = new List<R_OrderInfo_Product>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToROrderInfProduct(dr));
                }
            }
            return list;
        }

        //关系转对象
        private R_OrderInfo_Product RowToROrderInfProduct(DataRow dr)
        {
            R_OrderInfo_Product rop = new R_OrderInfo_Product();
            rop.ProName = dr["ProName"].ToString();//产品名称
            rop.ProPrice = Convert.ToDecimal(dr["ProPrice"]);//单价
            rop.CatName = dr["CatName"].ToString();//项目类别
            rop.ProUnit = dr["ProUnit"].ToString();//单位
            rop.ROrderProId = Convert.ToInt32(dr["ROrderProId"]);//中间表主键ID
            rop.SubTime = Convert.ToDateTime(dr["SubTime"]);//提交事件
            rop.UnitCount = Convert.ToDecimal(dr["UnitCount"]);//数量
            rop.ProMoney = rop.UnitCount * rop.ProPrice;//金额
            return rop;
        }
    }
}
