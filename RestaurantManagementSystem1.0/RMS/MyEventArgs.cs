using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS
{
    public class MyEventArgs : EventArgs
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Temp { get; set; }

        /// <summary>
        /// 对象
        /// </summary>
        public object Obj { get; set; }

        /// <summary>
        /// 最低消费金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 房间类型
        /// </summary>
        public string Name { get; set; }
    }
}
