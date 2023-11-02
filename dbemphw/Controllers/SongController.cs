using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dbemphw.Models;
namespace dbemphw.Controllers
{
    public class SongController : Controller
    {
        readonly ProductService productService = new ProductService();
        public ActionResult Song()
        {
            List<Song> songs = new List<Song>();
            songs = productService.GetSongs();
            return View(songs);
        }
        public ActionResult Details(string id)
        {
            Song song = new Song();
            song = productService.GetSongByID(id);
            return View(song);
        }
        public ActionResult CreateSong()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSong(Song song)
        {
            //檢查剛剛在model設定的檢查項目是否都通過
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;

                try
                {
                    //執行剛剛的新增指令
                    productService.NewProduct(song);
                    //成功就可以重導向回產品列表頁面(Product Action) 
                    return RedirectToAction("Song");
                }
                catch (Exception e)
                {
                   
                    //若新增出錯則把錯誤的viewBag設成true 返回產品頁面
                    ViewBag.Error = true;
                    return View(song);
                }
            }
            else
            {
                //沒通過驗證也是一樣
                ViewBag.Error = true;
                return View(song);
            }
        }
        public ActionResult Edit(string id)
        {
            var song = productService.GetSongByID(id);
            return View(song);
        }

        [HttpPost]
        public ActionResult Edit(Song song)
        {

            //檢查剛剛在model設定的檢查項目是否都通過
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;

                try
                {
                    //執行修改指令
                    productService.UpdateSong(song);
                    //成功就可以重導向回產品列表頁面(Product Action) 
                    return RedirectToAction("Song");
                }
                catch (Exception e)
                {
                    //若新增出錯則把錯誤的viewBag設成true 返回產品頁面
                    ViewBag.Error = true;
                    return View(song);
                }
            }
            else
            {
                //沒通過驗證也是一樣
                ViewBag.Error = true;
                return View(song);
            }

        }
        public ActionResult Delete(string id)
        {
            productService.DeleteSong(id);
            return RedirectToAction("Song");
        }


    }
}