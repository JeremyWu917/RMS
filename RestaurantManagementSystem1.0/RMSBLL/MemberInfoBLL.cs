using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class MemberInfoBLL
    {
        MemberInfoDAL memberInfoDAL = new MemberInfoDAL();

        /// <summary>
        /// 根据会员编号和金额更新会员金额
        /// </summary>
        /// <param name="memId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public bool UpdateMoneyByMemIdAndMoney(int memId, decimal money)
        {
            return memberInfoDAL.UpdateMoneyByMemIdAndMoney(memId, money) > 0;
        }

        /// <summary>
        /// 根据会员的id查询会员的类型
        /// </summary>
        /// <param name="memberId">会员的id</param>
        /// <returns></returns>
        public string GetMemberTypeNameByMemberId(int memberId)
        {
            return memberInfoDAL.GetMemberTypeNameByMemberId(memberId).ToString();
        }

        /// <summary>
        /// 根据会员编号获取会员信息
        /// </summary>
        /// <param name="memNum">会员编号</param>
        /// <returns></returns>
        public List<MemberInfo> GetLikeMemberInfoByMemNum(string memNum)
        {
            return memberInfoDAL.GetLikeMemberInfoByMemNum(memNum);
        }

        /// <summary>
        /// 根据产品会员编号获取会员信息类
        /// </summary>
        /// <param name="v">会员编号</param>
        /// <returns>会员信息类</returns>
        public List<MemberInfo> GetMemberInfoByMemNum(string memNum)
        {
            return memberInfoDAL.GetMemberInfoByMemNum(memNum);
        }

        /// <summary>
        /// 修改或者新增会员
        /// </summary>
        /// <param name="memberInfo">会员对象</param>
        /// <param name="temp">标识，1--新增 2--修改</param>
        /// <returns>成功true 失败false</returns>
        public bool SaveMemberInfo(MemberInfo memberInfo, int temp)
        {
            int r = -1;
            if (temp == 1)//新增
            {
                r = memberInfoDAL.AddMemmberInfo(memberInfo);
            }
            else if (temp == 2)//修改
            {
                r = memberInfoDAL.UpdateMemmberInfo(memberInfo);
            }
            return r > 0;
        }

        /// <summary>
        /// 根据id查会员对象
        /// </summary>
        /// <param name="id">会员id</param>
        /// <returns>会员对象</returns>
        public MemberInfo GetMemberInfoByMemberId(int id)
        {
            return memberInfoDAL.GetMemberInfoByMemberId(id);
        }

        /// <summary>
        /// 根据id修改删除标识
        /// </summary>
        /// <param name="memberId">会员id</param>
        /// <returns>true成功 false失败</returns>
        public bool UpdataMemberInfoById(int memberId)
        {
            return memberInfoDAL.UpdataMemberInfoById(memberId) > 0 ? true : false;

        }
        /// <summary>
        /// 根据删除标识查询所有的没有删除的会员
        /// </summary>
        /// <param name="delFlag">删除标识 --0 删除的 --1未删除的</param>
        /// <returns>返回会员信息对象的集合</returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int delFlag)
        {
            return memberInfoDAL.GetAllMemberInfoByDelFlag(delFlag);
        }
    }
}
