using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.BLL;
using RMS.Model;

namespace RMS
{
    public partial class FrmAddMoney : Form
    {
        public FrmAddMoney()
        {
            InitializeComponent();
        }
        private int ID { get; set; }//订单的OrderId
        //窗体传值的方法
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            labDeskName.Text = mea.Name;
            labDeskId.Text = "哈哈哈哈哈哈";
            this.ID = mea.Temp;//订单的id
        }
        //窗体载入时执行
        private void FrmAddMoney_Load(object sender, EventArgs e)
        {
            //载入所有的菜品
            LoadAllProductInfoByDelFlag(0);
            //载入商品的类别 节点树
            LoadCategoryInfoByDelFlag(0);
            //载入已点菜信息
            LoadROderInfoProductByOrderId(this.ID);
        }
        /// <summary>
        /// 载入已点菜信息
        /// </summary>
        /// <param name="v">订单ID</param>
        private void LoadROderInfoProductByOrderId(int v)
        {
            R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
            dgvROrderProduct.AutoGenerateColumns = false;
            dgvROrderProduct.DataSource = bll.GetROrderInfoProduct(v);
            if (dgvROrderProduct.SelectedRows.Count > 0)
            {
                dgvROrderProduct.SelectedRows[0].Selected = false;
            }
            //显示合计金额 
            labSumMoney.Text = bll.GetMoneyAndCount(this.ID).MONEY.ToString();
            //显示点单数量
            labCount.Text = bll.GetMoneyAndCount(this.ID).CT.ToString();
        }

        //所有的菜品类别
        private void LoadCategoryInfoByDelFlag(int v)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = bll.GetAllCategoryInfoByDelFlag(v);
            for (int i = 0; i < list.Count; i++)
            {
                TreeNode tn = tvCategory.Nodes.Add(list[i].CatName);
                LoadProductInfoByCatId(tn, list[i].CatId);
            }
        }
        //根据类别的id加载该类别下的所有的产品
        private void LoadProductInfoByCatId(TreeNode tn, int catId)
        {
            ProductInfoBLL bll = new ProductInfoBLL();
            List<ProductInfo> list = bll.GetAllProductInfoByCatId(catId);
            for (int i = 0; i < list.Count; i++)
            {
                tn.Nodes.Add(list[i].ProName + "--------------------" + list[i].ProPrice + "元");
            }
        }

        //所有的菜--产品
        private void LoadAllProductInfoByDelFlag(int v)
        {
            ProductInfoBLL pbll = new ProductInfoBLL();
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = pbll.GetAllProductInfoByDelFlag(v);
            if (dgvProduct.SelectedRows.Count > 0)
            {
                dgvProduct.SelectedRows[0].Selected = false;
            }
        }
        //双击单元格点菜
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0)
            {
                int ProId = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[0].Value);
                R_OrderInfo_Product rop = new R_OrderInfo_Product();
                rop.OrderId = this.ID;
                rop.ProId = ProId;
                rop.DelFlag = 0;
                rop.SubTime = System.DateTime.Now;
                rop.State = 0;
                if (string.IsNullOrEmpty(txtCount.Text) || txtCount.Text == "0" || txtCount.Text == "1")
                {
                    rop.UnitCount = 1;
                }
                else
                {
                    rop.UnitCount = Convert.ToInt32(txtCount.Text);
                }
                R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
                if (bll.AddROrderInfoProduct(rop))
                {
                    //点菜成功
                    LoadROderInfoProductByOrderId(this.ID);//查询点的什么产品
                }
                else
                {
                    MessageBox.Show("点单失败，请稍后重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("请先选中菜单！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //搜索菜品
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadAllProductInfoByDelFlag(0);
                return;
            }

            int n = 0;
            //拼音搜索 编号 
            if (char.IsLetter(txtSearch.Text[0]))//第一个字符是字母
            {
                n = 1;
            }
            else
            {
                //第一个字符是字母
                n = 2;
            }
            ProductInfoBLL bll = new ProductInfoBLL();
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = bll.GetProductInfoBySpellOrNum(txtSearch.Text, n);
            if (dgvProduct.SelectedRows.Count > 0)
            {
                dgvProduct.SelectedRows[0].Selected = false;
            }
        }
        //退菜
        private void btnDeleteRorderPro_Click(object sender, EventArgs e)
        {
            if (dgvROrderProduct.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvROrderProduct.SelectedRows[0].Cells[0].Value);

                R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
                if (bll.SoftDeleteROrderInfoProductByROrderProId(id))
                {
                    MessageBox.Show("退菜成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadROderInfoProductByOrderId(this.ID);//按照订单ID刷新
                }
                else
                {
                    MessageBox.Show("退菜失败请稍后重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请先选中想要退菜的项目！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //窗体关闭时，更新订单金额
        private void FrmAddMoney_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(labSumMoney.Text))
            {
                OrderInfoBLL bll = new OrderInfoBLL();
                bll.UpdateMoneyByOrderId(this.ID, Convert.ToDecimal(labSumMoney.Text));
            }
        }
    }
}
