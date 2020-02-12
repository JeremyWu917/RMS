using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.DAL;
using RMS.Model;

namespace RMS.BLL
{
    public class R_Order_DeskBLL
    {
        R_Order_DeskDAL dal = new R_Order_DeskDAL();

        /// <summary>
        /// 添加一条中间表数据
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        public bool AddROrderDesk(R_Order_Desk rod)
        {
            return dal.AddROrderDesk(rod) > 0;
        }

    }
}
