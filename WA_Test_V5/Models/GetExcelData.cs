using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using WA_Test_V5.Interface.TreeView;
using WA_Test_V5.Models;

namespace WA_Test_V5.GetData.Excel
{
    public class GetExcelData
    {
        private ExcelPackage pack;
        private string path;
        public GetExcelData(string filePath)
        {
            path = filePath;
            FileInfo fInfo = new FileInfo(path);
            if (fInfo.Exists != true) throw new Exception();
            pack = new ExcelPackage(fInfo);
        }

        public List<TreeViewElements> GetSample()
        {
            var sheets = pack.Workbook.Worksheets;
            var dataSheet = sheets.First();
            var numberOfRows = dataSheet.Dimension.End.Row;
            var numberOfCols = dataSheet.Dimension.End.Column;
            ExcelRange Cells = dataSheet.Cells;
            var _SampleTreeView = new List<TreeViewElements>();
            for (int rowIterator = 2; rowIterator <= numberOfRows; rowIterator++)
            {
                var e = new TreeViewElements()
                {
                    ID = Cells[rowIterator, 1].Value.ToString(),
                    Parent_ID = Cells[rowIterator, 2].Value.ToString(),
                    Name = Cells[rowIterator, 3].Value.ToString(),
                    CID = Convert.ToInt32(Cells[rowIterator, 4].Value),
                };
                _SampleTreeView.Add(e);
            }
            return _SampleTreeView;
        }

        public List<InDateRow> GetData()
        {
            var sheets = pack.Workbook.Worksheets;
            var dataSheet = sheets.FirstOrDefault(s => s.Name == "Исх. данные");
            var numberOfRows = dataSheet.Dimension.End.Row;
            var numberOfCols = dataSheet.Dimension.End.Column;
            var Cells = dataSheet.Cells;
            var _SampleTreeView = new List<InDateRow>();
            for (int rowIterator = 2; rowIterator <= numberOfRows; rowIterator++)
            {
                var e = new InDateRow()
                {
                    Program = Cells[rowIterator, 1].Value.ToString(),
                    Project = Cells[rowIterator, 2].Value.ToString(),
                    Budjet = Cells[rowIterator, 3].Value.ToString(),
                    Stage = Cells[rowIterator, 4].Value.ToString(),
                    System = Cells[rowIterator, 5].Value.ToString(),
                    Element = Cells[rowIterator, 6].Value.ToString(),
                    ISR = Convert.ToInt32(Cells[rowIterator, 7].Value),
                    PIR = Cells[rowIterator, 8].Value.ToString(),
                    Mark = Cells[rowIterator, 9].Value.ToString(),
                    CID = Convert.ToInt32(Cells[rowIterator, 10].Value),
                };
                _SampleTreeView.Add(e);
            }
            return _SampleTreeView;
        }
    }
}