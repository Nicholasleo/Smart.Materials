using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.Smart.Materials.Enity
{
    public class SystemConfigXml
    {

        public string ConfigPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "SystemConfig.xml";
            }
        }

        public int Deviation { get; set; }
        public int With { get; set; }
    }
}
