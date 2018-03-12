using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.Tutorials.Properties;

namespace Nicholas.Smart.Materials.Main
{
    public class ControlFunction
    {
        #region 取默认图片
        /// <summary>
        /// 按图片和路径获得图片
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Bitmap GetFileImage(string path, string filename)
        {
            Bitmap bitmap = null;
            try
            {

                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    if (file.Contains(filename))
                    {
                        // filename = file;
                        bitmap = (Bitmap)Bitmap.FromFile(file);
                        break;
                    }
                }
                if (bitmap == null)
                {
                    bitmap = (Bitmap)Resources.ResourceManager.GetObject(filename);
                }
            }
            catch (Exception)
            {
                bitmap = (Bitmap)Resources.ResourceManager.GetObject(filename);
            }
            return bitmap;
        }

        public static Image GetFileImage(string path)
        {
            Image bitmap = null;
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
                bitmap = System.Drawing.Image.FromStream(fs);

                fs.Close();
            }
            catch (Exception)
            {
            }
            return bitmap;
        }

        #endregion
    }
}
