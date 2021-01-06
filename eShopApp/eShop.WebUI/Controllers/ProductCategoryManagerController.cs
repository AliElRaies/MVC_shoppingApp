using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eShop.Core.Models;
using eShop.DataAccess.InMemory;

namespace eShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        ProductCategoryRepository context;

        public ProductCategoryManagerController()
        {
            context = new ProductCategoryRepository();
        }

        public ActionResult Index()
        {
            List<ProductCategory> productCategory = context.Collection().ToList();
            return View(productCategory);
        }
        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
                return View(productCategory);
            else
            {
                context.Insert(productCategory);
                context.Comit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string ID)
        {
            ProductCategory productCategory = context.Find(ID);
            if (productCategory == null)
                return HttpNotFound();
            else
                return View(productCategory);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string ID)
        {
            ProductCategory productCategoryToEdit = context.Find(ID);
            if (productCategoryToEdit == null)
                return HttpNotFound();
            else
            {
                if (!ModelState.IsValid)
                    return View(productCategory);

                productCategoryToEdit.Category = productCategory.Category;

                context.Comit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string ID)
        {
            ProductCategory productCategoryToDelete = context.Find(ID);
            if (productCategoryToDelete == null)
                return HttpNotFound();
            else
            {
                return View(productCategoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDeletion(string ID)
        {
            ProductCategory productCategoryToDelete = context.Find(ID);
            if (productCategoryToDelete == null)
                return HttpNotFound();
            else
            {
                context.Delete(ID);
                context.Comit();
                return RedirectToAction("Index");

            }
        }
    }
}