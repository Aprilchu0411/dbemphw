using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using dbemphw.Models;
namespace dbemphw.Controllers
{
    public class SingerController : Controller
    {
        readonly SingerService singerService = new SingerService();
        // GET: Singer
        public ActionResult Singer()
        {
            List<Singer> singer = new List<Singer>();
            singer = singerService.GetSingers();
            return View(singer);
        }

        public ActionResult DetailSinger(string zId)
        {
            Singer singer = new Singer();
            singer = singerService.GetSingerByID(zId);
            return View(singer);
        }
        public ActionResult CreateSinger()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSinger(Singer singer)
        {
            //檢查剛剛在model設定的檢查項目是否都通過
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;

                try
                {
                    //執行剛剛的新增指令
                    singerService.NewSinger(singer);
                    //成功就可以重導向回產品列表頁面(Product Action) 
                    return RedirectToAction("Singer");
                }
                catch (Exception e)
                {

                    //若新增出錯則把錯誤的viewBag設成true 返回產品頁面
                    ViewBag.Error = true;
                    return View(singer);
                }
            }
            else
            {
                //沒通過驗證也是一樣
                ViewBag.Error = true;
                return View(singer);
            }
        }
        public ActionResult EditSinger(string zId)
        {
            var singer = singerService.GetSingerByID(zId);
            return View(singer);
        }
        [HttpPost]
        public ActionResult EditSinger(Singer singer)
        {

            //檢查剛剛在model設定的檢查項目是否都通過
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;

                try
                {
                    //執行修改指令
                    singerService.UpdateSinger(singer);
                    //成功就可以重導向回產品列表頁面(Product Action) 
                    return RedirectToAction("Singer");
                }
                catch (Exception e)
                {
                    //若新增出錯則把錯誤的viewBag設成true 返回產品頁面
                    ViewBag.Error = true;
                    return View(singer);
                }
            }
            else
            {
                //沒通過驗證也是一樣
                ViewBag.Error = true;
                return View(singer);
            }

        }  public ActionResult DeleteSinger(string id)
    {
        singerService.DeleteSinger(id);
        return RedirectToAction("Singer");
    }
    }
  
}