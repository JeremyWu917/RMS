using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using RMS.Model;

namespace RMS.DAL
{
    public class CategoryInfoDAL
    {
        /// <summary>
        /// 根据产品类别ID删除产品类别信息
        /// </summary>
        /// <param name="catId">产品类别ID</param>
        /// <returns></returns>
        public int SoftDeleteCategoryInfoByCatId(int catId)
        {
            string sql = "update CategoryInfo set DelFlag=1 where CatId=" + catId;
           return SqliteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 新增商品类别
        /// </summary>
        /// <param name="ct">Categroty对象</param>
        /// <returns></returns>
        public int AddCategrotyInfo(CategoryInfo ct)
        {
            string sql = "insert into CategoryInfo(CatName,CatNum,Remark,DelFlag,SubTime,SubBy) values(@CatName,@CatNum,@Remark,@DelFlag,@SubTime,@SubBy)";
            return AddAndUpdateCategrotyInfo(sql, 1, ct);
        }

        /// <summary>
        /// 修改商品类别
        /// </summary>
        /// <param name="ct">Categroty对象</param>
        /// <returns></returns>
        public int UpdateCategrotyInfo(CategoryInfo ct)
        {
            string sql = "update CategoryInfo set CatName=@CatName,CatNum=@CatNum,Remark=@Remark where CatId=@CatId";
            return AddAndUpdateCategrotyInfo(sql, 2, ct);
        }

        /// <summary>
        /// 商品类别的新增或者修改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="temp">标识</param>
        /// <param name="ct">Categroty对象</param>
        /// <returns></returns>
        private int AddAndUpdateCategrotyInfo(string sql, int temp, CategoryInfo ct)
        {
            SQLiteParameter[] ps = {
            new SQLiteParameter("@CatName",ct.CatName),
            new SQLiteParameter("@CatNum",ct.CatNum),
            new SQLiteParameter("@Remark",ct.Remark),

            };

            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(ps);
            if (temp == 1)//新增
            {
                list.Add(new SQLiteParameter("@DelFlag", ct.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", ct.SubTime));
                list.Add(new SQLiteParameter("@SubBy", ct.SubBy));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SQLiteParameter("@CatId", ct.CatId));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据商品类别ID获取商品类别信息
        /// </summary>
        /// <param name="id">商品类别ID</param>
        /// <returns></returns>
        public CategoryInfo GetCategoryInfoById(int id)
        {
            string sql = "select * from CategoryInfo where DelFlag=0 and CatId=" + id;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            CategoryInfo ci = null;
            if (dt.Rows.Count > 0)
            {
                ci = RowToCategoryInfo(dt.Rows[0]);
            }
            return ci;
        }

        /// <summary>
        /// 查询所有的商品类别
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            string sql = "select * from CategoryInfo where DelFlag=" + delFlag;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            List<CategoryInfo> list = new List<CategoryInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToCategoryInfo(dr));
                }
            }
            return list;
        }
        
        /// <summary>
        /// 关系转Category对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private CategoryInfo RowToCategoryInfo(DataRow dr)
        {
            CategoryInfo ct = new CategoryInfo();
            ct.CatId = Convert.ToInt32(dr["CatId"]);
            ct.CatName = dr["CatName"].ToString();
            ct.CatNum = dr["CatNum"].ToString();
            ct.Remark = dr["Remark"].ToString();
            return ct;
        }
    }
}
