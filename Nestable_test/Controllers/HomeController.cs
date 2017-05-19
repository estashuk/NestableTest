using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml;
using Nestable_test.Domain;
using Nestable_test.Domain.Entities;
using Newtonsoft.Json;

namespace Nestable_test.Controllers
{
    public class HomeController : Controller
    {
        protected readonly Context Context;

        public HomeController()
        {
            Context = new Context();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PublicPage()
        {
            var menu = Context.MenuCfg.FirstOrDefault(x => x.Id == 1);
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(menu?.MenuConfig);
            return View(xml);
        }

        [HttpPost]
        public EmptyResult SaveMenuConfiguration(string txtValue)
        {
            XmlDocument xml = JsonConvert.DeserializeXmlNode("{\"li\":" + txtValue + "}", "ol");
            //XmlDocument xml = JsonConvert.DeserializeXmlNode(txtValue.Substring(1, txtValue.Length - 2), "root");

            //System.IO.File.WriteAllText(@"D:\WriteFile.txt", xml.OuterXml);

            MenuData menuData = new MenuData
            {
                Id = 1,
                MenuConfig = xml.OuterXml
            };

            Context.MenuCfg.AddOrUpdate(menuData);
            Context.SaveChanges();

            return null;
        }
    }
}