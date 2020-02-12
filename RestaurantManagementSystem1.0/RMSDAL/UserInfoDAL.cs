using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Model;
using System.Data;
using System.Data.SQLite;

namespace RMS.DAL//数据访问层
{
    public class UserInfoDAL
    {
        /// <summary>
        /// 根据用户名去数据库检索，返回的是对象
        /// </summary>
        /// <param name="loginName">登录的账号</param>
        /// <returns>UserInfo对象</returns>
        public UserInfo IsLoginByLoginName(string loginName)
        {
            string sql = "select * from UserInfo where LoginUserName=@LoginUserName";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@LoginUserName", loginName));
            UserInfo userInfo = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    userInfo = RowToUserInfo(dr);
                }
            }
            return userInfo;
        }

        /// <summary>
        /// 关系转UserInfo对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private UserInfo RowToUserInfo(DataRow dr)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            userInfo.LastLoginIP = dr["LastLoginIP"].ToString();
            userInfo.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
            userInfo.LoginUserName = dr["LoginUserName"].ToString();
            userInfo.Pwd = dr["Pwd"].ToString();
            userInfo.SubTime = Convert.ToDateTime(dr["SubTime"]);
            userInfo.UserId = Convert.ToInt32(dr["UserId"]);
            userInfo.UserName = dr["UserName"].ToString();
            return userInfo;
        }
    }
}
