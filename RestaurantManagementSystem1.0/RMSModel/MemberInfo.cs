using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.Model
{
    //会员信息
    public class MemberInfo
    {
        //    CREATE TABLE MemmberInfo(
        //    MemmberId INTEGER         PRIMARY KEY AUTOINCREMENT
        //                                     NOT NULL,
        //    MemName NVARCHAR( 32 ),
        //    MemPhone NVARCHAR( 32 ),
        //    MemMobilePhone NVARCHAR( 32 ),
        //    MemAddress NVARCHAR( 64 ),
        //    MemType INT             DEFAULT '''0''',
        //    MemNum NVARCHAR( 32 ),
        //    MemGender CHAR( 4 ),
        //    MemDiscount DECIMAL         DEFAULT '''1.00''',
        //    MemMoney DECIMAL         DEFAULT '''0''',
        //    DelFlag SMALLINT        DEFAULT( 0 ),
        //    SubTime DATE,
        //    MemIntegral      INTEGER,
        //    MemEndServerTime DATE,
        //    MemBirthdaty     DATE 
        //);

        #region 会员信息Model
        
        private int _memberId;
        private string _memName;
        private string _memTpName;
        private string _memPhone;
        private string _memMobilePhone;
        private string _memAddress;
        private int _memType;
        private string _memNum;
        private string _memGendor;
        private decimal? _memDiscount = 1.00M;
        private decimal? _memMoney = 0M;
        private int _delFlag;
        private DateTime? _subTime;
        private int? _memIntegral;
        private DateTime? _memEndServerTime;
        private DateTime? memBirthday;

        /// <summary>
        /// 会员编号ID
        /// </summary>
        public int MemberId { get => _memberId; set => _memberId = value; }
        
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemName { get => _memName; set => _memName = value; }
        
        /// <summary>
        /// 会员电话
        /// </summary>
        public string MemPhone { get => _memPhone; set => _memPhone = value; }
        
        /// <summary>
        /// 会员手机号码
        /// </summary>
        public string MemMobilePhone { get => _memMobilePhone; set => _memMobilePhone = value; }
        
        /// <summary>
        /// 会员地址
        /// </summary>
        public string MemAddress { get => _memAddress; set => _memAddress = value; }
        
        /// <summary>
        /// 会员类型
        /// </summary>
        public int MemType { get => _memType; set => _memType = value; }
        
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemNum { get => _memNum; set => _memNum = value; }
        
        /// <summary>
        /// 会员性别
        /// </summary>
        public string MemGendor { get => _memGendor; set => _memGendor = value; }
        
        /// <summary>
        /// 会员折扣
        /// </summary>
        public decimal? MemDiscount { get => _memDiscount; set => _memDiscount = value; }
        
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal? MemMoney { get => _memMoney; set => _memMoney = value; }
       
        /// <summary>
        /// 删除标识
        /// </summary>
        public int DelFlag { get => _delFlag; set => _delFlag = value; }
        
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? SubTime { get => _subTime; set => _subTime = value; }
        
        /// <summary>
        /// 会员级别
        /// </summary>
        public int? MemIntegral { get => _memIntegral; set => _memIntegral = value; }
        
        /// <summary>
        /// 会员上次消费时间
        /// </summary>
        public DateTime? MemEndServerTime { get => _memEndServerTime; set => _memEndServerTime = value; }
        
        /// <summary>
        /// 会员生日
        /// </summary>
        public DateTime? MemBirthday { get => memBirthday; set => memBirthday = value; }
        
        /// <summary>
        /// 会员级别名称
        /// </summary>
        public string MemTpName { get => _memTpName; set => _memTpName = value; }

        #endregion
    }
}
