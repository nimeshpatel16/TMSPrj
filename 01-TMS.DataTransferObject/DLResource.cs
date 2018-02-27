//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MLM.DBAccess;

//namespace MLM.BusinessLayer
//{
//    public class DLResource
//    {

//        DbHelper dbHelper = new DbHelper();


//        public DLResource()
//        {
//        }

//        // Get Resources based on Project (Default page)
//        public List<DTOResource> GetResourceFromTastMaster(DTOResource dtoResrouce)
//        {
//            dbHelper.ClearParameters();

//            //Add the Parameters
//            if (dtoResrouce.ProjectIDs != "")
//                dbHelper.AddParameter("@ProjectIDs", dtoResrouce.ProjectIDs);

//            if (dtoResrouce.startdate != null)
//                dbHelper.AddParameter("@startdate", dtoResrouce.startdate);

//            if (dtoResrouce.enddate != null)
//                dbHelper.AddParameter("@enddate", dtoResrouce.enddate);
//            //Pass the constant of the SP name to Execute it, Get the Result in DataTable, Convert it into List
//            return CollectionHelper.ConvertTo<DTOResource>(dbHelper.ExecuteDataTable("usp_GetResouceForTaskDetails"));
//        }

//        // Get Resources based on Project (ProjectwiseResourceAllocation page)
//        public List<DTOResource> GetResourceFromProjectAllocationMaster(DTOResource dtoResrouce)
//        {
//            dbHelper.ClearParameters();

//            //Add the Parameters
//            if (dtoResrouce.ProjectIDs != "")
//                dbHelper.AddParameter("@ProjectIDs", dtoResrouce.ProjectIDs);

//            if (dtoResrouce.startdate != null)
//                dbHelper.AddParameter("@startdate", dtoResrouce.startdate);

//            if (dtoResrouce.enddate != null)
//                dbHelper.AddParameter("@enddate", dtoResrouce.enddate);
//            //Pass the constant of the SP name to Execute it, Get the Result in DataTable, Convert it into List
//            return CollectionHelper.ConvertTo<DTOResource>(dbHelper.ExecuteDataTable("usp_GetResouceForProjectWiseResAllocation"));
//        }

//        public List<DTOResource> GetResourceForTaskDDL(DTOResource dtoResrouce)
//        {
//            dbHelper.ClearParameters();

//            //Add the Parameters
//            if (dtoResrouce.ResourceID != 0)
//                dbHelper.AddParameter("@ResourceId", dtoResrouce.ResourceID);

//            if (dtoResrouce.ProjectID != 0)
//                dbHelper.AddParameter("@ProjectID", dtoResrouce.ProjectID);

//            //Pass the constant of the SP name to Execute it, Get the Result in DataTable, Convert it into List
//            return CollectionHelper.ConvertTo<DTOResource>(dbHelper.ExecuteDataTable("usp_GetResourceToProject"));
//        }

//        public List<DTOResource> GetAllResource(DTOResource dtoResrouce)
//        {
//            dbHelper.ClearParameters();

//            //Add the Parameters
//            if (dtoResrouce.ResourceID != 0)
//                dbHelper.AddParameter("@ResourceID", dtoResrouce.ResourceID);

//            if (dtoResrouce.Search_PageIndex != null)
//                dbHelper.AddParameter("@Search_PageIndex", dtoResrouce.Search_PageIndex);

//            if (dtoResrouce.Search_PageSize != null)
//                dbHelper.AddParameter("@Search_PageSize", dtoResrouce.Search_PageSize);

//            if (dtoResrouce.IsActive != null)
//                dbHelper.AddParameter("@IsActive", dtoResrouce.IsActive);
            
//            if (!string.IsNullOrEmpty(dtoResrouce.ResourceName))        //Kajal.Trivedi (01/08/2015)
//                dbHelper.AddParameter("@ResourceName", dtoResrouce.ResourceName);
//            //Pass the constant of the SP name to Execute it, Get the Result in DataTable, Convert it into List
//            return CollectionHelper.ConvertTo<DTOResource>(dbHelper.ExecuteDataTable("usp_GetResource"));
//        }

//        /// <summary>
//        /// Insert Member
//        /// </summary>
//        /// <param name="dtoMember"></param>
//        public void InsertResource(DTOResource dtoResrouce)
//        {
//            List<DTOResource> lstResource = new List<DTOResource>();
//            dbHelper.ClearParameters();

//            dbHelper.AddParameter("@ResourceName", dtoResrouce.ResourceName);
//            dbHelper.AddParameter("@FirstName", dtoResrouce.FirstName);
//            dbHelper.AddParameter("@LastName", dtoResrouce.LastName);
//            dbHelper.AddParameter("@RoleID", dtoResrouce.RoleID);
//            dbHelper.AddParameter("@Email", dtoResrouce.Email);
//            dbHelper.AddParameter("@CreatedBy", dtoResrouce.CreatedBy);
//            dbHelper.AddParameter("@CreatedDate", dtoResrouce.CreatedDate);

//            dbHelper.AddParameter("@Contact", dtoResrouce.PrimaryContact);
//            dbHelper.AddParameter("@EmergencyContact", dtoResrouce.EmergencyContact);
//            dbHelper.AddParameter("@Address", dtoResrouce.Address);
//            dbHelper.AddParameter("@DOB", dtoResrouce.DOB);
//            dbHelper.AddParameter("@JoiningDate", dtoResrouce.JoiningDate);
//            dbHelper.AddParameter("@TotalLeave", dtoResrouce.TotalLeave);       //kajal.trivedi(12/5/2014)
//            dbHelper.AddParameter("@BloodGroup", dtoResrouce.BloodGroup);

