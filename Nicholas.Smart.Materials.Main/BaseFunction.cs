using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nicholas.Smart.Materials.Business;
using Nicholas.Smart.Materials.Enity;

namespace Nicholas.Smart.Materials.Main
{
    public class BaseFunction
    {
        public static int Deviation1 = 100;
        public static int Deviation2 = 100;
        public static int Deviation3 = 100;
        public static int Area = 1000;
        public static int MinArea = 600;

        public static SystemConfigXml systemConfigXml = new SystemConfigXml();

        public static void GetConfig()
        {
            string deviation = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Deviation1", "");
            if (!string.IsNullOrEmpty(deviation))
            {
                int.TryParse(deviation, out Deviation1);
            }
            deviation = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Deviation2", "");
            if (!string.IsNullOrEmpty(deviation))
            {
                int.TryParse(deviation, out Deviation2);
            }
            deviation = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Deviation3", "");
            if (!string.IsNullOrEmpty(deviation))
            {
                int.TryParse(deviation, out Deviation3);
            }
            string width = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Width", "");
            if (!string.IsNullOrEmpty(width))
            {
                int.TryParse(width, out Area);
            }
        }
    }
}
