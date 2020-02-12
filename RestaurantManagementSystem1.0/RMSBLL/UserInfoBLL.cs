using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DAL;
using RMS.Model;


namespace RMS.BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL infoDAL = new UserInfoDAL();

        /// <summary>
        /// 根据用户名去数据库检索，返回的是对象
        /// </summary>
        /// <param name="loginName">登录的账号</param>
        /// <returns>UserInfo对象</returns>
        public bool IsLoginByLoginName(string loginName, string pwd, out string msg)
        {
            bool flag = false;
            //获取对象
            UserInfo userInfo = infoDAL.IsLoginByLoginName(loginName);
            if (userInfo != null)
            {
                if (pwd == userInfo.Pwd)
                {
                    flag = true;
                    msg = "登陆成功";
                }
                else
                {
                    msg = "密码不正确，请确认！";
                }
            }
            else
            {
                msg = "账户不存在，请确认！";
            }
            return flag;
        }
    }
}
