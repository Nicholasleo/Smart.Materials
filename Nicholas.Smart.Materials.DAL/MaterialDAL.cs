using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nicholas.Smart.Materials.DAL
{
    /// <summary>
    /// 材料管理数据
    /// </summary>
    public class MaterialDAL
    {
        private DbHelperACE dbHelper = new DbHelperACE();
        public DataTable GetAllMaterial(string usercode)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Format("SELECT * FROM T_base_material WHERE Creator='admin' OR Creator='{0}'",
                    usercode);
                dt = dbHelper.SelectToDataTable(sql);
                return dt;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}
