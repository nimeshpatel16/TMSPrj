using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataAccessLayer.CommonInterface;
using TMS.DataTransferObject;
using System.Data;
using System.Data.SqlClient;


namespace TMS.DataAccessLayer.Resource
{
    public class ResourceDAL : IResource
    {
        public List<DTOResource> GetResouceList()
        {
            List<DTOResource> dtoresource = new List<DTOResource>();
            DataSet ds = new DataSet();
            SqlHelper sqlHelper = new SqlHelper();
            SqlParameter[] param = new SqlParameter[1];
            return CollectionHelper.ConvertTo<DTOResource>(sqlHelper.ExecuteDataTable("usp_GetResource", null));
        }

        public List<DTOResource> GetResouceListById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
