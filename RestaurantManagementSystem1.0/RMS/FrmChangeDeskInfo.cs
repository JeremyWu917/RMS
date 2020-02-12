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
    public partial class FrmChangeDeskInfo : Form
    {
        public FrmChangeDeskInfo()
        {
            InitializeComponent();
        }
        private int TP { get; set; }//存标识 1--新增 2--修改
        private int DeskId { get; set; }//餐桌ID
        //窗体载入时，刷新cmb控件值
        public void LoadRoom()
        {
            //载入房间
            RoomInfoBLL bll = new RoomInfoBLL();
            List<RoomInfo> list = bll.GetAllRoomInfoByDelFlag(0);
            list.Insert(0, new RoomInfo() { RoomId = -1, RoomName = "请选择" });
            cmbRoom.DataSource = list;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomId";
        }

        //窗体传值
        public void SetText(object sender, EventArgs e)
        {
            LoadRoom();
            //清空所有文本框
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tb = new TextBox();
                    tb.Text = "";
                }
            }
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;
            if (this.TP == 2)//修改
            {
                DeskInfo d = mea.Obj as DeskInfo;
                //餐桌ID
                this.DeskId = d.DeskId;
                txtDeskName.Text = d.DeskName;
                txtDeskRegion.Text = d.DeskRegion;
                txtDeskRemark.Text = d.DeskRemark;
                cmbRoom.SelectedValue = d.RoomId;
            }
            else
            {
                //刷新cmb控件
                LoadRoom();
            }
        }

        //保存修改
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsEmpty())
            {
                if (cmbRoom.SelectedIndex == 0)
                {
                    MessageBox.Show("请选择房间类型！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DeskInfo d = new DeskInfo();
                d.DeskName = txtDeskName.Text;
                d.DeskRegion = txtDeskRegion.Text;
                d.DeskRemark = txtDeskRemark.Text;
                d.RoomId = Convert.ToInt32(cmbRoom.SelectedValue);
                if (this.TP == 1)//新增
                {
                    d.DelFlag = 0;
                    d.DeskState = 0;
                    d.SubBy = 1;
                    d.SubTime = System.DateTime.Now;
                }
                else if (this.TP == 2)//修改
                {
                    d.DeskId = this.DeskId;
                }
                DeskInfoBLL dbll = new DeskInfoBLL();
                if (dbll.SaveDeskInfoByTemp(d, this.TP))
                {
                    MessageBox.Show("保存成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败，请稍后重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //检测文本框是否为空
        private bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txtDeskName.Text))
            {
                MessageBox.Show("餐桌名称不能为空，请确认！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtDeskRegion.Text))
            {
                MessageBox.Show("餐桌描述信息不能为空，请确认！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtDeskRemark.Text))
            {
                MessageBox.Show("餐桌备注信息不能为空，请确认！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

    }
}
