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
    public partial class FrmCategoryInfo : Form
    {
        public FrmCategoryInfo()
        {
            InitializeComponent();
        }

        private void FrmCategoryInfo_Load(object sender, EventArgs e)
        {
            //加载所有的商品类别
            LoadCategoryInfoByDelFlag(0);
            //加载所有的产品信息
            LoadProductInfoByDelFlag(0);
            //窗体加载显示所有的类别
            LoadCategoryInfoByDelFlagToCmb(0);
        }

        //绑定商品类别下拉框
        private void LoadCategoryInfoByDelFlagToCmb(int v)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = bll.GetAllCategoryInfoByDelFlag(v);
            list.Insert(0, new CategoryInfo() { CatId = -1, CatName = "请选择" });
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "CatName";
            cmbCategory.ValueMember = "CatId";
        }

        /// <summary>
        /// 自动刷新产品信息
        /// </summary>
        /// <param name="v">删除标识</param>
        private void LoadProductInfoByDelFlag(int v)
        {
            ProductInfoBLL bll = new ProductInfoBLL();
            dgvProductInfo.AutoGenerateColumns = false;
            dgvProductInfo.DataSource = bll.GetAllProductInfoByDelFlag(v);
            if (dgvCategoryInfo.SelectedRows.Count > 0)
            {
                dgvProductInfo.SelectedRows[0].Selected = false;//先判断是否存在第一行，否则有异常
            }
        }

        /// <summary>
        /// 自动刷新商品类别
        /// </summary>
        /// <param name="v">删除标识</param>
        private void LoadCategoryInfoByDelFlag(int v)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            dgvCategoryInfo.AutoGenerateColumns = false;
            dgvCategoryInfo.DataSource = bll.GetAllCategoryInfoByDelFlag(v);
            if (dgvCategoryInfo.SelectedRows.Count > 0)
            {
                dgvCategoryInfo.SelectedRows[0].Selected = false;
            }    
        }


        //添加商品类别
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            LoadFrmChangeCategory(1);
        }

        //修改商品类别
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategoryInfo.SelectedRows.Count > 0)
            {
                //选中行后获取ID
                int id = Convert.ToInt32(dgvCategoryInfo.SelectedRows[0].Cells[0].Value);

                //根据ID获取对象
                CategoryInfoBLL categoryInfoBLL = new CategoryInfoBLL();
                CategoryInfo ct = categoryInfoBLL.GetCategoryInfoById(id);

                if (ct != null)
                {
                    mea.Obj = ct;
                    //修改
                    LoadFrmChangeCategory(2);
                }
            }
            else
            {
                MessageBox.Show("请先选中要修改的行！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }

        public event EventHandler evtFcc;//声明一个事件用于窗体传值
        MyEventArgs mea = new MyEventArgs();//用于窗体之间传值/对象
        /// <summary>
        /// 显示新增或者修改的类别窗体
        /// </summary>
        /// <param name="v">标识 1--新增 2--修改</param>
        private void LoadFrmChangeCategory(int v)
        {
            FrmChangeCategory frmChangeCategory = new FrmChangeCategory();
            this.evtFcc += new EventHandler(frmChangeCategory.SetText);//注册事件
            mea.Temp = v;//存标识
            if (this.evtFcc != null)
            {
                this.evtFcc(this, mea);
                //窗体关闭时刷新
                frmChangeCategory.FormClosed += new FormClosedEventHandler(FrmChangeCategory_FormClosed);
                frmChangeCategory.ShowDialog();
            }
        }

        //刷新
        //新增或修改窗体之后调用的方法
        private void FrmChangeCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
        }

        //删除商品类别
        private void benDeleteCategory_Click(object sender, EventArgs e)
        {
            //判断有没有选中
            if (dgvCategoryInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中想要删除的类别！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //获取CatId
            int catId = Convert.ToInt32(dgvCategoryInfo.SelectedRows[0].Cells[0].Value);
            //判断产品信息中有没有改类别的产品
            ProductInfoBLL pbll = new ProductInfoBLL();
            if (pbll.GetProductInfoCountByCatId(catId))
            {
                MessageBox.Show("产品信息中包含该类别的产品，如果想删除，请联系管理员！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //友好提问
            if (DialogResult.OK == MessageBox.Show("删除后将无法恢复，您确定要删除吗？", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                //删除产品类别
                CategoryInfoBLL cbll = new CategoryInfoBLL();
                if (cbll.SoftDeleteCategoryInfoByCatId(catId))
                {
                    MessageBox.Show("删除成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除失败，请重试！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                LoadCategoryInfoByDelFlag(0);
            }
        }

        //删除商品
        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中需要删除的行！");
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("您确定要删除吗？", "删除操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value);
                    ProductInfoBLL productInfoBLL = new ProductInfoBLL();
                    if (productInfoBLL.SoftDelteProductInfo(id))
                    {
                        MessageBox.Show("删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                    LoadProductInfoByDelFlag(0);//刷新
                }
            }


        }

        //添加商品信息
        private void btnAddPro_Click(object sender, EventArgs e)
        {
            ShowFrmChangeProductInfo(3);
        }
        //修改商品信息
        private void btnUpdatePro_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count > 0)
            {
                //获取id
                int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value);
                //根据id查询对象
                ProductInfoBLL bll = new ProductInfoBLL();
                ProductInfo pro = bll.GetProductInfoByProId(id);
                if (pro != null)
                {
                    meaFcp.Obj = pro;
                    ShowFrmChangeProductInfo(4);
                }
            }
            else
            {
                MessageBox.Show("请先选中要修改的行！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public MyEventArgs meaFcp = new MyEventArgs();//声明一个事件对象
        public event EventHandler evtFcp;//声明一个事件用于窗体传值
        /// <summary>
        /// 弹出窗体
        /// </summary>
        /// <param name="v">标识 3--新增 4--修改</param>
        private void ShowFrmChangeProductInfo(int v)
        {
            FrmChangeProductInfo fcp = new FrmChangeProductInfo();
            //注册事件
            this.evtFcp += new EventHandler(fcp.SetText);
            //存标识
            meaFcp.Temp = v;
            if (this.evtFcp != null)
            {
                this.evtFcp(this, meaFcp);
            }
            fcp.FormClosed += new FormClosedEventHandler(Fcp_FormClosed);
            fcp.ShowDialog();
        }

        //产品信息修改后的刷新
        private void Fcp_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadProductInfoByDelFlag(0);
        }

        //选则发生改变时
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex != 0)
            {
                int id = Convert.ToInt32(cmbCategory.SelectedValue);
                ProductInfoBLL bll = new ProductInfoBLL();
                dgvProductInfo.AutoGenerateColumns = false;
                dgvProductInfo.DataSource = bll.GetAllProductInfoByCatId(id);
                if (dgvProductInfo.SelectedRows.Count > 0)
                {
                    dgvProductInfo.SelectedRows[0].Selected = false;
                }
            }
            else
            {
                LoadProductInfoByDelFlag(0);
            }
        }

        //根据编号查找
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //获取编号
            string txt = txtSearch.Text;
            ProductInfoBLL bll = new ProductInfoBLL();
            dgvProductInfo.AutoGenerateColumns = false;
            dgvProductInfo.DataSource = bll.GetProductInfoByProNum(txt);
            if (dgvProductInfo.SelectedRows.Count > 0)
            {
                dgvProductInfo.SelectedRows[0].Selected = false;
            }
        }
    }
}
