using System;

namespace WA_Test_V5.Helper
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class TreeViewAttribute : Attribute
    {
        public int Level { get; set; }

        public TreeViewAttribute(int level = int.MaxValue)
        {
            Level = level;
        }
    }
}