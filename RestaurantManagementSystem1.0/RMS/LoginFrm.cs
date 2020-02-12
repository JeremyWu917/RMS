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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        //退出系统
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //判断用户是否成功
            if (CheckText())
            {
                string msg = "";
                //判断登录是否成功
                UserInfoBLL userInfoBLL = new UserInfoBLL();
                string psd = Common.GetStringMD5(this.txtPassCode.Text);
                if (userInfoBLL.IsLoginByLoginName(this.txtUserName.Text, psd, out msg))
                {
                    //登陆成功
                    //设置当前的登录窗口的值
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    //登录失败
                    MessageBox.Show("登录失败：" + msg);
                }

            }
        }

        /// <summary>
        /// 判断用户名或者密码是否为空
        /// </summary>
        /// <returns>【false：为空】【true：不为空】</returns>
        private bool CheckText()
        {
            if (string.IsNullOrEmpty(this.txtUserName.Text))
            {
                this.txtUserName.Focus();
                MessageBox.Show("账户不能为空，请确认！");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtPassCode.Text))
            {
                this.txtPassCode.Focus();
                MessageBox.Show("密码不能为空，请确认！");
                return false;
            }
            return true;
        }

    }
}
