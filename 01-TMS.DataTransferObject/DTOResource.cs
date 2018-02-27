using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.DataTransferObject
{
    public class DTOResource
    {
        public DTOResource()
        {
        }
        public Int64 ResourceID { get; set; }
        public string ResourceName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }
        public string PrimaryContact { get; set; }
        public string EmergencyContact { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public Nullable<DateTime> JoiningDate { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
        public string ResourceIDs { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Nullable<Int32> Search_PageIndex { get; set; }
        public Nullable<Int32> Search_PageSize { get; set; }
        public Nullable<Int32> TotalRowCount { get; set; }
        public bool? IsActive { get; set; }
        public string ProjectIDs { get; set; }
        public string ProjectNames { get; set; }
        public DateTime @startdate { get; set; }
        public DateTime @enddate { get; set; }
        public Int64 ProjectID { get; set; }
        public Int64 ResID { get; set; }
        public Nullable<Decimal> TotalLeave { get; set; }
        public Nullable<Decimal> CarryForwardedLeave { get; set; } 
        public Nullable<DateTime> InactiveDate { get; set; }

        public Nullable<Decimal> HidedenTotalLeave { get; set; }
        public Nullable<Decimal> HidedenCarryForwardedLeave { get; set; } 
    }
}
