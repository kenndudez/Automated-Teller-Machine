using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;

namespace AutomatedTellerMachine.Controllers
{
	public class HomeController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		[Authorize]
		public ActionResult Index()
		{
			var userId = User.Identity.GetUserId();
			var checkinAccountId = db.CheckingAccounts.First(c => c.ApplicationUserId == userId).Id;
			ViewBag.CheckingAccountId = checkinAccountId;
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Serial(string letterCase)
		{
			var serial = "ASPNETMVC5ATM1";
			if (letterCase == "lower")
			{
				return Content(serial.ToLower());
			}
			return Content(serial);
			//return new HttpStatusCodeResult(403);
			//return Json(new {name = "serial", value = serial}, JsonRequestBehavior.AllowGet);
			//return RedirectToAction("Index");
		}
	}
}