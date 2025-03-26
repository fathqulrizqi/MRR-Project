using NGKBusi.Models;
using NGKBusi.Areas.Other.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Claims;


namespace NGKBusi.Areas.Other.Controllers
{
    public class MRRController : Controller
    {

        DefaultConnection db = new DefaultConnection();
        MRRConnection dbm = new MRRConnection();

        // GET: Other/MRR
        public ActionResult Index()
        {
            var currUserId = User.Identity.GetUserId();
            ViewBag.allowedUpdate = false;
            ViewBag.navHide = true;
            //if (Request.IsAuthenticated)
            //{
            //    ViewBag.allowedUpdate = db.Users_Menus_Roles.Where(x => x.userNIK == currUserId && x.menuID == 7).Select(x => x.allowUpdate).SingleOrDefault();
            //}
            return View();
        }

       [HttpPost]
       public ActionResult GetRoomDetails(int ID)
        {
            var currUser = ((ClaimsIdentity)User.Identity).GetUserId();
            var CurrUser = db.V_Users_Active.Where(w => w.NIK == currUser).FirstOrDefault();

            var room = dbm.OTH_MRR_Master_Rooms.Where(w => w.IDRoomCat == ID).ToList();
            var roomIDs = room.Select(r => r.ID).ToList();
            var props = dbm.OTH_MRR_Rooms_Properties.Where(w => roomIDs.Contains(w.RoomID)).ToList();

            return Json(new { data = room, prop = props }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSchedule()
        {
            var currUser = ((ClaimsIdentity)User.Identity).GetUserId();
            var CurrUser = db.V_Users_Active.Where(w => w.NIK == currUser).FirstOrDefault();

            return View();
        }

        public ActionResult Data()
        {
            Response.ContentType = "text/xml";
            ViewBag.events = db.Events.ToList();
            return View();
        }
    }
}