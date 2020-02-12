using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using RMS.Model;

namespace RMS.DAL
{
    public class MemberInfoDAL
    {

        /// <summary>
        /// 根据会员编号和金额更新会员金额
        /// </summary>
        /// <param name="memId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public int UpdateMoneyByMemIdAndMoney(int memId, decimal money)
        {
            string sql = "update Memmberinfo set MemMoney=" + money + " where DelFlag=0 and MemmberId=" + memId;
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据会员的id查询会员的类型
        /// </summary>
        /// <param name="memberId">会员的id</param>
        /// <returns></returns>
        public object GetMemberTypeNameByMemberId(int memberId)
        {
            string sql = "select a.MemTpName from MemmberType a, MemmberInfo b where a.MemType=b.MemType and b.MemmberId=" + memberId;
            return SqliteHelper.ExecuteScalar(sql);
        }

        /// <summary>
        /// 根据会员编号获取会员信息
        /// </summary>
        /// <param name="memNum">会员编号</param>
        /// <returns></returns>
        public List<MemberInfo> GetLikeMemberInfoByMemNum(string memNum)
        {
            string sql = "select * from MemmberInfo where DelFlag=0 and MemNum like @MemNum";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@MemNum", "%" + memNum + "%"));
            List<MemberInfo> list = new List<MemberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    list.Add(RowToMemberInfo(dataRow));
                }
            }
            return list;
        }

        //新增
        public int AddMemmberInfo(MemberInfo mem)
        {
            string sql = "insert into MemmberInfo(MemName,MemMobilePhone,MemType,MemNum,MemGender,MemDiscount,MemMoney,DelFlag,SubTime,MemIntegral,MemEndServerTime,MemBirthdaty,MemAddress) values(@MemName,@MemMobilePhone,@MemType,@MemNum,@MemGender,@MemDiscount,@MemMoney,@DelFlag,@SubTime,@MemIntegral,@MemEndServerTime,@MemBirthdaty,@MemAddress)";
            return AddOrUpdate(sql, mem, 1);
        }
        //修改
        public int UpdateMemmberInfo(MemberInfo mem)
        {
            string sql = "update MemmberInfo set MemName=@MemName,MemMobilePhone=@MemMobilePhone,MemType=@MemType,MemNum=@MemNum,MemGender=@MemGender,MemDiscount=@MemDiscount,MemMoney=@MemMoney,MemIntegral=@MemIntegral,MemEndServerTime=@MemEndServerTime,MemBirthdaty=@MemBirthdaty,MemAddress=@MemAddress where MemmberId=@MemmberId ";
            return AddOrUpdate(sql, mem, 2);
        }
        //合并//temp--1---新增,2---修改
        private int AddOrUpdate(string sql, MemberInfo mem, int temp)
        {

            SQLiteParameter[] param = {
                new SQLiteParameter("@MemName",mem.MemName),
                new SQLiteParameter("@MemMobilePhone",mem.MemMobilePhone),
                new SQLiteParameter("@MemType",mem.MemType),
                new SQLiteParameter("@MemNum",mem.MemNum),
                new SQLiteParameter("@MemGender",mem.MemGendor),
                new SQLiteParameter("@MemDiscount",mem.MemDiscount),
                new SQLiteParameter("@MemMoney",mem.MemMoney),
                new SQLiteParameter("@MemIntegral",mem.MemIntegral),
                new SQLiteParameter("@MemEndServerTime",mem.MemEndServerTime),
                new SQLiteParameter("@MemBirthdaty",mem.MemBirthday),
                new SQLiteParameter("@MemAddress",mem.MemAddress)
             };

            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(param);
            //判断是新增还是修改
            if (temp == 1)//新增
            {
                list.Add(new SQLiteParameter("@DelFlag", mem.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", mem.SubTime));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SQLiteParameter("@MemmberId", mem.MemberId));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据id查会员对象
        /// </summary>
        /// <param name="id">会员id</param>
        /// <returns>会员对象</returns>
        public MemberInfo GetMemberInfoByMemberId(int id)
        {
            string sql = "select * from MemmberInfo where DelFlag=0 and MemmberId=" + id;
            DataTable dataTable = SqliteHelper.ExecuteTable(sql);
            MemberInfo memberInfo = null;
            if (dataTable.Rows.Count > 0)
            {
                memberInfo = RowToMemberInfo(dataTable.Rows[0]);
            }
            return memberInfo;
        }

        /// <summary>
        /// 根据id修改删除标识
        /// </summary>
        /// <param name="memberId">会员id</param>
        /// <returns>受影响的行数</returns>
        public int UpdataMemberInfoById(int memberId)
        {
            string sql = "Update MemmberInfo set DelFlag=1 where MemmberId=@MemmberId";
            return SqliteHelper.ExecuteNonQuery(sql, new SQLiteParameter("@MemmberId", memberId));
        }

        /// <summary>
        /// 根据产品会员编号获取会员信息类
        /// </summary>
        /// <param name="v">会员编号</param>
        /// <returns>会员信息类</returns>
        public List<MemberInfo> GetMemberInfoByMemNum(string memNum)
        {
            string sql = "select * from MemmberInfo where MemNum = " + memNum;
            MemberInfo memberInfo = new MemberInfo();
            List<MemberInfo> list = new List<MemberInfo>();
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberInfo(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据删除标识查询所有的没有删除的会员
        /// </summary>
        /// <param name="delFlag">删除标识 --0 删除的 --1未删除的</param>
        /// <returns>返回会员信息对象的集合</returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int delFlag)
        {
            string sql = "select * from MemmberInfo where DelFlag=@DelFlag";
            DataTable dataTable = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@DelFlag", delFlag));
            List<MemberInfo> list = new List<MemberInfo>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    MemberInfo memberInfo = RowToMemberInfo(dataRow);
                    list.Add(memberInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private MemberInfo RowToMemberInfo(DataRow dataRow)
        {
            MemberInfo memberInfo = new MemberInfo();
            memberInfo.MemAddress = dataRow["MemAddress"].ToString();
            memberInfo.MemBirthday = Convert.ToDateTime(dataRow["MemBirthdaty"]);
            memberInfo.MemDiscount = Convert.ToDecimal(dataRow["MemDiscount"]);
            memberInfo.MemEndServerTime = Convert.ToDateTime(dataRow["MemEndServerTime"]);
            memberInfo.MemGendor = dataRow["MemGender"].ToString();
            memberInfo.MemIntegral = Convert.ToInt32(dataRow["MemIntegral"]);
            memberInfo.MemberId = Convert.ToInt32(dataRow["MemmberId"]);
            memberInfo.MemMobilePhone = dataRow["MemMobilePhone"].ToString();
            memberInfo.MemMoney = Convert.ToDecimal(dataRow["MemMoney"]);
            memberInfo.MemName = dataRow["MemName"].ToString();
            memberInfo.MemNum = dataRow["MemNum"].ToString();
            memberInfo.MemPhone = memberInfo.MemMobilePhone;
            memberInfo.MemType = Convert.ToInt32(dataRow["MemType"]);
            memberInfo.SubTime = Convert.ToDateTime(dataRow["SubTime"]);
            return memberInfo;
        }
    }
}
