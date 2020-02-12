using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Model;
using System.Data;
using System.Data.SQLite;

namespace RMS.DAL
{
    public class R_Order_DeskDAL
    {
        /// <summary>
        /// 添加一条中间表数据
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        public int AddROrderDesk(R_Order_Desk rod)
        {
            string sql = "insert into R_Order_Desk(OrderId,DeskId) values(@OrderId,@DeskId)";
            SQLiteParameter[] ps = {
                new SQLiteParameter("@OrderId",rod.OrderId),
                new SQLiteParameter("@DeskId",rod.DeskId)
            };
            return SqliteHelper.ExecuteNonQuery(sql,ps);
        }

    }
}
