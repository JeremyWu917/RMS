using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Model;
using System.Data;
using System.Data.SQLite;

namespace RMS.DAL
{
    public class RoomInfoDAL
    {

        /// <summary>
        /// 根据房间对象插入房间信息
        /// </summary>
        /// <param name="r">房间对象</param>
        /// <returns></returns>
        private int AddRoomInfo(RoomInfo r)
        {
            string sql = "insert into RoomInfo(RoomName,RoomType,RoomMinimunConsume,RoomMaxConsumer,IsDefault,DelFlag,SubTime,SubBy) values(@RoomName, @RoomType, @RoomMinimunConsume, @RoomMaxConsumer, @IsDefault, 0, @SubTime, 1)";
            SQLiteParameter[] ps = {
                new SQLiteParameter("@RoomName",r.RoomName),
                new SQLiteParameter("@RoomType",r.RoomType),
                new SQLiteParameter("@RoomMinimunConsume",r.RoomMinimunConsume),
                new SQLiteParameter("@RoomMaxConsumer",r.RoomMaxConsumer),
                new SQLiteParameter("@IsDefault",r.IsDefault),
                new SQLiteParameter("@SubTime",r.SubTime)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        /// <summary>
        /// 根据房间对象更新房间信息
        /// </summary>
        /// <param name="r">房间信息</param>
        /// <returns></returns>
        private int UpdateRoomInfo(RoomInfo r)
        {
            string sql = "update RoomInfo set RoomName=@RoomName,RoomType=@RoomType,RoomMinimunConsume=@RoomMinimunConsume,RoomMaxConsumer=@RoomMaxConsumer,IsDefault=@IsDefault where RoomId = @RoomId";
            SQLiteParameter[] ps = {
                new SQLiteParameter("@RoomName",r.RoomName),
                new SQLiteParameter("@RoomType",r.RoomType),
                new SQLiteParameter("@RoomMinimunConsume",r.RoomMinimunConsume),
                new SQLiteParameter("@RoomMaxConsumer",r.RoomMaxConsumer),
                new SQLiteParameter("@IsDefault",r.IsDefault),
                new SQLiteParameter("@RoomId",r.RoomId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        /// <summary>
        /// 根据房间对象和标识保存房间信息
        /// </summary>
        /// <param name="r">房间对象</param>
        /// <param name="temp">标识3--新增 4--更新</param>
        /// <returns></returns>
        public bool SaveRoomInfo(RoomInfo r, int temp)
        {
            int i = -1;
            if (temp == 3)//新增
            {
                i = AddRoomInfo(r);
            }
            else if (temp == 4)//更新
            {
                i = UpdateRoomInfo(r);
            }
            return i > 0;
        }

        /// <summary>
        /// 根据房间ID获取房间信息对象
        /// </summary>
        /// <param name="roomId">房间ID</param>
        /// <returns></returns>
        public RoomInfo GetRoomInfoByRoomId(int roomId)
        {
            string sql = "select * from RoomInfo where DelFlag=0 and RoomId=" + roomId;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            RoomInfo r = new RoomInfo();
            if (dt.Rows.Count > 0)
            {
                r = RowToRoomInfo(dt.Rows[0]);
            }
            return r;
        }

        /// <summary>
        /// 根据房间ID删除房间信息 假删除
        /// </summary>
        /// <param name="roomId">房间ID</param>
        /// <returns></returns>
        public int SoftDeleteRoomInfoByRoomId(int roomId)
        {
            string sql = "update RoomInfo set DelFlag=1 where DelFlag=0 and RoomId=" + roomId;
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据删除标识获取房间信息
        /// </summary>
        /// <param name="delFlag">删除标识 0--未删除 1--已删除</param>
        /// <returns></returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            string sql = "select * from RoomInfo where DelFlag=" + delFlag;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            List<RoomInfo> list = new List<RoomInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToRoomInfo(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 关系转RoomInfo对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private RoomInfo RowToRoomInfo(DataRow dr)
        {
            RoomInfo r = new RoomInfo();
            r.DelFlag = Convert.ToInt32(dr["DelFlag"].ToString());
            r.RoomId = Convert.ToInt32(dr["RoomId"].ToString());
            r.RoomMaxConsumer = Convert.ToInt32(dr["RoomMaxConsumer"].ToString());
            r.RoomMinimunConsume = Convert.ToDecimal(dr["RoomMinimunConsume"].ToString());
            r.RoomName = dr["RoomName"].ToString();
            r.RoomType = Convert.ToInt32(dr["RoomType"].ToString());
            r.SubBy = Convert.ToInt32(dr["SubBy"].ToString());
            r.SubTime = Convert.ToDateTime(dr["SubTime"].ToString());
            r.IsDefault = Convert.ToInt32(dr["IsDefault"]);
            return r;
        }
    }
}
