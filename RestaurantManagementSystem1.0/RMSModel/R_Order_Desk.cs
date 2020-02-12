using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.Model
{
    public class R_Order_Desk
    {
        #region 中间表 Model

        private int _rId;
        private int _orderId;
        private int _deskId;

        /// <summary>
        /// 中间表主键ID
        /// </summary>
        public int RId
        {
            get { return _rId; }
            set { _rId = value; }
        }

        /// <summary>
        /// 订单表主键ID
        /// </summary>
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        /// <summary>
        /// 餐桌表主键ID
        /// </summary>
        public int DeskId
        {
            get { return _deskId; }
            set { _deskId = value; }
        }
        #endregion
    }
}
