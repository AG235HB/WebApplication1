using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        ASP_DB_Context db = new ASP_DB_Context();

        public ActionResult Index()
        {
            IEnumerable<Organisation> organisations = db.Organisations;
            ViewBag.Organisations = organisations;

            IEnumerable<Founder> founders = db.Founders;
            ViewBag.Founders = founders;

            IEnumerable<Relation> relations = db.Relations;
            ViewBag.Relations = relations;

            return View();
        }

        [HttpGet]
        public ActionResult ViewOrg(int id)
        {
            IEnumerable<Organisation> organisations = db.Organisations;
            foreach(Organisation o in organisations)
                if (o.ID==id)
                    ViewBag.Organisation = o;

            IEnumerable<Founder> founders = db.Founders;
            IEnumerable<Relation> relations = db.Relations;
            var selectedFounders = from founder in db.Founders
                                   from relation in relations
                                   where relation.org_ID == id
                                   where founder.ID == relation.fdr_ID
                                   select founder;

            foreach (Founder f in selectedFounders)
                Console.WriteLine(f.Name);

            ViewBag.Founders = selectedFounders;

            return View();
        }

        [HttpGet]
        public ActionResult AddOrg()
        {
            ViewBag.Founders = db.Founders;
            return View();
        }

        [HttpPost]
        public string AddOrg(Organisation org, List<int> fdr_id)
        {
            db.Organisations.Add(org);
            db.SaveChanges();

            var newId = from organisation in db.Organisations
                        where organisation.Name == org.Name
                        where organisation.INN == org.INN
                        select organisation.ID;

            foreach (var id in newId)
            {
                foreach (var f in fdr_id)
                    db.Relations.Add(new Relation { org_ID = id, fdr_ID = f });
            }
            db.SaveChanges();

            return "POST";
            //return View();
        }
    }
}