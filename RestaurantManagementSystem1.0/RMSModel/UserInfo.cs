using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.Model//模型层
{
    //用户信息
    public class UserInfo
    {
        //CREATE TABLE UserInfo(
        //    UserId        INTEGER         NOT NULL    PRIMARY KEY     AUTOINCREMENT,
        //    UserName      NVARCHAR(32)
        //    LoginUserName NVARCHAR(32)    NOT NULL,
        //    Pwd           NVARCHAR(32)    NOT NULL,
        //    LastLoginTime DATE,
        //    LastLoginIP   NVARCHAR(32),
        //    DelFlag       SMALLINT,
        //    SubTime       DATE
        //);

        #region 用户信息Model

        private int _userId;
        private string _userName;
        private string _loginUserName;
        private string _pwd;
        private DateTime _lastLoginTime;
        private string _lastLoginIP;
        private int _delFlag;
        private DateTime _subTime;

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime SubTime { get => _subTime; set => _subTime = value; }

        /// <summary>
        /// 上次登录IP地址
        /// </summary>
        public string LastLoginIP { get => _lastLoginIP; set => _lastLoginIP = value; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLoginTime { get => _lastLoginTime; set => _lastLoginTime = value; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get => _pwd; set => _pwd = value; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string LoginUserName { get => _loginUserName; set => _loginUserName = value; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get => _userName; set => _userName = value; }

        /// <summary>
        /// 账户ID
        /// </summary>
        public int UserId { get => _userId; set => _userId = value; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int DelFlag { get => _delFlag; set => _delFlag = value; }

        #endregion
    }
}
