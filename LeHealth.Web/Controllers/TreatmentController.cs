using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeHealth.Base.API.Controllers
{
    [Route("api/Treatment")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ILogger<TreatmentController> logger;
        private readonly ITreatmentService treatmentService; 
        public TreatmentController(ILogger<TreatmentController> _logger, ITreatmentService _treatmentService)
        {
            logger = _logger;
            treatmentService = _treatmentService;
        }

        [Route("InsertUpdatePhysioAnalysisHistoryTreatment")]
        [HttpPost]
        public ResponseDataModel<PhysioAnalysisHistoryModel> InsertUpdatePhysioAnalysisHistoryTreatment(PhysioAnalysisHistoryModel pem)
        {
            try
            {
                string message = string.Empty;
                PhysioAnalysisHistoryModel vm = new PhysioAnalysisHistoryModel();
                vm = treatmentService.InsertUpdatePhysioAnalysisHistoryTreatment(pem);
                if (vm.Id > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<PhysioAnalysisHistoryModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = vm,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<PhysioAnalysisHistoryModel>()
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

        [Route("GetPhysioAnalysisHistoryTreatment")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PhysioAnalysisHistoryModel>> GetPhysioAnalysisHistoryTreatment(PhysioAnalysisHistoryModel ndim)
        {
            try
            {
                List<PhysioAnalysisHistoryModel> cptList = new List<PhysioAnalysisHistoryModel>();
                cptList = treatmentService.GetPhysioAnalysisHistoryTreatment(ndim);
                var response = new ResponseDataModel<IEnumerable<PhysioAnalysisHistoryModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PhysioAnalysisHistoryModel>>()
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
        [Route("InsertTreatmentDetails")]
        [HttpPost]
        public ResponseDataModel<TreatmentDetailsModel> InsertTreatmentDetails(TreatmentDetailsModel dem)
        {
            try
            {
                string message = string.Empty;
                TreatmentDetailsModel vm = new TreatmentDetailsModel();
                vm = treatmentService.InsertTreatmentDetails(dem);
                if (vm.Id > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<TreatmentDetailsModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = vm,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<TreatmentDetailsModel>()
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

        [Route("GetTreatmentDetails")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<TreatmentDetailsModel>> GetTreatmentDetails(TreatmentDetailsModel ndim)
        {
            try
            {
                List<TreatmentDetailsModel> cptList = new List<TreatmentDetailsModel>();
                cptList = treatmentService.GetTreatmentDetails(ndim);
                var response = new ResponseDataModel<IEnumerable<TreatmentDetailsModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<TreatmentDetailsModel>>()
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
