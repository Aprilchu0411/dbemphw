using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dbemphw.Models;

namespace dbemphw.Controllers
{
    public class CategoryController : Controller
    {
        readonly CategoryService categoryService = new CategoryService();
        public ActionResult Category()
        {
            List<Category> categorys = new List<Category>();
            categorys = categoryService.GetCategory();
            return View(categorys);
        }
        public ActionResult DetailsCategory(string id)
        {
            Category category = new Category();
            category = categoryService.GetCategoryByID(id);
            return View(category);
        }
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            //檢查剛剛在model設定的檢查項目是否都通過
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;

                try
                {
                    //執行剛剛的新增指令
                    categoryService.NewCategory(category);
                    //成功就可以重導向回產品列表頁面(Product Action) 
                    return RedirectToAction("Category");
                }
                catch (Exception e)
                {

                    //若新增出錯則把錯誤的viewBag設成true 返回產品頁面
                    ViewBag.Error = true;
                    return View(category);
                }
            }
            else
            {
                //沒通過驗證也是一樣
                ViewBag.Error = true;
                return View(category);
            }
        }
        public ActionResult EditCategory(string id)
        {
            var category = categoryService.GetCategoryByID(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {

            //檢查剛剛在model設定的檢查項目是否都通過
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;

                try
                {
                    //執行修改指令
                    categoryService.UpdateCategory(category);
                    //成功就可以重導向回產品列表頁面(Product Action) 
                    return RedirectToAction("Category");
                }
                catch (Exception e)
                {
                    //若新增出錯則把錯誤的viewBag設成true 返回產品頁面
                    ViewBag.Error = true;
                    return View(category);
                }
            }
            else
            {
                //沒通過驗證也是一樣
                ViewBag.Error = true;
                return View(category);
            }

        }
        public ActionResult DeleteCategory(string id)
        {
            categoryService.DeleteCategory(id);
            return RedirectToAction("Category");
        }


    }
}