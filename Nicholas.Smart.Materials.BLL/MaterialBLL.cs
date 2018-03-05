using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nicholas.Smart.Materials.DAL;

namespace Nicholas.Smart.Materials.BLL
{
    public class MaterialBLL
    {
        private MaterialDAL dal = new MaterialDAL();

        public DataTable GetAllMaterial(string usercode)
        {
            return dal.GetAllMaterial(usercode);
        }
    }
}
