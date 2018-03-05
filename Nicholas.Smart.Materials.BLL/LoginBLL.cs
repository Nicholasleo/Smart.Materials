using Nicholas.Smart.Materials.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.Smart.Materials.Enity;

namespace Nicholas.Smart.Materials.BLL
{
    public class LoginBLL
    {
        private readonly LoginDAL _dal = new LoginDAL();

        public ResultMessage CheckLogin(string usercode, string password)
        {
            return _dal.CheckLogin(usercode, password);
        }

    }
}
