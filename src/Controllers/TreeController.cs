using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolProject.Controllers
{
    public class TreeController : Controller
    {
        private SchoolContext _db = new SchoolContext();

        // GET: Tree
        public ActionResult Index()
        {
            var treeStructure = _db.TreeItems.ToList();
            return View(treeStructure);
        }
    }
}