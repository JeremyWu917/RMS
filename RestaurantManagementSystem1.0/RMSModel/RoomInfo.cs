using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.Model
{
    public class RoomInfo
    {
        //    CREATE TABLE RoomInfo(
        //    RoomId INTEGER         NOT NULL
        //                                       PRIMARY KEY AUTOINCREMENT,
        //    RoomName NVARCHAR( 32 )  NULL,
        //    RoomType SMALLINT        NULL,
        //    RoomMinimunConsume DECIMAL         NULL,
        //    RoomMaxConsumer INTEGER         DEFAULT '''100'''
        //                                       NULL,
        //    IsDefault SMALLINT        NULL,
        //    DelFlag SMALLINT        NULL,
        //    SubTime DATE            NULL,
        //    SubBy INTEGER         NULL 
        //);
        #region 房间信息 Model
        private int _roomId;
        private string _roomName;
        private int? _roomType;
        private decimal? _roomMinimunConsume;
        private int? _roomMaxConsumer;
        private int? _isDefault;
        private int? _delFlag;
        private DateTime? _subTime;
        private int? _subBy;

        /// <summary>
        /// 房间主键ID
        /// </summary>
        public int RoomId { get => _roomId; set => _roomId = value; }
        /// <summary>
        /// 房间名称
        /// </summary>
        public string RoomName { get => _roomName; set => _roomName = value; }
        /// <summary>
        /// 房间类型
        /// </summary>
        public int? RoomType { get => _roomType; set => _roomType = value; }
        /// <summary>
        /// 房间最低消费
        /// </summary>
        public decimal? RoomMinimunConsume { get => _roomMinimunConsume; set => _roomMinimunConsume = value; }
        /// <summary>
        /// 房间最大可容纳人数
        /// </summary>
        public int? RoomMaxConsumer { get => _roomMaxConsumer; set => _roomMaxConsumer = value; }
        /// <summary>
        /// 默认房间编号
        /// </summary>
        public int? IsDefault { get => _isDefault; set => _isDefault = value; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public int? DelFlag { get => _delFlag; set => _delFlag = value; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? SubTime { get => _subTime; set => _subTime = value; }
        /// <summary>
        /// 提交人
        /// </summary>
        public int? SubBy { get => _subBy; set => _subBy = value; }
        #endregion

    }
}
