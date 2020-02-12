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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        private int ID { get; set; }//餐桌ID
        //为窗体的所有的文本框赋值
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            DeskInfo dk = mea.Obj as DeskInfo;//获取DeskInfo对象
            labDeskName.Text = dk.DeskName;//房间名
            labRoomType.Text = mea.Name;//房间类型
            labLittleMoney.Text = mea.Money.ToString();//最低消费

            //餐桌的ID
            this.ID = dk.DeskId;
        }


        public event EventHandler evtFrmMoney;//声明一个事件用于窗体传值
        //确定开单了
        private void btnOK_Click(object sender, EventArgs e)
        {
            //更改餐桌的状态
            DeskInfoBLL dkBll = new DeskInfoBLL();
            bool dkFlag = dkBll.UpdateDeskStateByDeskId(this.ID, 1);

            //添加一个订单
            OrderInfoBLL orBll = new OrderInfoBLL();
            OrderInfo o = new OrderInfo();
            o.SubTime = System.DateTime.Now;//当前时间
            o.DelFlag = 0;
            o.OrderMoney = 0;//初次订单的钱
            o.OrderState = 1;//状态
            o.Remark = txtPersonCount.Text + txtDescription.Text;
            o.SubBy = 1;
            //o.SubTime = System.DateTime.Now;//当前时间

            int orderId = orBll.AddOrderInfo(o);

            //添加中间表的数据
            R_Order_DeskBLL rodBll = new R_Order_DeskBLL();
            R_Order_Desk rod = new R_Order_Desk();
            rod.DeskId = this.ID;
            rod.OrderId = orderId;
            bool rodFlag = rodBll.AddROrderDesk(rod);

            if (dkFlag && rodFlag)
            {
                MessageBox.Show("开单成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //选中立即增加菜单
                if (ckbMeal.Checked)
                {
                    MyEventArgs mea = new MyEventArgs();
                    mea.Name = labDeskName.Text;//餐桌的编号
                    mea.Temp = orderId;//订单ID
                    //窗体传值
                    FrmAddMoney fam = new FrmAddMoney();
                    this.evtFrmMoney += new EventHandler(fam.SetText);
                    if (this.evtFrmMoney != null)
                    {
                        this.evtFrmMoney(this, mea);
                        fam.FormClosed += new FormClosedEventHandler(Fam_FormClosed);
                        fam.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("开单失败！请重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Fam_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();//增加菜品窗体关闭时，开单窗体也一起关闭
        }
    }
}
