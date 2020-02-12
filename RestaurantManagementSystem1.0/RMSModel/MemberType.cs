using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.Model
{
    public class MemberType
    {
        //    CREATE TABLE MemmberType(
        //    MemType INT             PRIMARY KEY,
        //    MemTpName NVARCHAR( 20 ),
        //    MemTpDesc NVARCHAR( 50 ),
        //    DelFlag INT,
        //    SubBy     INT 
        //);

        #region 会员类型Model
        private int _memType;
        private string _memTpName;
        private string _memTpDesc;
        private int _delFlag;
        private int _subBy;

        /// <summary>
        /// 会员类型
        /// </summary>
        public int MemType { get => _memType; set => _memType = value; }
        /// <summary>
        /// 会员类型名称
        /// </summary>
        public string MemTpName { get => _memTpName; set => _memTpName = value; }
        /// <summary>
        /// 会员类型描述
        /// </summary>
        public string MemTpDesc { get => _memTpDesc; set => _memTpDesc = value; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public int DelFlag { get => _delFlag; set => _delFlag = value; }
        /// <summary>
        /// 提交人
        /// </summary>
        public int SubBy { get => _subBy; set => _subBy = value; }

        #endregion



    }
}
