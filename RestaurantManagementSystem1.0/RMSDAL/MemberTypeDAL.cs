using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using RMS.Model;

namespace RMS.DAL
{
    public class MemberTypeDAL
    {
        /// <summary>
        /// 根据会员类型获取MemberTypeName
        /// </summary>
        /// <param name="memType">会员类型</param>
        /// <returns></returns>
        public string GetMemberTypeNameByMemType(int memType)
        {
            string sql = "select MemTpName from MemmberType where DelFlag=0 and MemType=@MemType order by MemType";
            SQLiteParameter[] ps = {
                new SQLiteParameter("@MemType",memType)
            };
            return SqliteHelper.ExecuteScalar(sql, ps).ToString();
        }

        /// <summary>
        /// 根据删除标识获取MemberType对象
        /// </summary>
        /// <param name="delFlag">删除标识 0--删除 1--未删除</param>
        /// <returns></returns>
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            string sql = "select * from MemmberType where DelFlag=@DelFlag order by MemType";
            SQLiteParameter[] ps = {
                new SQLiteParameter("@DelFlag",delFlag)
            };
            DataTable dt = new DataTable();
            List<MemberType> list = new List<MemberType>();
            dt = SqliteHelper.ExecuteTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberType(dr));
                }
            }
            return list;
        }

        //关系转MemberType对象
        private MemberType RowToMemberType(DataRow dr)
        {
            MemberType mt = new MemberType();
            mt.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            mt.MemTpDesc = dr["MemTpDesc"].ToString();
            mt.MemTpName = dr["MemTpName"].ToString();
            mt.MemType = Convert.ToInt32(dr["MemType"]);
            mt.SubBy = Convert.ToInt32(dr["SubBy"]);
            return mt;
        }
    }
}
