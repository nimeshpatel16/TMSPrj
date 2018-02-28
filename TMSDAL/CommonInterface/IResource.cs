using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataTransferObject;
namespace TMS.DataAccessLayer.CommonInterface
{
    public interface IResource
    {
        List<DTOResource> GetResouceList();
        List<DTOResource> GetResouceListById(int Id);
    }
}
