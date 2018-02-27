using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace TaskManagementSystem.Models.CustomClass
{
    public class LeaveModel
    {
        public Int32 LeaveId { get; set; }
        public Int32 ResourceID { get; set; }
        public Int32 ProjectID { get; set; }
        public string ResourceName { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
        public bool IsStartHalf { get; set; }
        public bool IsEndHalf { get; set; }
        [Required(ErrorMessage = "Reason text cannot be blank")]
        public string Reason { get; set; }
        public Int32 LeaveType { get; set; }
        public string LeaveTypeDescription { get; set; }
        public Decimal AppliedLeaveCount { get; set; }
        public Decimal LeaveBalance { get; set; }
        public Decimal Balance { get; set; }
        public int Status { get; set; }

        public string EmailToHR { get; set; }
        public string EmailToEmp { get; set; }
        public string StatusName { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 LastModifiedBy { get; set; }
        public string LastModifiedByName { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Nullable<Int32> Search_PageIndex { get; set; }
        public Nullable<Int32> Search_PageSize { get; set; }
        public Nullable<Int32> TotalRowCount { get; set; }
        //public TestPartialModel Partial { get; set; }
    }
    //public class TestPartialModel
    //{
    //    public string ResourceName { get; set; }
    //    public string Title { get; set; }
        
    //    public DateTime StartDate { get; set; }
       
    //    public DateTime EndDate { get; set; }
    //    public bool IsStartHalf { get; set; }
    //    public bool IsEndHalf { get; set; }
       
    //    public string Reason { get; set; }
    //}

}