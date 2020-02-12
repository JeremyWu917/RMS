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
    public partial class FrmChangeRoom : Form
    {
        public FrmChangeRoom()
        {
            InitializeComponent();
        }

        private int ROOMID { get; set; }//房间ID
        private int TP { get; set; }//操作类型
        //声明事件用于窗体传值
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            RoomInfo r = mea.Obj as RoomInfo;
            this.TP = mea.Temp;
            if (this.TP == 3)//增加
            {

            }
            else if (this.TP == 4)//修改
            {
                ROOMID = r.RoomId;
                txtIsDeflaut.Text = r.IsDefault.ToString();
                txtRMinMoney.Text = r.RoomMinimunConsume.ToString();
                txtRName.Text = r.RoomName;
                txtRType.Text = r.RoomType.ToString();
                txtRPerNum.Text = r.RoomMaxConsumer.ToString();
            }

        }
        //检测文本框是否为空
        public bool TextIsEmpty()
        {
            if (string.IsNullOrEmpty(txtIsDeflaut.Text))
            {
                MessageBox.Show("默认编号不能为空，请确认！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtRMinMoney.Text))
            {
                MessageBox.Show("最低消费不能为空，请确认！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtRName.Text))
            {
                MessageBox.Show("房间名字不能为空，请确认！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtRPerNum.Text))
            {
                MessageBox.Show("房间人数不能为空，请确认！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtRType.Text))
            {
                MessageBox.Show("房间类型不能为空，请确认！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        //保存修改
        private void btnOk_Click(object sender, EventArgs e)
        {
            //判断文本框是否为空
            if (TextIsEmpty())
            {
                RoomInfo r = new RoomInfo();
                
                r.RoomMaxConsumer = Convert.ToInt32(txtRPerNum.Text);
                r.RoomMinimunConsume = Convert.ToDecimal(txtRMinMoney.Text);
                r.RoomName = txtRName.Text;
                r.RoomType = Convert.ToInt32(txtRType.Text);
                r.IsDefault = Convert.ToInt32(txtIsDeflaut.Text);
                if (this.TP == 3)//增加
                {
                    //r.DelFlag = 0;
                    //r.SubBy = 1;
                    r.SubTime = System.DateTime.Now;

                }
                else if (this.TP == 4)//修改
                {
                    r.RoomId = this.ROOMID;
                }
                RoomInfoBLL bll = new RoomInfoBLL();
                if (bll.SaveRoomInfo(r, this.TP))
                {
                    MessageBox.Show("保存成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败，请稍后重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
