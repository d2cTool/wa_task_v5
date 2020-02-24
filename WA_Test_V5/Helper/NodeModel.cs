using System;
using System.Collections.Generic;

namespace WA_Test_V5.Helper
{
    public class NodeModel : IEquatable<NodeModel>
    {
        public int Level { get; set; }

        public string Name { get; set; }

        public NodeModel Parent { get; set; }

        public HashSet<NodeModel> Children { get; set; }

        public int CID { get; set; }

        public bool Equals(NodeModel other) => Level == other.Level && Name == other.Name && CID == other.CID;

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Level.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + CID.GetHashCode();
                return hash;
            }
        }

        public NodeModel()
        {
            Children = new HashSet<NodeModel>();
        }
    }
}