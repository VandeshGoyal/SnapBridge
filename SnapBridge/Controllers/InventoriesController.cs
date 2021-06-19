using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SnapBridge.Context;
using SnapBridge.Dtos;
using SnapBridge.Models;
using SnapBridge.Repository;

namespace SnapBridge.Controllers
{
    public class InventoriesController : Controller
    {
        private IDbReadRepository _dbReadRepository;
        private IDbWriteRepository _dbWriteRepository;
        public InventoriesController(IDbReadRepository dbReadRepository, IDbWriteRepository dbWriteRepository)
        {
            _dbReadRepository = dbReadRepository;
            _dbWriteRepository = dbWriteRepository;
        }

        public ActionResult Index()
        {
            try
            {
                return View("Index", _dbReadRepository.ReadAllItemsFromDB());
            }
            catch
            {
                return RedirectToAction("Error");
            }
            
        }

        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Inventory inventory = _dbReadRepository.ReadItemFromDb(id);//db.Inventories.Find(id);
                if (inventory == null)
                {
                    return HttpNotFound();
                }
                return View(inventory);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Discription,Price,Image")] InventoryDto inventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //HttpPostedFileBase file = Request.Files["ImageData"];
                    DbWriteRepository service = new DbWriteRepository();
                    int i = service.InsertInDataBase(inventory);
                    if (i == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(inventory);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                _dbWriteRepository.DeleteItemFromDb(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        public byte[] GetImageFromDataBase(int Id)
        {
            var q = _dbReadRepository.GetImageFromDb(Id);
            byte[] cover = q.First();
            return cover;
        }
    }
}
