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
    public partial class FrmBalance : Form
    {
        public FrmBalance()
        {
            InitializeComponent();
        }

        private int deskId { set; get; }//餐桌的ID
        //窗体传值方法
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            DeskInfo dk = mea.Obj as DeskInfo;
            this.deskId = dk.DeskId;
            //餐桌编号
            labDeskName.Text = dk.DeskName;
            //根据餐桌的ID查找该餐桌正在使用的订单
            //获取订单ID
            OrderInfoBLL obll = new OrderInfoBLL();
            int orderId = obll.GetOrderIdByDeskId(dk.DeskId);
            labOrderId.Text = orderId.ToString();//订单ID
            //消费总金额
            decimal Money = obll.GetMoneyByOrderId(orderId);
            labMoney.Text = Money.ToString();
            lblMoney.Text = Money.ToString();

        }
        //窗体加载
        private void FrmBalance_Load(object sender, EventArgs e)
        {
            //加载所有的会员
            LoadMemberInfoByDelFlag(0);
            //加载该订单所点的所有菜品
            LoadProduct(Convert.ToInt32(labOrderId.Text));
        }

        //加载该订单所点的所有菜品
        private void LoadProduct(int v)
        {
            R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
            dgvAllPro.AutoGenerateColumns = false;
            dgvAllPro.DataSource = bll.GetROrderInfoProduct(Convert.ToInt32(labOrderId.Text));
            if (dgvAllPro.SelectedRows.Count > 0)
            {
                dgvAllPro.SelectedRows[0].Selected = false;
            }
        }

        //加载所有的会员
        private void LoadMemberInfoByDelFlag(int v)
        {
            MemberInfoBLL bll = new MemberInfoBLL();
            List<MemberInfo> list = bll.GetAllMemberInfoByDelFlag(v);
            list.Insert(0, new MemberInfo() { MemberId = -1, MemName = "请选择" });
            cmbMemmber.DataSource = list;
            cmbMemmber.DisplayMember = "MemName";
            cmbMemmber.ValueMember = "MemberId";
        }

        private void cmbMemmber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMemmber.SelectedIndex != 0)
            {
                MemberInfoBLL bll = new MemberInfoBLL();
                MemberInfo mem = cmbMemmber.SelectedItem as MemberInfo;
                labTp.Text = bll.GetMemberTypeNameByMemberId(mem.MemberId);//会员级别
                labyeMoney.Text = mem.MemMoney.ToString();
                lblDis.Text = mem.MemDiscount.ToString();
                lblMoney.Text = (Convert.ToDecimal(labMoney.Text) * mem.MemDiscount / 10).ToString();
            }
            else
            {
                labTp.Text = "";
                labyeMoney.Text = "";
                lblDis.Text = "";
                lblMoney.Text = labMoney.Text;
            }
        }

        //开始结算
        private void btnAccounts_Click(object sender, EventArgs e)
        {
           
            OrderInfo order = new OrderInfo();
            order.EndTime = System.DateTime.Now;
            order.OrderId = Convert.ToInt32(labOrderId.Text);
            //会员的余额改变
            if (cmbMemmber.SelectedIndex != 0)//是会员
            {
                MemberInfo mem = cmbMemmber.SelectedItem as MemberInfo;
                order.OrderMemId = mem.MemberId;//会员ID
                order.DisCount = mem.MemDiscount;//会员折扣
                //会员的余额
                decimal money = Convert.ToDecimal(mem.MemMoney) - Convert.ToDecimal(lblMoney.Text);

                if (money >= 0)//判断钱数
                {
                    //余额充足
                    order.OrderMoney = money;
                    //更新会员卡内的钱
                    MemberInfoBLL mbll = new MemberInfoBLL();
                    bool memFlag = mbll.UpdateMoneyByMemIdAndMoney(mem.MemberId, money);
                }
                else
                {
                    //余额不足，需要补充money*-1元钱
                    //余额为零
                    order.OrderMoney = 0;
                    //更新会员卡内的钱
                    MemberInfoBLL mbll = new MemberInfoBLL();
                    bool memFlag = mbll.UpdateMoneyByMemIdAndMoney(mem.MemberId, money);
                    MessageBox.Show("会员卡余额不足，您还需要支付" + (money * (-1)).ToString() + "元！请知悉！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else//不是会员
            {
                if (string.IsNullOrEmpty(txtMoney.Text))
                {
                    MessageBox.Show("请输入付款金额！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToDecimal(txtMoney.Text) < Convert.ToDecimal(lblMoney.Text))
                {
                    MessageBox.Show("付款金额不足请确认！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                order.OrderMoney = Convert.ToDecimal(lblMoney.Text);
            }

            //订单的状态改变
            OrderInfoBLL obll = new OrderInfoBLL();
            bool orderFlag = obll.UpdateOrderInfoMoney(order);
            //餐桌状态改变
            DeskInfoBLL dkbll = new DeskInfoBLL();
            bool dkFlag = dkbll.UpdateDeskStateByDeskId(this.deskId, 0);
            if (dkFlag && orderFlag)
            {
                MessageBox.Show("结账成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("结账失败，请稍后重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        //获取找零金额
        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtMoney.Text) >= Convert.ToDecimal(lblMoney.Text))
            {
                lblSpareMoney.Text = (Convert.ToDecimal(txtMoney.Text) - Convert.ToDecimal(lblMoney.Text)).ToString();
            }

        }
    }
}
