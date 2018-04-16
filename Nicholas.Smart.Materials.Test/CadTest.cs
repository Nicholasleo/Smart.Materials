using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Exception = System.Exception;

namespace Nicholas.Smart.Materials.Test
{
    public class CadTest
    {
        public static string FileName = "D:\\Downloads\\对开门图纸.dwg";

        //[CommandMethod("GetLayerPro")]
        public static void GetLayerPro()
        {
            try
            {
                Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
                Database db = new Database(false, true);
                if (File.Exists(FileName))
                {
                    db.ReadDwgFile(FileName, FileShare.Read, true, null);
                    using (Transaction trans = db.TransactionManager.StartTransaction())
                    {
                        LayerTable lt = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
                        foreach (ObjectId layerId in lt)
                        {
                            LayerTableRecord ltr = (LayerTableRecord)trans.GetObject(layerId, OpenMode.ForRead);
                            if (ltr != null)
                            {
                                Autodesk.AutoCAD.Colors.Color layerColor = ltr.Color;
                                ed.WriteMessage("\n图层名称为：" + ltr.Name);
                                ed.WriteMessage("\n图层颜色为：" + layerColor.ToString());
                            }
                        }
                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
