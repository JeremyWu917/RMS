using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using RMS.Model;

namespace RMS.DAL
{
    public class ProductInfoDAL
    {
        /// <summary>
        /// 根据拼音或者产品编号查询产品信息对象
        /// </summary>
        /// <param name="num">拼音或者产品编号</param>
        /// <param name="temp">1--拼音 2--产品编号</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoBySpellOrNum(string num, int temp)
        {
            string sql = "select * from ProductInfo where DelFlag=0 ";
            if (temp == 1)//拼音
            {
                sql += "and ProSpell like @ProSpell";
            }
            else if (temp == 2)//编号
            {
                sql += "and ProNum like @ProSpell";
            }
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@ProSpell", "%"+num+"%"));
            List<ProductInfo> list = new List<ProductInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据CatID获取产品信息
        /// </summary>
        /// <param name="catId">产品类别ID</param>
        /// <returns>首行产品信息</returns>
        public object GetProductInfoCountByCatId(int catId)
        {
            string sql = "select count(*) from ProductInfo where DelFlag=0 and CatId=" + catId;
            return SqliteHelper.ExecuteScalar(sql);
        }

        /// <summary>
        /// 根据产品编号获取产品信息集合
        /// </summary>
        /// <param name="proNum">产品编号</param>
        /// <returns>产品信息集合</returns>
        public List<ProductInfo> GetProductInfoByProNum(string proNum)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and ProNum like @ProNum";
            DataTable dt = SqliteHelper.ExecuteTable(sql, new SQLiteParameter("@ProNum", "%" + proNum + "%"));
            List<ProductInfo> list = new List<ProductInfo>();
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据产品类别Id查询产品信息
        /// </summary>
        /// <param name="catId">产品类别ID</param>
        /// <returns>产品信息对象</returns>
        public List<ProductInfo> GetAllProductInfoByCatId(int catId)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and CatId=" + catId;
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }
        //新增产品信息
        public int AddProductInfo(ProductInfo pro)
        {
            string sql = "insert into ProductInfo(CatId,ProName,ProCost,ProSpell,ProPrice,ProUnit,Remark,DelFlag,SubTime,ProStock,ProNum,SubBy) values(@CatId,@ProName,@ProCost,@ProSpell,@ProPrice,@ProUnit,@Remark,@DelFlag,@SubTime,@ProStock,@ProNum,@SubBy)";
            return AddOrUpdate(pro, sql, 3);
        }
        //修改产品信息
        public int UpdateProductInfo(ProductInfo pro)
        {
            string sql = "update ProductInfo set CatId=@CatId,ProName=@ProName,ProCost=@ProCost,ProSpell=@ProSpell,ProPrice=@ProPrice,ProUnit=@ProUnit,Remark=@Remark,ProStock=@ProStock,ProNum=@ProNum where ProId=@ProId";
            return AddOrUpdate(pro, sql, 4);
        }
        private int AddOrUpdate(ProductInfo pro, string sql, int temp)
        {
            SQLiteParameter[] ps = {
              new SQLiteParameter("@CatId",pro.CatId),
              new SQLiteParameter("@ProName",pro.ProName),
              new SQLiteParameter("@ProCost",pro.ProCost),
              new SQLiteParameter("@ProSpell",pro.ProSpell),
              new SQLiteParameter("@ProPrice",pro.ProPrice),
              new SQLiteParameter("@ProUnit",pro.ProUnit),
              new SQLiteParameter("@Remark",pro.Remark),
              new SQLiteParameter("@ProStock",pro.ProStock),
              new SQLiteParameter("@ProNum",pro.ProNum)
                                   };

            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(ps);

            if (temp == 3)//新增
            {
                list.Add(new SQLiteParameter("@DelFlag", pro.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", pro.SubTime));
                list.Add(new SQLiteParameter("@SubBy", pro.SubBy));
            }
            else if (temp == 4)//修改
            {
                list.Add(new SQLiteParameter("@ProId", pro.ProId));
            }
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据id查询ProductInfo对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductInfo GetProductInfoByProId(int id)
        {
            string sql = "select * from ProductInfo where DelFlag=0 and ProId=" + id;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            ProductInfo pro = null;
            if (dt.Rows.Count > 0)
            {
                pro = RowToProductInfo(dt.Rows[0]);
            }
            return pro;
        }

        /// <summary>
        /// 根据产品ID删除产品信息
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>返回受影响的行</returns>
        public int SoftDelteProductInfo(int id)
        {
            string sql = "update ProductInfo set DelFlag=1 where ProId=" + id;
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 通过删除标识获取所有的产品信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            string sql = "select * from ProductInfo where DelFlag=" + delFlag;
            DataTable dt = SqliteHelper.ExecuteTable(sql);
            List<ProductInfo> list = new List<ProductInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 关系转ProductInfo对象
        /// </summary>
        /// <param name="dr"></param>
        private ProductInfo RowToProductInfo(DataRow dr)
        {
            ProductInfo productInfo = new ProductInfo();
            productInfo.CatId = Convert.ToInt32(dr["CatId"]);
            productInfo.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            productInfo.ProCost = Convert.ToDecimal(dr["ProCost"]);
            productInfo.ProId = Convert.ToInt32(dr["ProId"]);
            productInfo.ProName = dr["ProName"].ToString();
            productInfo.ProNum = dr["ProNum"].ToString();
            productInfo.ProPrice = Convert.ToDecimal(dr["ProPrice"]);
            productInfo.ProSpell = dr["ProSpell"].ToString();
            productInfo.ProStock = Convert.ToDecimal(dr["ProStock"]);
            productInfo.ProUnit = dr["ProUnit"].ToString();
            productInfo.Remark = dr["Remark"].ToString();
            productInfo.SubBy = Convert.ToInt32(dr["SubBy"]);
            productInfo.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return productInfo;
        }
    }
}
