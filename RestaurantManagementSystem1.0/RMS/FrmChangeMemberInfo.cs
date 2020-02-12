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
    public partial class FrmChangeMemberInfo : Form
    {
        public FrmChangeMemberInfo()
        {
            InitializeComponent();
        }
        //存标识
        private int TP { get; set; }
        //存会员类型
        private int MemType { get; set; }
        //为该窗体的所有文本框赋值
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;
            if (this.TP == 1)//新增
            {
                //清空所有文本框
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox textBox = item as TextBox;
                        textBox.Text = "";
                    }
                }
                txtMemIntegral.Text = "0";
                rdoMan.Checked = true;
            }
            else if (this.TP == 2)//修改
            {
                //赋值
                MemberInfo memberInfo = mea.Obj as MemberInfo;
                labId.Text = memberInfo.MemberId.ToString();
                txtBirs.Text = memberInfo.MemBirthday.ToString();//生日
                txtMemDiscount.Text = memberInfo.MemDiscount.ToString();//折扣
                txtMemIntegral.Text = memberInfo.MemIntegral.ToString();//积分
                txtmemMoney.Text = memberInfo.MemMoney.ToString();//余额
                txtMemName.Text = memberInfo.MemName;//姓名
                txtMemNum.Text = memberInfo.MemNum;//编号
                txtMemPhone.Text = memberInfo.MemPhone;//电话号码
                //性别
                rdoMan.Checked = memberInfo.MemGendor == "男" ? true : false;
                rdoWomen.Checked = memberInfo.MemGendor == "女" ? true : false;
                //结束日期
                dtEndServerTime.Value = Convert.ToDateTime(memberInfo.MemEndServerTime);
                txtMemAddress.Text = memberInfo.MemAddress;//地址
                //会员类型
                this.MemType = memberInfo.MemType;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                //获取每个文本框的值
                MemberInfo memberInfo = new MemberInfo();
                memberInfo.MemBirthday = Convert.ToDateTime(txtBirs.Text);
                memberInfo.MemDiscount = Convert.ToDecimal(txtMemDiscount.Text);
                memberInfo.MemEndServerTime = Convert.ToDateTime(dtEndServerTime.Value);
                memberInfo.MemGendor = CheckGendor();
                memberInfo.MemIntegral = Convert.ToInt32(txtMemIntegral.Text);
                memberInfo.MemMobilePhone = txtMemPhone.Text;
                memberInfo.MemMoney = Convert.ToDecimal(txtmemMoney.Text);
                memberInfo.MemName = txtMemName.Text;
                memberInfo.MemNum = txtMemNum.Text;
                memberInfo.MemType = Convert.ToInt32(cmbMemType.SelectedIndex);
                memberInfo.MemAddress = txtMemAddress.Text;

                //判断是新增还是修改
                if (this.TP == 1)//新增
                {
                    memberInfo.DelFlag = 0;
                    memberInfo.SubTime = System.DateTime.Now;
                }
                else if (this.TP == 2)//修改
                {
                    memberInfo.MemberId = Convert.ToInt32(labId.Text);
                }

                MemberInfoBLL memberInfoBLL = new MemberInfoBLL();
                string msg = memberInfoBLL.SaveMemberInfo(memberInfo, this.TP) ? "操作成功！" : "操作失败！";
                MessageBox.Show(msg, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        //性别
        private string CheckGendor()
        {
            string str = "";
            if (rdoMan.Checked)
            {
                str = "男";
            }
            else if (rdoWomen.Checked)
            {
                str = "女";
            }
            return str;
        }

        //判断所有的文本框不为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtBirs.Text))
            {
                MessageBox.Show("生日不能为空！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMemDiscount.Text))
            {
                MessageBox.Show("折扣不能为空！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMemIntegral.Text))
            {
                MessageBox.Show("积分不能为空！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtmemMoney.Text))
            {
                MessageBox.Show("余额不能为空！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMemName.Text))
            {
                MessageBox.Show("姓名不能为空！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMemNum.Text))
            {
                MessageBox.Show("编号不能为空！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMemPhone.Text))
            {
                MessageBox.Show("电话不能为空！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMemAddress.Text))
            {
                MessageBox.Show("电话不能为空！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //窗体载入
        private void FrmChangeMemberInfo_Load(object sender, EventArgs e)
        {
            LoadMemberTypeByTemp(this.TP);

        }

        /// <summary>
        /// 通过窗体打开类型载入会员类型
        /// </summary>
        /// <param name="v">窗体打开类型 1--新增 2--修改</param>
        private void LoadMemberTypeByTemp(int v)
        {
            //获取所有的会员类型信息，并添加到cmb控件中
            MemberTypeBLL bll = new MemberTypeBLL();
            List<MemberType> list = new List<MemberType>();
            list = bll.GetAllMemberTypeByDelFlag(0);
            if (v == 1)//新增
            {
                list.Insert(0, new MemberType() { MemTpName = "请选择", MemType = -1 });
            }
            cmbMemType.DataSource = list;//绑定到cmb控件上
            cmbMemType.DisplayMember = "MemTpName";
            cmbMemType.ValueMember = "MemType";
            if (v == 2)//修改
            {
                //通过会员信息获取会员类型
                //string memTP = bll.GetAllMemberTypeNameByMemType(this.MemType);
               // cmbMemType.SelectedIndex = this.MemType;
                cmbMemType.SelectedValue = this.MemType;
            }
        }
    }
}
