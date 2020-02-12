using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class ProductInfoBLL
    {
        ProductInfoDAL dal = new ProductInfoDAL();

        /// <summary>
        /// 根据拼音或者产品编号查询产品信息对象
        /// </summary>
        /// <param name="num">拼音或者产品编号</param>
        /// <param name="temp">1--拼音 2--产品编号</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoBySpellOrNum(string num, int temp)
        {
            return dal.GetProductInfoBySpellOrNum(num, temp);
        }

        /// <summary>
        /// 根据CatID获取产品信息
        /// </summary>
        /// <param name="catId">产品类别ID</param>
        /// <returns></returns>
        public bool GetProductInfoCountByCatId(int catId)
        {
            return Convert.ToInt32(dal.GetProductInfoCountByCatId(catId)) > 0;
        }
        
        /// <summary>
        /// 根据产品编号获取产品信息集合
        /// </summary>
        /// <param name="proNum">产品编号</param>
        /// <returns>产品信息集合</returns>
        public List<ProductInfo> GetProductInfoByProNum(string proNum)
        {
            return dal.GetProductInfoByProNum(proNum);
        }

        /// <summary>
        /// 根据产品类别Id查询产品信息
        /// </summary>
        /// <param name="catId">产品类别ID</param>
        /// <returns>产品信息对象</returns>
        public List<ProductInfo> GetAllProductInfoByCatId(int catId)
        {
            return dal.GetAllProductInfoByCatId(catId);
        }

        /// <summary>
        /// 增加或者修改产品信息
        /// </summary>
        /// <param name="pro">产品信息对象</param>
        /// <param name="temp">标识 3--增加 4--修改</param>
        /// <returns></returns>
        public bool SaveProduct(ProductInfo pro, int temp)
        {
            int r = -1;
            if (temp == 3)//增加
            {
                r = dal.AddProductInfo(pro);
            }
            else if (temp == 4)//修改
            {
                r = dal.UpdateProductInfo(pro);
            }
            return r > 0;
        }

        /// <summary>
        /// 根据id查询ProductInfo对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductInfo GetProductInfoByProId(int id)
        {
            return dal.GetProductInfoByProId(id);
        }
       
        /// <summary>
        /// 根据产品ID删除产品信息
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>true删除成功 false删除失败</returns>
        public bool SoftDelteProductInfo(int id)
        {
            return dal.SoftDelteProductInfo(id) > 0;
        }

        /// <summary>
        /// 通过删除标识获取所有的产品信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            return dal.GetAllProductInfoByDelFlag(delFlag);
        }
    }
}
