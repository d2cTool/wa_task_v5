﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WA_Test_V5.GetData.Excel;
using WA_Test_V5.Helper;
using WA_Test_V5.Interface.JsTreeNodes;

namespace WA_Test_V5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetTreeViewSample()
        {
            var parser = new GetExcelData(Server.MapPath("~/Content/SampleData.xlsx"));
            var SampleTreeView = parser.GetSample();

            int nodeUnicID = 0;
            var ParentsDic = new Dictionary<int, string>();//no
            var ReadyList = new List<JsTree3Node>();
            var mainNode = new JsTree3Node()
            {
                id = "0",
                text = "Портфель проектов",
                state = new State(true, false, false),
                children = new List<JsTree3Node>(),
                data = 0
            };
            ReadyList.Add(mainNode);
            ParentsDic.Add(nodeUnicID, "0");
            nodeUnicID++;
            foreach (var elem in SampleTreeView)
            {
                var newNode = new JsTree3Node()
                {
                    id = elem.ID,
                    text = elem.Name,
                    state = new State(false, false, false),
                    children = new List<JsTree3Node>(),
                    data = elem.CID
                };
                if (ParentsDic.ContainsValue(elem.Parent_ID.ToString()))
                    ReadyList[ParentsDic.FirstOrDefault(x => x.Value == elem.Parent_ID.ToString()).Key].children.Add(newNode);

                ReadyList.Add(newNode);
                ParentsDic.Add(nodeUnicID, elem.ID.ToString());
                nodeUnicID++;
            }
            return Json(mainNode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTreeViewNew()
        {
            var parser2 = new GetExcelData(Server.MapPath("~/Content/Task.xlsx"));
            var inData = parser2.GetData().Convert();

            int nodeUnicID = 0;
            var ParentsDic = new Dictionary<int, string>();//no
            var ReadyList = new List<JsTree3Node>();
            var mainNode = new JsTree3Node()
            {
                id = "0",
                text = "Портфель проектов",
                state = new State(true, false, false),
                children = new List<JsTree3Node>(),
                data = 0
            };
            ReadyList.Add(mainNode);
            ParentsDic.Add(nodeUnicID, "0");
            nodeUnicID++;
            foreach (var elem in inData)
            {
                var newNode = new JsTree3Node()
                {
                    id = elem.ID,
                    text = elem.Name,
                    state = new State(false, false, false),
                    children = new List<JsTree3Node>(),
                    data = elem.CID
                };
                if (ParentsDic.ContainsValue(elem.Parent_ID.ToString()))
                    ReadyList[ParentsDic.FirstOrDefault(x => x.Value == elem.Parent_ID.ToString()).Key].children.Add(newNode);

                ReadyList.Add(newNode);
                ParentsDic.Add(nodeUnicID, elem.ID.ToString());
                nodeUnicID++;
            }
            return Json(mainNode, JsonRequestBehavior.AllowGet);
        }
    }
}