using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class CategoryInfoBLL
    {
        CategoryInfoDAL dal = new CategoryInfoDAL();

        /// <summary>
        /// 根据产品类别ID删除产品类别信息
        /// </summary>
        /// <param name="catId">产品类别ID</param>
        /// <returns></returns>
        public bool SoftDeleteCategoryInfoByCatId(int catId)
        {
            return dal.SoftDeleteCategoryInfoByCatId(catId) > 0;
        }

        /// <summary>
        /// 新增或者修改商品类别
        /// </summary>
        /// <param name="ct">类别对象</param>
        /// <param name="temp">1--新增 2--修改</param>
        /// <returns></returns>
        public bool SaveCategoryInfo(CategoryInfo ct, int temp)
        {
            int r = -1;
            if (temp == 1)//新增
            {
                r = dal.AddCategrotyInfo(ct);
            }
            else if (temp == 2)//修改
            {
                r = dal.UpdateCategrotyInfo(ct);
            }
            return r > 0;
        }

        /// <summary>
        /// 根据商品类别ID获取商品类别信息
        /// </summary>
        /// <param name="id">商品类别ID</param>
        /// <returns></returns>
        public CategoryInfo GetCategoryInfoById(int id)
        {
            return dal.GetCategoryInfoById(id);

        }

        /// <summary>
        /// 查询所有的商品类别
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            return dal.GetAllCategoryInfoByDelFlag(delFlag);
        }

    }
}
