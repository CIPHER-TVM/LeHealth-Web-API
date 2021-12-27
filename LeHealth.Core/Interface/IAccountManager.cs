using LeHealth.Entity.DataModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LeHealth.Core.Interface
{
    public interface IAccountManager
    {     
        /// <summary>
        /// To list of all hospital details
        /// </summary>
        List<LoginOutputModel> Login(CredentialModel credential);  
    }
}
