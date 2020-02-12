using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class DeskInfoBLL
    {
        DeskInfoDAL dal = new DeskInfoDAL();

        /// <summary>
        /// 保存餐桌信息
        /// </summary>
        /// <param name="d">餐桌信息对象</param>
        /// <param name="temp">2--修改 3--新增</param>
        /// <returns></returns>
        public bool SaveDeskInfoByTemp(DeskInfo d, int temp)
        {
            return dal.SaveDeskInfoByTemp(d, temp);
        }

        /// <summary>
        /// 根据房间Id获取餐桌的数量
        /// </summary>
        /// <param name="roomId">房间ID</param>
        /// <returns></returns>
        public bool GetDeskCountByRoomId(int roomId)
        {
            return dal.GetDeskCountByRoomId(roomId) > 0;
        }

        /// <summary>
        /// 根据餐桌ID查询所有的餐桌信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public DeskInfo GetDeskInfoByDeskId(int deskId)
        {
            return dal.GetDeskInfoByDeskId(deskId);
        }

        /// <summary>
        /// 根据餐桌ID删除餐桌
        /// </summary>
        /// <param name="deskId">餐桌ID</param>
        /// <returns></returns>
        public bool SoftDeleteDeskInfoByDeskId(int deskId)
        {
            return dal.SoftDeleteDeskInfoByDeskId(deskId) > 0;
        }

        /// <summary>
        /// 根据删除标识查询所有的餐桌信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByDelFlag(int delFlag)
        {
            return dal.GetAllDeskInfoByDelFlag(delFlag);
        }

        /// <summary>
        /// 更改餐桌的状态
        /// </summary>
        /// <param name="deskId">餐桌ID</param>
        /// <param name="state">状态 0--空闲 1--占用</param>
        /// <returns></returns>
        public bool UpdateDeskStateByDeskId(int deskId, int state)
        {
            return dal.UpdateDeskStateByDeskId(deskId, state) > 0;
        }

        /// <summary>
        /// 根据房间编号查询所有的餐桌信息
        /// </summary>
        /// <param name="roomId">房间编号</param>
        /// <returns>餐桌信息对象</returns>
        public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
        {
            return dal.GetAllDeskInfoByRoomId(roomId);
        }


    }
}
