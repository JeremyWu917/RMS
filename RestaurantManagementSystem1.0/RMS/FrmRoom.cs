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
    public partial class FrmRoom : Form
    {
        public FrmRoom()
        {
            InitializeComponent();
        }

        //窗体载入时
        private void FrmRoom_Load(object sender, EventArgs e)
        {
            //显示所有的房间
            LoadRoomInfoByDelFlag(0);

            //显示所有的餐桌
            LoadDeskInfoByDelFlag(0);

        }
        //显示所有的餐桌
        private void LoadDeskInfoByDelFlag(int v)
        {
            DeskInfoBLL dBll = new DeskInfoBLL();
            dgvDeskInfo.AutoGenerateColumns = false;
            dgvDeskInfo.DataSource = dBll.GetAllDeskInfoByDelFlag(0);
            if (dgvDeskInfo.SelectedRows.Count > 0)
            {
                dgvDeskInfo.SelectedRows[0].Selected = false;
            }
        }
        //显示所有的房间
        private void LoadRoomInfoByDelFlag(int v)
        {
            RoomInfoBLL rBll = new RoomInfoBLL();
            dgvRoomInfo.AutoGenerateColumns = false;
            dgvRoomInfo.DataSource = rBll.GetAllRoomInfoByDelFlag(0);
            if (dgvRoomInfo.SelectedRows.Count > 0)
            {
                dgvRoomInfo.SelectedRows[0].Selected = false;
            }
        }

        private int ROOMID { set; get; }//房间ID
        //删除房间
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            //判断有没有选中
            if (dgvRoomInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中要删除的房间！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //判断该房间下有没有餐桌
            ROOMID = Convert.ToInt32(dgvRoomInfo.SelectedRows[0].Cells[0].Value);//房间ID
            DeskInfoBLL dbll = new DeskInfoBLL();
            if (dbll.GetDeskCountByRoomId(ROOMID))
            {
                MessageBox.Show("该房间下有餐桌，禁止删除！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //友好提示
            if (DialogResult.OK == MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                RoomInfoBLL rbll = new RoomInfoBLL();
                if (rbll.SoftDeleteRoomInfoByRoomId(ROOMID))
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRoomInfoByDelFlag(0);
                }
                else
                {
                    MessageBox.Show("删除失败，请稍后重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //删除餐桌
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //判断有没有选中
            if (dgvDeskInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中要删除的餐桌！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //判断餐桌的当前状态
            if (dgvDeskInfo.SelectedRows[0].Cells[3].Value.ToString() != "空闲")
            {
                MessageBox.Show("餐桌正在使用中，禁止删除！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //友好提示
            if (DialogResult.OK == MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                int deskId = Convert.ToInt32(dgvDeskInfo.SelectedRows[0].Cells[0].Value);
                DeskInfoBLL dbll = new DeskInfoBLL();
                if (dbll.SoftDeleteDeskInfoByDeskId(deskId))
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDeskInfoByDelFlag(0);
                }
                else
                {
                    MessageBox.Show("删除失败，请稍后重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        public event EventHandler evtFcd;//声明一个事件用于窗体传值
        public MyEventArgs meaFcd = new MyEventArgs();
        //修改餐桌
        private void btnUpdateDesk_Click(object sender, EventArgs e)
        {
            //判断有没有选中
            if (dgvDeskInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中要删除的餐桌！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //判断餐桌的当前状态
            if (dgvDeskInfo.SelectedRows[0].Cells[3].Value.ToString() != "空闲")
            {
                MessageBox.Show("餐桌正在使用中，禁止修改！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int deskId = Convert.ToInt32(dgvDeskInfo.SelectedRows[0].Cells[0].Value);
            DeskInfoBLL dBll = new DeskInfoBLL();
            meaFcd.Obj = dBll.GetDeskInfoByDeskId(deskId);
            UpdateDeskInfoByFlag(2);
        }
        /// <summary>
        /// 管理餐桌信息
        /// </summary>
        /// <param name="v">2--修改 1--新增</param>
        private void UpdateDeskInfoByFlag(int v)
        {
            FrmChangeDeskInfo fcd = new FrmChangeDeskInfo();
            meaFcd.Temp = v;
            //注册事件
            this.evtFcd += new EventHandler(fcd.SetText);
            if (this.evtFcd != null)
            {
                this.evtFcd(this, meaFcd);    
            }
            fcd.FormClosed += new FormClosedEventHandler(Fcd_FormClosed);
            fcd.ShowDialog();
        }

        //餐桌管理窗体关闭后执行的事件
        private void Fcd_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDeskInfoByDelFlag(0);
        }
        //添加餐桌
        private void btnAddDesk_Click(object sender, EventArgs e)
        {
            UpdateDeskInfoByFlag(1);
        }

        //声明全局变量事件用于窗体传值
        public event EventHandler evtRoom;
        public MyEventArgs meaRoom = new MyEventArgs();

        //增加房间
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            UpdateRoomInfoByFlag(3);
        }
        //修改房间
        private void button2_Click(object sender, EventArgs e)
        {
            //判断有没有选中
            if (dgvRoomInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中要删除的房间！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //判断该房间下有没有餐桌
            ROOMID = Convert.ToInt32(dgvRoomInfo.SelectedRows[0].Cells[0].Value);//房间ID
            //DeskInfoBLL dbll = new DeskInfoBLL();
            //if (dbll.GetDeskCountByRoomId(ROOMID))
            //{
            //    MessageBox.Show("该房间下有餐桌，禁止修改！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //获取房间对象
            RoomInfo r = new RoomInfo();
            RoomInfoBLL rbll = new RoomInfoBLL();
            meaRoom.Obj = rbll.GetRoomInfoByRoomId(ROOMID);
            UpdateRoomInfoByFlag(4);
        }
        /// <summary>
        /// 根据标识更新房间信息
        /// </summary>
        /// <param name="v">3--增加 4--修改</param>
        private void UpdateRoomInfoByFlag(int v)
        {
            FrmChangeRoom fcr = new FrmChangeRoom();
            //存标识
            meaRoom.Temp = v;
            //注册事件
            this.evtRoom += new EventHandler(fcr.SetText);
            if (this.evtRoom != null)
            {
                evtRoom(this, meaRoom);   
            }
            fcr.FormClosed += new FormClosedEventHandler(Fcr_FormClosed);//注册窗体关闭事件
            fcr.ShowDialog();
        }

        //修改房间信息关闭时，刷新房间信息
        private void Fcr_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadRoomInfoByDelFlag(0);
        }

        //窗体关闭时刷新主界面房间和餐桌信息
        private void FrmRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain fr = new FrmMain();
            fr.RefreshingRoomInfoAndDeskInfo();
        }
    }
}
