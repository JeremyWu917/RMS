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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        //会员管理
        private void btnMember_Click(object sender, EventArgs e)
        {
            FrmMemberInfo frmMemberInfo = new FrmMemberInfo();
            frmMemberInfo.ShowDialog();
        }

        //商品管理
        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmCategoryInfo frmCategoryInfo = new FrmCategoryInfo();
            frmCategoryInfo.ShowDialog();
        }

        //刷新当前房间的餐桌信息
        public void RefreshingRoomInfoAndDeskInfo()
        {
            //加载房间
            LoadRoomInfoByDelFlag(0);
            //加载餐桌
            LoadDeskInfoByRoomIdAndTabPageIndex(tabC.TabPages[0]);
            //加载其他的房间的餐桌
            tabC.SelectedIndexChanged += new EventHandler(TabC_SelectedIndexChanged);
        }

        //主窗体加载时
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //加载房间
            LoadRoomInfoByDelFlag(0);
            //加载餐桌
            LoadDeskInfoByRoomIdAndTabPageIndex(tabC.TabPages[0]);
            //加载其他的房间的餐桌
            tabC.SelectedIndexChanged += new EventHandler(TabC_SelectedIndexChanged);
        }

        //加载其他的房间的餐桌
        private void TabC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeskInfoByRoomIdAndTabPageIndex(tabC.SelectedTab);
        }

        //加载餐桌
        private void LoadDeskInfoByRoomIdAndTabPageIndex(TabPage tp)
        {
            RoomInfo r = tp.Tag as RoomInfo;//获取房间对象
            ListView lv = tp.Controls[0] as ListView;//获取lv控件
            lv.Clear();//防止重复加载
            DeskInfoBLL dbll = new DeskInfoBLL();
            List<DeskInfo> listDesk = dbll.GetAllDeskInfoByRoomId(r.RoomId);//获取餐桌集合
            for (int i = 0; i < listDesk.Count; i++)
            {
                lv.Items.Add(listDesk[i].DeskName, listDesk[i].DeskState);//设定图片和名称
                lv.Items[i].Tag = listDesk[i];//把餐桌的对象存到tag属性中
            }
        }

        //加载所有的未删除的房间
        private void LoadRoomInfoByDelFlag(int v)
        {
            RoomInfoBLL rbll = new RoomInfoBLL();
            //获取所有的房间
            List<RoomInfo> listRoom = rbll.GetAllRoomInfoByDelFlag(v);
            for (int i = 0; i < listRoom.Count; i++)
            {
                TabPage tp = new TabPage();//创建一个页面选项卡
                tp.Text = listRoom[i].RoomName;//显示房间的名字
                tp.Tag = listRoom[i];//将房间对象存到tag属性中

                ListView lv = new ListView();//创建一个lv显示餐桌信息
                lv.LargeImageList = imageList1;//绑定图片
                lv.View = View.LargeIcon;//图片显示的方式
                lv.Dock = DockStyle.Fill;//设置图片填充方式
                lv.BackColor = Color.White;//设置背景颜色
                lv.MultiSelect = false;//禁止选中多个
                tp.Controls.Add(lv);//绑定图片到tp中

                tabC.TabPages.Add(tp);//将选项卡加载到TabPage中
            }
        }


        public event EventHandler evtFBI;//声明一个事件用于开单窗体传值
        //顾客开单
        private void btnBilling_Click(object sender, EventArgs e)
        {
            TabPage tp = tabC.SelectedTab;//获取选中页
            //tp.Tag 房间的对象
            ListView lv = tp.Controls[0] as ListView;
            //lv.SelectedItems[0];//选中的lv

            //判断是否选中
            if (lv.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请先选中餐桌号！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //判断餐桌状态
            if ((lv.SelectedItems[0].Tag as DeskInfo).DeskState != 0)
            {
                MessageBox.Show("餐桌已被占用，请确认！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MyEventArgs mea = new MyEventArgs();//用于窗体之间传值/对象
            mea.Obj = lv.SelectedItems[0].Tag;//餐桌对象

            //房间对象
            FrmBilling fbi = new FrmBilling();

            //房间的类型 房间的最低消费
            mea.Name = (tp.Tag as RoomInfo).RoomName;//房间的名字/类型
            mea.Money = Convert.ToDecimal((tp.Tag as RoomInfo).RoomMinimunConsume);//房间的最低消费

            this.evtFBI += new EventHandler(fbi.SetText);//注册事件 委托
            if (this.evtFBI != null)
            {
                this.evtFBI(this, mea);
                fbi.FormClosed += new FormClosedEventHandler(Fbi_FormClosed);//注册一个关闭事件
                fbi.ShowDialog();
            }
        }

        //开单窗体关闭后刷新
        private void Fbi_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDeskInfoByRoomIdAndTabPageIndex(tabC.SelectedTab);//依然显示当前房间
        }


        public event EventHandler evtFrmAddMoney; //注册一个事件用于窗体传值
        //增加消费
        private void btnAddMoney_Click(object sender, EventArgs e)
        {
            TabPage tp = tabC.SelectedTab;//获取选中页
            //tp.Tag 房间的对象
            ListView lv = tp.Controls[0] as ListView;
            //lv.SelectedItems[0];//选中的lv

            //判断是否选中
            if (lv.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请先选中餐桌号！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //判断餐桌状态
            if ((lv.SelectedItems[0].Tag as DeskInfo).DeskState != 1)
            {
                MessageBox.Show("请先选中空闲的餐桌！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //注册事件 
            FrmAddMoney fam = new FrmAddMoney();

            this.evtFrmAddMoney += new EventHandler(fam.SetText);
            MyEventArgs mea = new MyEventArgs();
            mea.Name = (lv.SelectedItems[0].Tag as DeskInfo).DeskName;//餐桌编号
            OrderInfoBLL bll = new OrderInfoBLL();
            mea.Temp = bll.GetOrderIdByDeskId((lv.SelectedItems[0].Tag as DeskInfo).DeskId);//订单ID
                                                                                            //窗体传值
            if (this.evtFrmAddMoney != null)
            {
                this.evtFrmAddMoney(this, mea);
                fam.FormClosed += new FormClosedEventHandler(Fbi_FormClosed);
                fam.ShowDialog();
            }
        }

        public event EventHandler evtFrmBalance;
        //结账
        private void btnBalance_Click(object sender, EventArgs e)
        {
            TabPage tp = tabC.SelectedTab;//获取选中页
            //tp.Tag 房间的对象
            ListView lv = tp.Controls[0] as ListView;
            //lv.SelectedItems[0];//选中的lv

            //判断是否选中
            if (lv.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请先选中需要结账的餐桌号！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //判断餐桌状态
            if ((lv.SelectedItems[0].Tag as DeskInfo).DeskState != 1)
            {
                MessageBox.Show("请先选中需要结账的餐桌号！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmBalance fb = new FrmBalance();
            this.evtFrmBalance += new EventHandler(fb.SetText);//注册事件
            MyEventArgs meaFB = new MyEventArgs();
            meaFB.Obj = lv.SelectedItems[0].Tag;//餐桌对象
            if (this.evtFrmBalance != null)
            {
                this.evtFrmBalance(this, meaFB);
                fb.FormClosed += new FormClosedEventHandler(Fb_FormClosed);
                fb.ShowDialog();
            }
        }

        //结账完成后刷新主界面餐桌信息
        private void Fb_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDeskInfoByRoomIdAndTabPageIndex(tabC.SelectedTab);
        }

        //房间餐桌设置
        private void btnRoom_Click(object sender, EventArgs e)
        {
            FrmRoom fr = new FrmRoom();
            fr.ShowDialog();
        }
    }
}
