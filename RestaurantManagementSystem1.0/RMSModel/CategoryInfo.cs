using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.Model
{
    //商品类别
    public class CategoryInfo
    {
        //    CREATE TABLE CategoryInfo(
        //    CatId INTEGER         PRIMARY KEY AUTOINCREMENT
        //                            NOT NULL,
        //    CatName NVARCHAR( 32 ),
        //    CatNum NVARCHAR( 32 )  UNIQUE,
        //    Remark NVARCHAR( 64 ),
        //    DelFlag SMALLINT,
        //    SubTime DATE,
        //    SubBy INTEGER 
        //);

        #region 商品类别Model

        private int _catId;
        private string _catName;
        private string _catNum;
        private string _remark;
        private int? delFlag;
        private DateTime? _subTime;
        private int? _subBy;

        /// <summary>
        /// 商品类别主键ID
        /// </summary>
        public int CatId { get => _catId; set => _catId = value; }

        /// <summary>
        /// 商品类别名称
        /// </summary>
        public string CatName { get => _catName; set => _catName = value; }

        /// <summary>
        /// 商品类别编号
        /// </summary>
        public string CatNum { get => _catNum; set => _catNum = value; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get => _remark; set => _remark = value; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? DelFlag { get => delFlag; set => delFlag = value; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? SubTime { get => _subTime; set => _subTime = value; }

        /// <summary>
        /// 提交人
        /// </summary>
        public int? SubBy { get => _subBy; set => _subBy = value; }

        #endregion
    }
}
