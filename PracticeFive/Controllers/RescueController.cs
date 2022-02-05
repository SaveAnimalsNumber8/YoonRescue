using Newtonsoft.Json;
using PracticeFive.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeFive.Controllers
{
    public class RescueController : Controller
    {
        SaveAnimalsEntities sadb = new SaveAnimalsEntities();

        // GET: Rescue
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var rescueList = sadb.tRescue.OrderByDescending(sadb => sadb.Created_At).ToList();
            return View(rescueList);
        }


        public ActionResult More(int id)
        {
            tRescue rescueDetails = sadb.tRescue.FirstOrDefault(p => p.RescueID == id);

            if (rescueDetails == null)
            {
                return RedirectToAction("List", "Rescue");
            }
            else
            {
                return View(rescueDetails);
            }
        }
    }
}