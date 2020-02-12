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
    public partial class FrmChangeProductInfo : Form
    {
        public FrmChangeProductInfo()
        {
            InitializeComponent();
        }

        private int TP { get; set; }

        //刷新下来列表
        private void LoadCategoryInfoByDelFlag(int v)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = new List<CategoryInfo>();
            list = bll.GetAllCategoryInfoByDelFlag(v);
            list.Insert(0, new CategoryInfo() { CatName = "请选择", CatId = -1 });
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "CatName";
            cmbCategory.ValueMember = "CatId";
        }
        public void SetText(Object sender, EventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;

            if (this.TP == 3)//新增
            {

            }
            else if (this.TP == 4)//修改
            {
                ProductInfo pro = mea.Obj as ProductInfo;
                txtCost.Text = pro.ProCost.ToString();
                txtName.Text = pro.ProName;
                txtNum.Text = pro.ProNum;
                txtPrice.Text = pro.ProPrice.ToString();
                txtRemark.Text = pro.Remark;
                txtSpell.Text = pro.ProSpell;
                txtStock.Text = pro.ProStock.ToString();
                txtUnit.Text = pro.ProUnit;
                labId.Text = pro.ProId.ToString();//id存起来

                //类别
                cmbCategory.SelectedValue = pro.CatId;
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            //判断是新增还是修改
            if (CheckEmpty())
            {
                ProductInfo pro = new ProductInfo();
                pro.CatId = Convert.ToInt32(cmbCategory.SelectedValue);
                pro.ProCost = Convert.ToDecimal(txtCost.Text);
                pro.ProName = txtName.Text;
                pro.ProNum = txtNum.Text;
                pro.ProPrice = Convert.ToDecimal(txtPrice.Text);
                pro.ProSpell = txtSpell.Text;
                pro.ProStock = Convert.ToDecimal(txtStock.Text);
                pro.ProUnit = txtUnit.Text;
                pro.Remark = txtRemark.Text;

                if (this.TP == 3)//新增
                {
                    pro.DelFlag = 0;
                    pro.SubBy = 1;
                    pro.SubTime = System.DateTime.Now;
                }
                else if (this.TP == 4)//修改
                {
                    pro.ProId = Convert.ToInt32(labId.Text);
                }

                ProductInfoBLL bll = new ProductInfoBLL();
                if (bll.SaveProduct(pro, this.TP))
                {
                    MessageBox.Show("保存成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败，请确认！");
                }
                this.Close();
            }
        }

        //判断每个文本框不能为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                MessageBox.Show("商品成本不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("商品名称不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                MessageBox.Show("商品编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("商品价格不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                MessageBox.Show("商品备注不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtSpell.Text))
            {
                MessageBox.Show("商品拼音不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("商品库存不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                MessageBox.Show("商品单位不能为空");
                return false;
            }
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("请选择类别！");
                return false;
            }
            return true;
        }


    }
}
