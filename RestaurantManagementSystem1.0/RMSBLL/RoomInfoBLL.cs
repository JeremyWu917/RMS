using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Model;
using RMS.DAL;

namespace RMS.BLL
{
    public class RoomInfoBLL
    {
        RoomInfoDAL dal = new RoomInfoDAL();

        /// <summary>
        /// 根据房间对象和标识保存房间信息
        /// </summary>
        /// <param name="r">房间对象</param>
        /// <param name="temp">标识3--新增 4--更新</param>
        /// <returns></returns>
        public bool SaveRoomInfo(RoomInfo r, int temp)
        {
            return dal.SaveRoomInfo(r,temp);
        }

        /// <summary>
        /// 根据房间ID获取房间信息对象
        /// </summary>
        /// <param name="roomId">房间ID</param>
        /// <returns></returns>
        public RoomInfo GetRoomInfoByRoomId(int roomId)
        {
            return dal.GetRoomInfoByRoomId(roomId);
        }

        /// <summary>
        /// 根据房间ID删除房间信息 假删除
        /// </summary>
        /// <param name="roomId">房间ID</param>
        /// <returns></returns>
        public bool SoftDeleteRoomInfoByRoomId(int roomId)
        {
            return dal.SoftDeleteRoomInfoByRoomId(roomId) > 0;
        }

        /// <summary>
        /// 根据删除标识获取房间信息
        /// </summary>
        /// <param name="delFlag">删除标识 0--未删除 1--已删除</param>
        /// <returns></returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            return dal.GetAllRoomInfoByDelFlag(delFlag);
        }



    }
}
