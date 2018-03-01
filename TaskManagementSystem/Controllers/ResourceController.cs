using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.DataAccessLayer.CommonInterface;
using TaskManagementSystem.Models.CustomClass;

namespace TaskManagementSystem.Controllers
{
    public class ResourceController : Controller
    {
        IResource _iresource;
        public ResourceController(IResource resource)
        {
            _iresource = resource;
        }
        
        // GET: Resource
        public ActionResult Index()
        {
            return View();
        }

        // GET: Resource/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resource/Create
        public ActionResult AddResource()
        {
            return View();
        }

        [HttpPost]
        [ActionName("SaveData")]
        public ActionResult SaveRecords(ResourceModel model)
        {
            try
            {
                

                return View("AddResource");

            }
            catch
            {
                return View("AddResource");
            }
        }

        public ActionResult GetAllResource()
        {
            return View(_iresource.GetResouceList());
        }
        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            return View();
        }
       public ActionResult Create()
        {
            return View();
        }
        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Resource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Resource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
