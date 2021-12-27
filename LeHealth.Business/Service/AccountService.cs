using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountManager accountManager;
        /// <summary>
        /// Initialising todaysPatientManager object
        /// </summary>
        /// <param name="_todaysPatientManager"></param>
        public AccountService( IAccountManager _accountManager)
        {
            accountManager = _accountManager;
        }
        /// <summary>
        /// adding a new patient registration 
        /// </summary>
        public List<LoginOutputModel> Login(CredentialModel credential)
        {
            return accountManager.Login(credential); 
        }
    }
}
