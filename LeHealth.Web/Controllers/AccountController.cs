using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeHealth.Base.API.Controllers
{
    [Route("api/Account")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;
        private readonly IAccountService accountService;

        public AccountController(ILogger<AccountController> _logger, IAccountService _accountService)
        {
            logger = _logger;
            accountService = _accountService;
        }
        /// <summary>
        /// API for Login into website
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LoginOutputModel>> Login(CredentialModel credentials)
        {
            try
            {
                List<LoginOutputModel> loginoutputList = new List<LoginOutputModel>();
                loginoutputList = accountService.Login(credentials);
                var response = new ResponseDataModel<IEnumerable<LoginOutputModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = loginoutputList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LoginOutputModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }
            finally
            {
            }
        }
        /// <summary>
        /// For testing purposes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Getdata")]
        public string Getdata()
        {
            return "success";
        }
    }
}