//            lstResource = CollectionHelper.ConvertTo<DTOResource>(dbHelper.ExecuteDataTable("usp_InsertResource"));
//            if (dtoResrouce.ProjectIDs != "")
//            {
//                DTOResourceProject dtoResourcePro = new DTOResourceProject();
//                dtoResourcePro.ResourceID = lstResource[0].ResourceID;
//                dtoResourcePro.ProjectIDs = dtoResrouce.ProjectIDs;
//                dtoResourcePro.CreatedBy = dtoResrouce.CreatedBy;
//                dtoResourcePro.CreatedDate = dtoResrouce.CreatedDate;
//                InsertResourceToProject(dtoResourcePro);
//            }
//        }

//        public void InsertResourceToProject(DTOResourceProject dtoResourcePro)
//        {
//            dbHelper.ClearParameters();
//            dbHelper.AddParameter("@ResourceID", dtoResourcePro.ResourceID);
//            dbHelper.AddParameter("@ProjectID", dtoResourcePro.ProjectIDs);
//            dbHelper.AddParameter("@CreatedBy", dtoResourcePro.CreatedBy);
//            dbHelper.AddParameter("@CreatedDate", dtoResourcePro.CreatedDate);

//            dbHelper.ExecuteNonQuery("usp_InsertResourceToProject");
//        }

//        public void UpdatePassword(DTOResource dtoResrouce)
//        {
//            dbHelper.ClearParameters();

//            dbHelper.AddParameter("@ResourceID", dtoResrouce.ResourceID);
//            dbHelper.AddParameter("@Password", dtoResrouce.Password);

//            dbHelper.ExecuteNonQuery("usp_Update_ResourcePassword");
//        }


//        public void UpdateIsActive(DTOResource dtoResrouce)
//        {
//            dbHelper.ClearParameters();

//            dbHelper.AddParameter("@ResourceID", dtoResrouce.ResourceID);
//            if (dtoResrouce.IsActive == true)
//            {
//                dbHelper.AddParameter("@IsActive", 0);
//                dbHelper.AddParameter("@InactiveDate", null);
//            }
//            else
//            {
//                dbHelper.AddParameter("@IsActive", 1);
//                dbHelper.AddParameter("@InactiveDate", dtoResrouce.InactiveDate);
//            }

//            dbHelper.ExecuteNonQuery("usp_SetUserIsActive");
//        }

//        public void UpdateResource(DTOResource dtoResrouce)
//        {
            
//            dbHelper.ClearParameters();

//            dbHelper.AddParameter("@ResourceID", dtoResrouce.ResourceID);
//            dbHelper.AddParameter("@ResourceName", dtoResrouce.ResourceName);
//            dbHelper.AddParameter("@FirstName", dtoResrouce.FirstName);
//            dbHelper.AddParameter("@LastName", dtoResrouce.LastName);
//            dbHelper.AddParameter("@RoleID", dtoResrouce.RoleID);
//            dbHelper.AddParameter("@Email", dtoResrouce.Email);
//            dbHelper.AddParameter("@LastModifiedBy", dtoResrouce.LastModifiedBy);
//            dbHelper.AddParameter("@LastModifiedDate", dtoResrouce.LastModifiedDate);

//            dbHelper.AddParameter("@Contact", dtoResrouce.PrimaryContact);
//            dbHelper.AddParameter("@EmergencyContact", dtoResrouce.EmergencyContact);
//            dbHelper.AddParameter("@Address", dtoResrouce.Address);
//            dbHelper.AddParameter("@DOB", dtoResrouce.DOB);
//            dbHelper.AddParameter("@JoiningDate", dtoResrouce.JoiningDate);
//            dbHelper.AddParameter("@BloodGroup", dtoResrouce.BloodGroup);

//            if (dtoResrouce.TotalLeave != null && dtoResrouce.CarryForwardedLeave != null)
//            {
//                dbHelper.AddParameter("@TotalLeave", dtoResrouce.TotalLeave);
//                dbHelper.AddParameter("@CarryForwardedLeave", dtoResrouce.CarryForwardedLeave);
//                dbHelper.ExecuteNonQuery("usp_Update_Resource");
//            }
//            else
//                dbHelper.ExecuteNonQuery("usp_Update_ResourceMaster");

//            if (dtoResrouce.ProjectIDs != "")
//            {
//                DTOResourceProject dtoResourcePro = new DTOResourceProject();
//                dtoResourcePro.ResourceID = dtoResrouce.ResourceID;
//                dtoResourcePro.ProjectIDs = dtoResrouce.ProjectIDs;
//                dtoResourcePro.CreatedBy = dtoResrouce.LastModifiedBy;
//                dtoResourcePro.CreatedDate = dtoResrouce.LastModifiedDate;

//                InsertResourceToProject(dtoResourcePro);
//            }

//        }

//        public List<DTOResource> VerifyUser(string Username)
//        {
//            dbHelper.ClearParameters();

//            //Add the Parameters
//            dbHelper.AddParameter("@Username", Username);

//            //Pass the constant of the SP name to Execute it, Get the Result in DataTable, Convert it into List
//            return CollectionHelper.ConvertTo<DTOResource>(dbHelper.ExecuteDataTable("usp_LoginVerification"));
//        }

//    }

//}
