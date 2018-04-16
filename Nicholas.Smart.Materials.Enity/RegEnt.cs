using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.Smart.Materials
{
    public class RegEnt
    {
    }

    public class MaterialsData
    {
        public string Type { get; set; }
        public string Area { get; set; }
        public string Path { get; set; }
        public string Depth { get; set; }
    }

    public class SystemRegInfo
    {
        public string IsAuthorized { get; set; }
        public string RegKey { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class MaterialsNode
    {
        /// <summary>
        /// 根节点
        /// </summary>
        public string RNode { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public string PNode { get; set; }
        /// <summary>
        /// 父节点属性名
        /// </summary>
        public string PNodeAttr { get; set; }
        /// <summary>
        /// 父节点属性值
        /// </summary>
        public string PNodeValue { get; set; }
        /// <summary>
        /// 父节点属性值
        /// </summary>
        public string PNodeNewValue { get; set; }

        /// <summary>
        ///子节点
        /// </summary>
        public string[] CNode { get; set; }

        public string[] CNodeAttr { get; set; }

        public string[] CNodeValue { get; set; }
    }
}
