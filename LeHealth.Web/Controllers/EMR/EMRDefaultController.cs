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

namespace LeHealth.Base.API.Controllers.EMR
{
    [Route("api/EMR")]
    [ApiController]
    public class EMRDefaultController : ControllerBase
    {
        private readonly ILogger<EMRDefaultController> logger;
        private readonly IEMRDefaultService masterdataService;
        public EMRDefaultController(ILogger<EMRDefaultController> _logger, IEMRDefaultService _masterdataService)
        {
            logger = _logger;
            masterdataService = _masterdataService;
        }
        [Route("GetConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationEMRModel>> GetConsultation(ConsultationEMRModelAll cmfma)
        {
            try
            {
                List<ConsultationEMRModel> cptList = new List<ConsultationEMRModel>();
                cptList = masterdataService.GetConsultation(cmfma);
                var response = new ResponseDataModel<IEnumerable<ConsultationEMRModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultationEMRModel>>()
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


        [Route("GetBasicPatientDetails")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientBasicModel>> GetBasicPatientDetails(PatientBasicModel cmfma)
        {
            try
            {
                List<PatientBasicModel> cptList = new List<PatientBasicModel>();
                cptList = masterdataService.GetBasicPatientDetails(cmfma);
                var response = new ResponseDataModel<IEnumerable<PatientBasicModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatientBasicModel>>()
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

        [Route("InsertVisit")]
        [HttpPost]
        public ResponseDataModel<VisitModel> InsertVisit(VisitModel visit)
        {
            try
            {
                string message = string.Empty;
                VisitModel vm = new VisitModel();
                vm = masterdataService.InsertVisit(visit);
                if (vm.VisitId > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<VisitModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response= vm,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<VisitModel>()
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

        [Route("InsertUpdateChiefComplaints")]
        [HttpPost]
        public ResponseDataModel<ComplaintsModel> InsertComplaints(ComplaintsModel visit)
        {
            try
            {
                string message = string.Empty;
                ComplaintsModel vm = new ComplaintsModel();
                vm = masterdataService.InsertComplaints(visit);
                //if (vm.VisitId > 0)
                //    message = "Success";
                //else
                //    message = "Failure";
                var response = new ResponseDataModel<ComplaintsModel>()
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
                return new ResponseDataModel<ComplaintsModel>()
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

        [Route("GetChiefComplaints")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ComplaintsModel>> GetChiefComplaints(ComplaintsModel cmfma)
        {
            try
            {
                List<ComplaintsModel> cptList = new List<ComplaintsModel>();
                cptList = masterdataService.GetChiefComplaints(cmfma);
                var response = new ResponseDataModel<IEnumerable<ComplaintsModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ComplaintsModel>>()
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

        [Route("InsertPEDetails")]
        [HttpPost]
        public ResponseDataModel<PhysicalExaminationModel> InsertPEDetails(PhysicalExaminationModel pe)
        {
            try
            {
                string message = string.Empty;
                PhysicalExaminationModel vm = new PhysicalExaminationModel();
                vm = masterdataService.InsertPhysicalExamination(pe);
                if (vm.PEId > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<PhysicalExaminationModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = pe,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<PhysicalExaminationModel>()
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

        [Route("InsertReviewOfSymptoms")]
        [HttpPost]
        public ResponseDataModel<SymptomReviewModel> InsertReviewOfSymptoms(SymptomReviewModel srm)
        {
            try
            {
                string message = string.Empty;
                SymptomReviewModel vm = new SymptomReviewModel();
                vm = masterdataService.InsertReviewOfSymptoms(srm);
                if (vm.SRMId > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<SymptomReviewModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = srm,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<SymptomReviewModel>()
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

        [Route("GetVisitDetails")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<VisitModel>> GetVisitDetails(VisitModel visit) 
        {
            try
            {
                List<VisitModel> visitList = new List<VisitModel>();
                visitList = masterdataService.GetVisitDetails(visit);
                var response = new ResponseDataModel<IEnumerable<VisitModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = visitList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<VisitModel>>()
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
