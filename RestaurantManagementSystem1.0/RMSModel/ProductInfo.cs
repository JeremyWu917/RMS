using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.Model
{
    //产品信息
    public class ProductInfo
    {
        //    CREATE TABLE ProductInfo(
        //    ProId INTEGER         NOT NULL
        //                             PRIMARY KEY AUTOINCREMENT,
        //    CatId INTEGER         NULL,
        //    ProName NVARCHAR( 32 )  NULL,
        //    ProCost DECIMAL         NULL,
        //    ProSpell NVARCHAR( 64 )  NULL,
        //    ProPrice DECIMAL         NULL,
        //    ProUnit NVARCHAR( 16 )  NULL,
        //    Remark NVARCHAR( 64 )  NULL,
        //    DelFlag SMALLINT        NULL,
        //    SubTime DATE            NULL,
        //    ProStock DECIMAL         NULL,
        //    ProNum NVARCHAR( 32 )  NULL,
        //    SubBy INTEGER         NULL 
        //);

        #region 产品信息Model
        private int _proId;
        private int? _catId;
        private string _proName;
        private decimal? _proCost;
        private string _proSpell;
        private decimal? _proPrice;
        private string _proUnit;
        private string _remark;
        private int? _delFlag;
        private DateTime? _subTime;
        private decimal? _proStock;
        private string _proNum;
        private int? _subBy;

        /// <summary>
        /// 产品主键ID
        /// </summary>
        public int ProId { get => _proId; set => _proId = value; }
        /// <summary>
        /// 商品类别逐渐ID
        /// </summary>
        public int? CatId { get => _catId; set => _catId = value; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProName { get => _proName; set => _proName = value; }
        /// <summary>
        /// 商品进价
        /// </summary>
        public decimal? ProCost { get => _proCost; set => _proCost = value; }
        /// <summary>
        /// 商品中文拼写
        /// </summary>
        public string ProSpell { get => _proSpell; set => _proSpell = value; }
        /// <summary>
        /// 商品售价
        /// </summary>
        public decimal? ProPrice { get => _proPrice; set => _proPrice = value; }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string ProUnit { get => _proUnit; set => _proUnit = value; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get => _remark; set => _remark = value; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public int? DelFlag { get => _delFlag; set => _delFlag = value; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? SubTime { get => _subTime; set => _subTime = value; }
        /// <summary>
        /// 商品库存
        /// </summary>
        public decimal? ProStock { get => _proStock; set => _proStock = value; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProNum { get => _proNum; set => _proNum = value; }
        /// <summary>
        /// 提交人
        /// </summary>
        public int? SubBy { get => _subBy; set => _subBy = value; }

        #endregion

    }
}
