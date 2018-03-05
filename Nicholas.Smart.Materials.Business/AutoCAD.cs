using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

namespace Nicholas.Smart.Materials
{
    public class AutoCAD
    {
        [CommandMethod("GetLayerPro")]
        public static void GetLayerPro(string filename)
        {
            Autodesk.AutoCAD.EditorInput ed = Application.DocumentManager.MdiActiveDocument.EditorInput;
            //新建 一个数据库对象以读取DWG文件
            Database db = new Database(false,true);
            db.ReadDwgFile(filename,FileShare.Read,true,null);
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //获取图层表对象
                LayerTable layer = (LayerTable) trans.GetObject(db.LayerTableId, OpenMode.ForRead);
                //遍历图层
                foreach (ObjectId layerId in layer)
                {
                    LayerTableRecord ltr = (LayerTableRecord)trans.GetObject(layerId, OpenMode.ForRead);
                }
                trans.Commit();
            }
        }
    }
}
