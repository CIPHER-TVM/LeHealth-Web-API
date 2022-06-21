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
                    Response = vm,
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
                if (vm.ComplaintId > 0)
                    message = "Success";
                else
                    message = "Failure";
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

        [Route("InsertUpdatePhysicalExaminationDetails")]
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


        [Route("GetPhysicalExaminationDetails")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PhysicalExaminationModel>> GetPEDetails(PhysicalExaminationModel cmfma)
        {
            try
            {
                List<PhysicalExaminationModel> cptList = new List<PhysicalExaminationModel>();
                cptList = masterdataService.GetPEDetails(cmfma);
                var response = new ResponseDataModel<IEnumerable<PhysicalExaminationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PhysicalExaminationModel>>()
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


        [Route("InsertUpdateReviewOfSymptoms")]
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
        [Route("GetReviewOfSymptoms")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SymptomReviewModel>> GetReviewOfSymptoms(SymptomReviewModel cmfma)
        {
            try
            {
                List<SymptomReviewModel> cptList = new List<SymptomReviewModel>();
                cptList = masterdataService.GetReviewOfSymptoms(cmfma);
                var response = new ResponseDataModel<IEnumerable<SymptomReviewModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SymptomReviewModel>>()
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


        [Route("InsertUpdateMedicalDecision")]
        [HttpPost]
        public ResponseDataModel<MedicalDecisionModel> InsertMedicalDecision(MedicalDecisionModel pe)
        {
            try
            {
                string message = string.Empty;
                MedicalDecisionModel vm = new MedicalDecisionModel();
                vm = masterdataService.InsertMedicalDecision(pe);
                if (vm.MDId > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<MedicalDecisionModel>()
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
                return new ResponseDataModel<MedicalDecisionModel>()
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


        [Route("GetMedicalDecision")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<MedicalDecisionModel>> GetMedicalDecision(MedicalDecisionModel cmfma)
        {
            try
            {
                List<MedicalDecisionModel> cptList = new List<MedicalDecisionModel>();
                cptList = masterdataService.GetMedicalDecision(cmfma);
                var response = new ResponseDataModel<IEnumerable<MedicalDecisionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MedicalDecisionModel>>()
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

        //
        [Route("InsertUpdatePlanAndProcedure")]
        [HttpPost]
        public ResponseDataModel<PlanAndProcedureModel> InsertPlanAndProcedure(PlanAndProcedureModel pe)
        {
            try
            {
                string message = string.Empty;
                PlanAndProcedureModel vm = new PlanAndProcedureModel();
                vm = masterdataService.InsertPlanAndProcedure(pe);
                if (vm.PapId > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<PlanAndProcedureModel>()
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
                return new ResponseDataModel<PlanAndProcedureModel>()
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


        [Route("GetPlanAndProcedure")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PlanAndProcedureModel>> GetPlanAndProcedure(PlanAndProcedureModel cmfma)
        {
            try
            {
                List<PlanAndProcedureModel> cptList = new List<PlanAndProcedureModel>();
                cptList = masterdataService.GetPlanAndProcedure(cmfma);
                var response = new ResponseDataModel<IEnumerable<PlanAndProcedureModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PlanAndProcedureModel>>()
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
        //
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
