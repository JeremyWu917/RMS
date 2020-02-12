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
    public partial class FrmMemberInfo : Form
    {
        public FrmMemberInfo()
        {
            InitializeComponent();
        }
        //多次调用该类，防止代码冗余
        MemberInfoBLL memberInfoBLL = new MemberInfoBLL();

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMemberInfo_Load(object sender, EventArgs e)
        {
            //刷新会员信息
            LoadMemberInfoByDelFlag(0);
            //加载下拉框
            cboDelFlag.Items.Clear();
            cboDelFlag.Items.Add("请选择");
            cboDelFlag.Items.Add("回收站");
            cboDelFlag.SelectedIndex = 0;
        }

        /// <summary>
        /// 加载所有的会员
        /// </summary>
        /// <param name="v">删除标识0</param>
        private void LoadMemberInfoByDelFlag(int v)
        {

            //禁止自动生成列
            dgvMember.AutoGenerateColumns = false;
            dgvMember.DataSource = memberInfoBLL.GetAllMemberInfoByDelFlag(v);
            //禁止默认第一行选中
            if (dgvMember.SelectedRows.Count > 0)
            {
                dgvMember.SelectedRows[0].Selected = false;
            }
            
        }

        //删除会员--更新删除标识
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //判断有没有选中
            if (dgvMember.SelectedRows.Count > 0)
            {

                int id = Convert.ToInt32(dgvMember.SelectedRows[0].Cells[0].Value.ToString());
                if (memberInfoBLL.UpdataMemberInfoById(id))
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //刷新界面
                    LoadMemberInfoByDelFlag(0);
                }
            }
            else
            {
                MessageBox.Show("您尚未选中要删除的行，请确认！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }

        //定义事件 用于窗体传值
        public event EventHandler evtMember;
        //标识 1--新增 2--修改
        //新增会员
        private void btnAppend_Click(object sender, EventArgs e)
        {
            ShowFrmUpdateMemberInfo(1);
        }

        //修改会员
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //判断是否选中
            if (dgvMember.SelectedRows.Count > 0)
            {
                //获取选中行的id
                int id = Convert.ToInt32(dgvMember.SelectedRows[0].Cells[0].Value.ToString());
                //根据id去数据库查询
                //获取会员对象信息
                mea.Obj = memberInfoBLL.GetMemberInfoByMemberId(id);
                ShowFrmUpdateMemberInfo(2);
            }
            else
            {
                MessageBox.Show("您未选中，请确认！");
            }
        }
        //用来传值的
        MyEventArgs mea = new MyEventArgs();

        public void ShowFrmUpdateMemberInfo(int v)
        {
            FrmChangeMemberInfo frmUpdateMemberInfo = new FrmChangeMemberInfo();

            this.evtMember += new EventHandler(frmUpdateMemberInfo.SetText);
            mea.Temp = v;
            if (this.evtMember != null)
            {
                this.evtMember(this, mea);
                //关闭刷新
                frmUpdateMemberInfo.FormClosed += new FormClosedEventHandler(FrmUpdateMemberInfo_FormClosed);
                frmUpdateMemberInfo.ShowDialog();
            }
        }

        //刷新窗体
        private void FrmUpdateMemberInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadMemberInfoByDelFlag(0);
        }

        //根据会员名称或者会员编号来查询会员信息
        private void btnView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMebID.Text))
            {
                MessageBox.Show("请输入会员名称或者会员ID");
            }
            else
            {
                dgvMember.AutoGenerateColumns = false;
                dgvMember.DataSource = memberInfoBLL.GetMemberInfoByMemNum(txtMebID.Text);
                if (dgvMember.SelectedRows.Count > 0)
                {
                    dgvMember.SelectedRows[0].Selected = false;
                }
            }
        }

        //下拉框内容改变时触发
        private void cboDelFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboDelFlag.SelectedIndex;
            if (index == 0)//请选择
            {
                LoadMemberInfoByDelFlag(0);
            }
            else if (index == 1)//回收站
            {
                LoadMemberInfoByDelFlag(1);
            }
        }

        //内容改变时触发查询功能
        private void txtMebID_TextChanged(object sender, EventArgs e)
        {
            if (txtMebID.Text != "")
            {
                dgvMember.AutoGenerateColumns = false;
                dgvMember.DataSource = memberInfoBLL.GetLikeMemberInfoByMemNum(txtMebID.Text);
                if (dgvMember.SelectedRows.Count > 0)
                {
                    dgvMember.SelectedRows[0].Cells[0].Selected = false;
                }
            }
            else
            {
                LoadMemberInfoByDelFlag(0);
            }
        }
    }
}
