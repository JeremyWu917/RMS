using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using RMS.Model;

namespace RMS.DAL
{
    public class DeskInfoDAL
    {
        /// <summary>
        /// 保存餐桌信息
        /// </summary>
        /// <param name="d">餐桌信息对象</param>
        /// <param name="temp">2--修改 3--新增</param>
        /// <returns></returns>
        public bool SaveDeskInfoByTemp(DeskInfo d, int temp)
        {
            int r = -1;
            if (temp == 2)//修改
            {
                r = UpdateDeskInfo(d);
            }
            else if (temp == 1)//新增
            {
                r = AddDeskInfo(d);
            }
            return r > 0;
        }

        /// <summary>
        /// 插入一条餐桌信息
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private int AddDeskInfo(DeskInfo d)
        {
            string sql = "insert into DeskInfo(RoomId, DeskName, DeskRemark, DeskRegion, DeskState, DelFlag, SubTime, SubBy) values(@RoomId, @DeskName, @DeskRemark, @DeskRegion, @DeskState, @DelFlag, @SubTime, @SubBy)";
            SQLiteParameter[] ps = {
                new SQLiteParameter("@RoomId",d.RoomId),
                new SQLiteParameter("@DeskName",d.DeskName),
                new SQLiteParameter("@DeskRemark",d.DeskRemark),
                new SQLiteParameter("@DeskRegion",d.DeskRegion),
                new SQLiteParameter("@DeskState",d.DeskState),
                new SQLiteParameter("@DelFlag",d.DelFlag),
                new SQLiteParameter("@SubTime",d.SubTime),
                new SQLiteParameter("@SubBy",d.SubBy)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        /// <summary>
        /// 根据餐桌Id更新餐桌信息
        /// </summary>
        /// <param name="d">餐桌Id</param>
        /// <returns></returns>
        private int UpdateDeskInfo(DeskInfo d)
        {
            string sql = "update DeskInfo set RoomId = @RoomId, DeskName = @DeskName, DeskRemark = @DeskRemark, DeskRegion = @DeskRegion where DeskId = @DeskId";
            SQLiteParameter[] ps = {
                new SQLiteParameter("@RoomId",d.RoomId),
                new SQLiteParameter("@DeskName",d.DeskName),
                new SQLiteParameter("@DeskRemark",d.DeskRemark),
                new SQLiteParameter("@DeskRegion",d.DeskRegion),
                new SQLiteParameter("@DeskId",d.DeskId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        /// <summary>
        /// 根据房间Id获取餐桌的数量
        /// </summary>
        /// <param name="roomId">房间ID</param>
        /// <returns></returns>
        public int GetDeskCountByRoomId(int roomId)
        {
            string sql = "select * from DeskInfo where DelFlag=0 and RoomId=" + roomId;
            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sql));
        }

        /// <summary>
        /// 根据餐桌ID查询所有的餐桌信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public DeskInfo GetDeskInfoByDeskId(int deskId)
        {
            string sql = "select * from DeskInfo where DelFlag= 0 and DeskId=" + deskId;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            return RowToDeskInfo(dt.Rows[0]);
        }

        /// <summary>
        /// 根据餐桌ID删除餐桌
        /// </summary>
        /// <param name="deskId">餐桌ID</param>
        /// <returns></returns>
        public int SoftDeleteDeskInfoByDeskId(int deskId)
        {
            string sql = "Update DeskInfo set DelFlag=1 where DelFlag=0 and DeskId=" + deskId;
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据删除标识查询所有的餐桌信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByDelFlag(int delFlag)
        {
            string sql = "select * from DeskInfo where DelFlag=" + delFlag;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            List<DeskInfo> list = new List<DeskInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToDeskInfo(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 更改餐桌的状态
        /// </summary>
        /// <param name="deskId">餐桌ID</param>
        /// <param name="state">状态 0--空闲 1--占用</param>
        /// <returns></returns>
        public int UpdateDeskStateByDeskId(int deskId, int state)
        {
            string sql = "update DeskInfo set DeskState=@DeskState where DelFlag=0 and DeskId=@DeskId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@DeskState", state), new SQLiteParameter("@DeskId", deskId));
        }

        /// <summary>
        /// 根据房间编号查询所有的餐桌信息
        /// </summary>
        /// <param name="roomId">房间编号</param>
        /// <returns>餐桌信息对象</returns>
        public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
        {
            string sql = "select * from DeskInfo where DelFlag=0 and RoomId=@RoomId";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@RoomId", roomId));
            List<DeskInfo> list = new List<DeskInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToDeskInfo(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private DeskInfo RowToDeskInfo(DataRow dr)
        {
            DeskInfo d = new DeskInfo();
            d.DelFlag = Convert.ToInt32(dr["DelFlag"].ToString());
            d.DeskId = Convert.ToInt32(dr["DeskId"].ToString());
            d.DeskName = dr["DeskName"].ToString();
            d.DeskRegion = dr["DeskRegion"].ToString();
            d.DeskRemark = dr["DeskRemark"].ToString();
            d.DeskState = Convert.ToInt32(dr["DeskState"].ToString());
            //状态
            d.DeskStateString = Convert.ToInt32(dr["DeskState"]) == 0 ? "空闲" : "开桌";
            d.RoomId = Convert.ToInt32(dr["RoomId"]);
            d.SubBy = Convert.ToInt32(dr["SubBy"].ToString());
            d.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return d;
        }
    }
}
