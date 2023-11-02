using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbemphw.Models;
namespace dbemphw.Controllers
{
    public class AlbumController : Controller
    {
        readonly AlbumService albumService = new AlbumService();
        // GET: Album
        public ActionResult Album()
        {
            List<Album> album = new List<Album>();
            album = albumService.GetAlbum();
            return View(album);
        }
        public ActionResult DetailAlbum(string aId)
        {
            Album album = new Album();
            album = albumService.GetAlbumByID(aId);
            return View(album);
        }
        public ActionResult CreateAlbum()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAlbum(Album album)
        {
            //檢查剛剛在model設定的檢查項目是否都通過
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;

                try
                {
                    //執行剛剛的新增指令
                    albumService.NewAlbum(album);
                    //成功就可以重導向回產品列表頁面(Product Action) 
                    return RedirectToAction("Album");
                }
                catch (Exception e)
                {

                    //若新增出錯則把錯誤的viewBag設成true 返回產品頁面
                    ViewBag.Error = true;
                    return View(album);
                }
            }
            else
            {
                //沒通過驗證也是一樣
                ViewBag.Error = true;
                return View(album);
            }
        }
        public ActionResult EditAlbum(string aId)
        {
            var album = albumService.GetAlbumByID(aId);
            return View(album);
        }
        [HttpPost]
        public ActionResult EditAlbum(Album album)
        {

            //檢查剛剛在model設定的檢查項目是否都通過
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;

                try
                {
                    //執行修改指令
                    albumService.UpdateAlbum(album);
                    //成功就可以重導向回產品列表頁面(Product Action) 
                    return RedirectToAction("Album");
                }
                catch (Exception e)
                {
                    //若新增出錯則把錯誤的viewBag設成true 返回產品頁面
                    ViewBag.Error = true;
                    return View(album);
                }
            }
            else
            {
                //沒通過驗證也是一樣
                ViewBag.Error = true;
                return View(album);
            }

        }
        public ActionResult DeleteAlbum(string id)
        {
            albumService.DeleteAlbum(id);
            return RedirectToAction("Album");
        }
    }
}
