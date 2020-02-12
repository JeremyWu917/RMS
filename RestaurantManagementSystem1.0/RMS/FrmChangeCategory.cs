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
    public partial class FrmChangeCategory : Form
    {
        public FrmChangeCategory()
        {
            InitializeComponent();
        }
        //存标识
        private int TP { get; set; }
        public void SetText(Object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;

            if (this.TP == 1)//新增
            {

            }
            else if (this.TP == 2)//修改
            {
                CategoryInfo ct = mea.Obj as CategoryInfo;
                txtCName.Text = ct.CatName;
                txtCNum.Text = ct.CatNum;
                txtCRemark.Text = ct.Remark;
                labId.Text = ct.CatId.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                CategoryInfo ct = new CategoryInfo();
                ct.CatName = txtCName.Text;
                ct.CatNum = txtCNum.Text;
                ct.Remark = txtCRemark.Text;
                if (this.TP == 1)//新增
                {
                    ct.DelFlag = 0;
                    ct.SubBy = 1;
                    ct.SubTime = System.DateTime.Now;
                }
                else if (this.TP == 2)//修改
                {
                    ct.CatId = Convert.ToInt32(labId.Text);
                }
                CategoryInfoBLL bll = new CategoryInfoBLL();
                if (bll.SaveCategoryInfo(ct, this.TP))
                {
                    MessageBox.Show("保存成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Close();
            }

        }

        //判断文本框不能为空
        private bool CheckEmpty()
        {
            if (txtCName.Text == "")
            {
                MessageBox.Show("类别名称不能为空，请确认！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            if (txtCNum.Text == "")
            {
                MessageBox.Show("编号名称不能为空，请确认！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            if (txtCRemark.Text == "")
            {
                MessageBox.Show("备注不能为空，请确认！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
