using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WA_Test_V5.Interface.TreeView;
using WA_Test_V5.Models;

namespace WA_Test_V5.Helper
{
    public static class TreeViewHelper
    {
        public static List<TreeViewElements> Convert(this List<InDateRow> data)
        {
            var nodes = new HashSet<NodeModel>();
            data.ForEach(it => AddLine(nodes, it));

            var elements = new List<TreeViewElements>();
            int id = 0;
            int parentId = 0;

            foreach (var node in nodes.OrderBy(n => n.Name))
            {
                elements.Add(node, ref id, parentId);
            }

            return elements;
        }

        private static List<TreeViewElements> Add(this List<TreeViewElements> elements, NodeModel node, ref int id, int parentId)
        {
            int nodeId = ++id;

            elements.Add(new TreeViewElements()
            {
                Parent_ID = parentId.ToString(),
                ID = nodeId.ToString(),
                Name = node.Name,
                CID = node.CID
            });

            foreach (var item in node.Children.OrderBy(n => n.Name))
            {
                elements.Add(item, ref id, nodeId);
            }

            return elements;
        }

        private static void AddLine(HashSet<NodeModel> nodes, InDateRow row)
        {
            var exportProps = typeof(InDateRow)
               .GetProperties()
               .Select(p => new
               {
                   Prop = p,
                   Attr = p.GetCustomAttribute<TreeViewAttribute>()
               })
               .Where(x => x.Attr != null)
               .OrderBy(x => x.Attr.Level)
               .ToList();

            NodeModel parent = null;

            foreach (var prop in exportProps)
            {
                var node = new NodeModel()
                {
                    Level = prop.Attr.Level,
                    Name = prop.Prop.GetValue(row).ToString(),
                    CID = prop.Attr.Level == 9 ? row.CID : -2
                };

                if (parent == null)
                {
                    if (!nodes.Contains(node))
                    {
                        nodes.Add(node);
                        parent = node;
                    }
                    else
                    {
                        parent = nodes.FirstOrDefault(el => el.Equals(node));
                    }
                }
                else
                {
                    if (!parent.Children.Contains(node))
                    {
                        node.Parent = parent;
                        parent.Children.Add(node);
                        parent = node;
                    }
                    else
                    {
                        parent = parent.Children.FirstOrDefault(el => el.Equals(node));
                    }
                }
            }
        }
    }
}