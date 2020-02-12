using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class MemberTypeBLL
    {
        MemberTypeDAL dal = new MemberTypeDAL();

        /// <summary>
        /// 根据会员类型获取MemberType对象
        /// </summary>
        /// <param name="memType">会员类型</param>
        /// <returns></returns>
        public string GetAllMemberTypeNameByMemType(int memType)
        {
            return dal.GetMemberTypeNameByMemType(memType);
        }

        /// <summary>
        /// 根据删除标识获取MemberType对象
        /// </summary>
        /// <param name="delFlag">删除标识 0--删除 1--未删除</param>
        /// <returns></returns>
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            return dal.GetAllMemberTypeByDelFlag(delFlag);
        }

    }
}
