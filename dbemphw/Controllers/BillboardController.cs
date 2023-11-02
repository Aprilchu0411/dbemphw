using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbemphw.Models;
namespace dbemphw.Controllers
{
    public class BillboardController : Controller
    {
        readonly BillboardService billboardService = new BillboardService();
        // GET: Billboard
        public ActionResult Billboard() //billboard
        {
            List<Billboard> billboard = new List<Billboard>();
            billboard = billboardService.GetBillboards();
            return View(billboard);
        }
    }
}