using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.DataAccessLayer.Leaves;
using TMS.DataTransferObject;
using TaskManagementSystem.Models.CustomClass;
using AutoMapper;

namespace TaskManagementSystem.Controllers
{
    public class LeaveController : Controller
    {
        public object DTOLeaveMaster { get; private set; }

        // GET: Leave
        public ActionResult Index()
        {
            return View();
        }

        // GET: Leave/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Leave/Create
        public ActionResult AddLeaves()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ClearData")]
        public ActionResult ClearData(LeaveModel model)
        {
            ModelState.Clear();
            return View("AddLeaves");
        }

        [ActionName("BindLeaves")]
        public ActionResult GetLeavesByResouces(LeaveModel model)
        {
            LevesDAL leaveDAL = new LevesDAL();
            DTOLeaveMaster DTOLeave = new DTOLeaveMaster();
            List<DTOLeaveMaster> dtoList = new List<TMS.DataTransferObject.DTOLeaveMaster>();
            DTOLeave.ResourceID = model.ResourceID;
            dtoList = leaveDAL.GetLeaveList(DTOLeave).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTOLeaveMaster, LeaveModel>();

            });
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            List<LeaveModel> lstModel = mapper.Map<List<DTOLeaveMaster>, List<LeaveModel>>(dtoList);
            return View(lstModel);
        }

        [HttpPost]
        [ActionName("_AddLeaves")]
        public ActionResult _AddLeaves()
        {
            return PartialView("_AddLeaves");
        }

        [HttpGet]
       
        public ActionResult GetGameListing()
        {
            var model = new LeaveModel();
             return PartialView(model);
        }
        [ActionName("ViewLyubomir")]
        public ActionResult ViewLyubomir()
        {
            return PartialView("ViewLyubomir");
        }
        [HttpPost]
        public ActionResult Lyubomir()
        {
            return RedirectToAction("Index");
        }

        // POST: Leave/Create
        [HttpPost]
        [ActionName("SaveData")]
        public ActionResult SaveRecords(FormCollection form,LeaveModel model)
        {
            try
            {
                DTOLeaveMaster DTOLeave = new DTOLeaveMaster();
                DTOLeave.ResourceName = model.ResourceName;
                DTOLeave.LeaveType = Convert.ToInt32(form["ddlLeaveType"].ToString());
                DTOLeave.StartDate = model.StartDate;
                DTOLeave.EndDate = model.EndDate;
                DTOLeave.IsStartHalf = true;
                DTOLeave.IsEndHalf = true;
                DTOLeave.Reason = model.Reason;
                
                

                if (ModelState.IsValid)
                {
                    LevesDAL levesdal = new LevesDAL();
                    levesdal.Saveleaves(DTOLeave);
                    return RedirectToAction("Index","Home");
                }
               
                return View("AddLeaves");
                
            }
            catch
            {
                return View("AddLeaves");
            }
        }

        // GET: Leave/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Leave/Edit/5
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

        // GET: Leave/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Leave/Delete/5
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
