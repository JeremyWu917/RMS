using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.Model
{
    public class DeskInfo
    {

        //    CREATE TABLE DeskInfo(
        //    DeskId INTEGER         NOT NULL
        //                               PRIMARY KEY AUTOINCREMENT,
        //    RoomId INTEGER         NULL,
        //    DeskName NVARCHAR( 32 )  NULL,
        //    DeskRemark NVARCHAR( 64 )  NULL,
        //    DeskRegion NVARCHAR( 32 )  NULL,
        //    DeskState SMALLINT        NULL,
        //    DelFlag SMALLINT        NULL,
        //    SubTime DATE            NULL,
        //    SubBy INTEGER         NULL 
        //);

        #region 餐桌信息 Model
        private string _deskStateString;
        //餐桌的字符串数据
        public string DeskStateString
        {
            get { return _deskStateString; }
            set { _deskStateString = value; }
        }

        private int _deskId;
        private int _roomId;
        private string _deskName;
        private string _deskRemark;
        private string _deskRegion;
        private int _deskState;
        private int _delFlag;
        private DateTime _subTime;
        private int _subBy;

        /// <summary>
        /// 餐桌主键ID
        /// </summary>
        public int DeskId { get => _deskId; set => _deskId = value; }
        /// <summary>
        /// 房间主键ID
        /// </summary>
        public int RoomId { get => _roomId; set => _roomId = value; }
        /// <summary>
        /// 餐桌名字
        /// </summary>
        public string DeskName { get => _deskName; set => _deskName = value; }
        /// <summary>
        /// 餐桌备注信息
        /// </summary>
        public string DeskRemark { get => _deskRemark; set => _deskRemark = value; }
        /// <summary>
        /// 餐桌描述信息
        /// </summary>
        public string DeskRegion { get => _deskRegion; set => _deskRegion = value; }
        /// <summary>
        /// 餐桌状态
        /// </summary>
        public int DeskState { get => _deskState; set => _deskState = value; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public int DelFlag { get => _delFlag; set => _delFlag = value; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime SubTime { get => _subTime; set => _subTime = value; }
        /// <summary>
        /// 提交人
        /// </summary>
        public int SubBy { get => _subBy; set => _subBy = value; }



        #endregion

    }
}
