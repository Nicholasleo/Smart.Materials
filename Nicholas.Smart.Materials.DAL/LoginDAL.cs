using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nicholas.Smart.Materials.Enity;

namespace Nicholas.Smart.Materials.DAL
{
    public class LoginDAL
    {
        private DbHelperACE dbHelper = new DbHelperACE();
        public ResultMessage CheckLogin(string usercode, string password)
        {
            var result = new ResultMessage();
            result.ResultFlg = false;
            DataTable dt = new DataTable();
            try
            {
                result.ResultMsg = @"登录失败";
                string sql = string.Format("SELECT * FROM T_Sys_UserInfo WHERE UserCode='{0}' AND Password = '{1}'",
                    usercode, password);
                dt = dbHelper.SelectToDataTable(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result.ResultFlg = true;
                    result.ResultMsg = @"登录成功";
                }
                else
                {
                    result.ResultFlg = false;
                    result.ResultMsg = @"登录失败，用户名或密码错误！";
                }
            }
            catch (Exception ex)
            {
                result.ResultMsg = @"登录失败，系统异常！" + ex.Message;
                //throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
