using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using LeHealth.Entity.ViewModel;
using LeHealth.Service.ServiceInterface;
using LeHealth.Entity.DataModel;
using System.Data;

namespace LeHealth.Catalogue.API.Controllers
{
    [Route("api/FormValidation")]
    [ApiController]
    public class FormValidationController : ControllerBase
    {
        private readonly ILogger<FormValidationController> logger;
        private readonly IFormValidationService formValidationService;

        /// <summary>
        /// Initialisation of logger,hospital service objects

        /// </summary>
        public FormValidationController(ILogger<FormValidationController> _logger, IFormValidationService _formValidationService)
        {
            logger = _logger;
            formValidationService = _formValidationService;
        }


        [Route("GetFormValidation/{FormId}/{DepartmentId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<FormValidationModel>> GetFormValidation(Int32 FormId, Int32 DepartmentId)
        {
            try
            {
                var hospitals = formValidationService.GetFormValidation(FormId, DepartmentId);
                var response = new ResponseDataModel<IEnumerable<FormValidationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = hospitals,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "FormValidationController", "GetFormValidation()");

                return new ResponseDataModel<IEnumerable<FormValidationModel>>()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Response = null,
                    ErrorMessage = new ErrorResponse()
                    {
                        Message = ex.Message
                    }

                };
            }

        }
        [Route("InsertUpdateFormValidation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<FormValidationModel>> InsertUpdateFormValidation(FormValidationModel formvalidation)
        {
            String message = String.Empty;;
            try
            {
                message = formValidationService.InsertUpdateFormValidation(formvalidation);
                var response = new ResponseDataModel<IEnumerable<FormValidationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<FormValidationModel>>()
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

    }
}
