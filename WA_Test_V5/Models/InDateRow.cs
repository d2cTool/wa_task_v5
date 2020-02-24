using WA_Test_V5.Helper;

namespace WA_Test_V5.Models
{
    public class InDateRow
    {
        [TreeView(1)]
        public string Program { get; set; }

        [TreeView(2)]
        public string Project { get; set; }

        [TreeView(3)]
        public string Budjet { get; set; }

        [TreeView(4)]
        public string Stage { get; set; }

        [TreeView(5)]
        public string System { get; set; }

        [TreeView(6)]
        public string Element { get; set; }

        [TreeView(7)]
        public int ISR { get; set; }

        [TreeView(8)]
        public string PIR { get; set; }

        [TreeView(9)]
        public string Mark { get; set; }

        public int CID { get; set; }
    }
}