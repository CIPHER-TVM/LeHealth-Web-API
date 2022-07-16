using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly IEMRDefaultService emrdefaultService;
        public EMRDefaultController(ILogger<EMRDefaultController> _logger, IEMRDefaultService _emrdefaultService)
        {
            logger = _logger;
            emrdefaultService = _emrdefaultService;
        }
        [Route("GetConsultation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultationEMRModel>> GetConsultation(ConsultationEMRModelAll cmfma)
        {
            try
            {
                List<ConsultationEMRModel> cptList = new List<ConsultationEMRModel>();
                cptList = emrdefaultService.GetConsultation(cmfma);
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
                cptList = emrdefaultService.GetBasicPatientDetails(cmfma);
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
                vm = emrdefaultService.InsertVisit(visit);
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
                vm = emrdefaultService.InsertComplaints(visit);
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
                cptList = emrdefaultService.GetChiefComplaints(cmfma);
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
                vm = emrdefaultService.InsertPhysicalExamination(pe);
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
                cptList = emrdefaultService.GetPEDetails(cmfma);
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
                vm = emrdefaultService.InsertReviewOfSymptoms(srm);
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
                cptList = emrdefaultService.GetReviewOfSymptoms(cmfma);
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
                vm = emrdefaultService.InsertMedicalDecision(pe);
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
                cptList = emrdefaultService.GetMedicalDecision(cmfma);
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
                vm = emrdefaultService.InsertPlanAndProcedure(pe);
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
                cptList = emrdefaultService.GetPlanAndProcedure(cmfma);
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
                visitList = emrdefaultService.GetVisitDetails(visit);
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
        //

        [Route("InsertUpdateMenstrualHistory")]
        [HttpPost]
        public ResponseDataModel<MenstrualHistoryModel> InsertMenstrualHistory(MenstrualHistoryModel pe)
        {
            try
            {
                string message = string.Empty;
                MenstrualHistoryModel vm = new MenstrualHistoryModel();
                vm = emrdefaultService.InsertMenstrualHistory(pe);
                if (vm.Mid > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<MenstrualHistoryModel>()
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
                return new ResponseDataModel<MenstrualHistoryModel>()
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


        [Route("GetMenstrualHistory")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<MenstrualHistoryModel>> GetMenstrualHistory(MenstrualHistoryModel mh)
        {
            try
            {
                List<MenstrualHistoryModel> mhList = new List<MenstrualHistoryModel>();
                mhList = emrdefaultService.GetMenstrualHistory(mh);
                var response = new ResponseDataModel<IEnumerable<MenstrualHistoryModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = mhList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MenstrualHistoryModel>>()
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


        [Route("InsertUpdateNarrativeDiagnosisICD")]
        [HttpPost]
        public ResponseDataModel<NarrativeDiagnosisICDModel> InsertNarrativeDiagnosisICD(NarrativeDiagnosisICDModel ndim)
        {
            try
            {
                string message = string.Empty;
                NarrativeDiagnosisICDModel vm = new NarrativeDiagnosisICDModel();
                vm = emrdefaultService.InsertNarrativeDiagnosisICD(ndim);
                if (vm.Nid > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<NarrativeDiagnosisICDModel>()
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
                return new ResponseDataModel<NarrativeDiagnosisICDModel>()
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

        [Route("GetNarrativeDiagnosisICD")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<NarrativeDiagnosisICDModel>> GetNarrativeDiagnosisICD(NarrativeDiagnosisICDModel ndim)
        {
            try
            {
                List<NarrativeDiagnosisICDModel> cptList = new List<NarrativeDiagnosisICDModel>();
                cptList = emrdefaultService.GetNarrativeDiagnosisICD(ndim);
                var response = new ResponseDataModel<IEnumerable<NarrativeDiagnosisICDModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<NarrativeDiagnosisICDModel>>()
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

        [Route("InsertUpdateEMRVitalSign")]
        [HttpPost]
        public ResponseDataModel<VitalSignEMRModel> InsertUpdateEMRVitalSign(VitalSignEMRModel ndim)
        {
            try
            {
                string message = string.Empty;
                VitalSignEMRModel vm = new VitalSignEMRModel();
                vm = emrdefaultService.InsertEMRVitalSign(ndim);
                if (vm.Eid > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<VitalSignEMRModel>()
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
                return new ResponseDataModel<VitalSignEMRModel>()
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

        [Route("GetEMRVitalSign")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<VitalSignEMRData>> GetEMRVitalSign(VitalSignEMRModel ndim)
        {
            try
            {
                List<VitalSignEMRData> emrList = new List<VitalSignEMRData>();
                emrList = emrdefaultService.GetEMRVitalSign(ndim);
                var response = new ResponseDataModel<IEnumerable<VitalSignEMRData>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = emrList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<VitalSignEMRData>>()
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

        [Route("GetEMRVitalSignHistory")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<VitalSignEMRHistory>> GetEMRVitalSignHistory(VitalSignEMRModel ndim)
        {
            try
            {
                List<VitalSignEMRHistory> emrList = new List<VitalSignEMRHistory>();
                emrList = emrdefaultService.GetEMRVitalSignHistory(ndim);
                var response = new ResponseDataModel<IEnumerable<VitalSignEMRHistory>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = emrList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<VitalSignEMRHistory>>()
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
        [Route("GetAllEMRVitalSignByVisitId")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<VitalSignEMRAll>> GetAllEMRVitalSignByVisitId(VitalSignEMRModel ndim)
        {
            try
            {
                List<VitalSignEMRAll> emrList = new List<VitalSignEMRAll>();
                emrList = emrdefaultService.GetAllEMRVitalSignByVisitId(ndim);
                var response = new ResponseDataModel<IEnumerable<VitalSignEMRAll>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = emrList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<VitalSignEMRAll>>()
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

        [Route("GetDrugsAutoComplete")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DrugModelAutoComplete>> GetDrugsAutoComplete(DrugModelAutoComplete dmac)
        {
            try
            {
                List<DrugModelAutoComplete> emrList = new List<DrugModelAutoComplete>();
                emrList = emrdefaultService.GetDrugsAutoComplete(dmac);
                var response = new ResponseDataModel<IEnumerable<DrugModelAutoComplete>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = emrList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DrugModelAutoComplete>>()
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

        [Route("InsertUpdateDrugsEMR")]
        [HttpPost]
        public ResponseDataModel<DrugsEMRModel> InsertUpdateDrugsEMR(DrugsEMRModel dem)
        {
            try
            {
                string message = string.Empty;
                DrugsEMRModel vm = new DrugsEMRModel();
                vm = emrdefaultService.InsertDrugsEMR(dem);
                if (vm.Id > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<DrugsEMRModel>()
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
                return new ResponseDataModel<DrugsEMRModel>()
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

        [Route("GetDrugsEMR")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DrugsEMRModel>> GetDrugsEMR(DrugsEMRModel dmac)
        {
            try
            {
                List<DrugsEMRModel> emrList = new List<DrugsEMRModel>();
                emrList = emrdefaultService.GetDrugsEMR(dmac);
                var response = new ResponseDataModel<IEnumerable<DrugsEMRModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = emrList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DrugsEMRModel>>()
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

        [Route("InsertUpdatePatientHistoryEMR")]
        [HttpPost]
        public ResponseDataModel<PatientHistoryEMRModel> InsertUpdatePatientHistoryEMR(PatientHistoryEMRModel pem)
        {
            try
            {
                string message = string.Empty;
                PatientHistoryEMRModel vm = new PatientHistoryEMRModel();
                vm = emrdefaultService.InsertUpdatePatientHistoryEMR(pem);
                if (vm.Id > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<PatientHistoryEMRModel>()
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
                return new ResponseDataModel<PatientHistoryEMRModel>()
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

        [Route("GetPatientHistoryEMR")]
        [HttpPost]
        public ResponseDataModel<PatientHistoryEMRModel> GetPatientHistoryEMR(PatientHistoryEMRModel dmac)
        {
            try
            {
                PatientHistoryEMRModel emrList = new PatientHistoryEMRModel();
                emrList = emrdefaultService.GetPatientHistoryEMR(dmac);
                if (emrList.Id == 0)
                {
                    emrList = null;
                }
                var response = new ResponseDataModel<PatientHistoryEMRModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = emrList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<PatientHistoryEMRModel>()
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
        [Route("InsertUpdatePatientQuestionareEMR")]
        [HttpPost]
        public ResponseDataModel<PatientQuestionareModelInput> InsertUpdatePatientQuestionareEMR(PatientQuestionareModelInput pem)
        {
            try
            {
                string message = string.Empty;
                PatientQuestionareModelInput vm = new PatientQuestionareModelInput();
                vm = emrdefaultService.InsertUpdatePatientQuestionareEMR(pem);
                message = "Success";
                var response = new ResponseDataModel<PatientQuestionareModelInput>()
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
                return new ResponseDataModel<PatientQuestionareModelInput>()
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

        [Route("GetPatientQuestionareEMR")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientQuestionareModel>> GetPatientQuestionareEMR(PatientQuestionareModel dmac)
        {
            try
            {
                List<PatientQuestionareModel> emrList = new List<PatientQuestionareModel>();
                emrList = emrdefaultService.GetPatientQuestionareEMR(dmac);
                var response = new ResponseDataModel<IEnumerable<PatientQuestionareModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = emrList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatientQuestionareModel>>()
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

        [Route("GetPatientFoldersEMR")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PatientFoldersEMRModel>> GetPatientFoldersEMR(EMRInputModel dmac)
        {
            try
            {
                List<PatientFoldersEMRModel> emrList = new List<PatientFoldersEMRModel>();
                emrList = emrdefaultService.GetPatientFoldersEMR(dmac);
                var response = new ResponseDataModel<IEnumerable<PatientFoldersEMRModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = emrList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatientFoldersEMRModel>>()
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

        [Route("InsertUpdateFolderEMR")]
        [HttpPost]
        public ResponseDataModel<PatientFoldersEMRModel> InsertUpdateFolderEMR(EMRInputModel pem)
        {
            try
            {
                string message = string.Empty;
                PatientFoldersEMRModel vm = new PatientFoldersEMRModel();
                vm = emrdefaultService.InsertUpdateFolderEMR(pem);
                if (vm.Id > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<PatientFoldersEMRModel>()
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
                return new ResponseDataModel<PatientFoldersEMRModel>()
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

        [Route("UploadFileEMR")]
        [HttpPost]
        public ResponseDataModel<EMRFileOutputModel> UploadFileEMR([FromForm] EMRFileSaveRequestModel pem)
        {
            try
            {
                EMRFileOutputModel eom = new EMRFileOutputModel();
                EMRSaveFilesModel patientDetail = JsonConvert.DeserializeObject<EMRSaveFilesModel>(pem.FileJson);
                patientDetail.EMRFiles = pem.PatientDocs;
                EMRSaveFilesModel registrationDetail = emrdefaultService.UploadFileEMR(patientDetail);
                string message = string.Empty;
                //PatientFoldersEMRModel vm = new PatientFoldersEMRModel();
                //vm = emrdefaultService.UploadFileEMR(pem); 
                if (registrationDetail.FolderId > 0)
                {
                    message = "Success";
                    eom.UserId = patientDetail.UserId;
                    eom.FolderId = patientDetail.FolderId;
                    eom.PatientId = patientDetail.PatientId;
                }
                else
                {
                    message = "Failure";
                }
                var response = new ResponseDataModel<EMRFileOutputModel>()
                {
                    Status = HttpStatusCode.OK,
                    Response = eom,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<EMRFileOutputModel>()
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

        [Route("GetEMRServiceItem")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ItemEMR>> GetEMRServiceItem(EMRInputModel dmac)
        {
            try
            {
                List<ItemEMR> emrList = new List<ItemEMR>();
                emrList = emrdefaultService.GetEMRServiceItem(dmac);
                var response = new ResponseDataModel<IEnumerable<ItemEMR>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = emrList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ItemEMR>>()
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

        [Route("InsertServiceItemsEMR")]
        [HttpPost]
        public ResponseDataModel<ItemEMRInputModel> InsertServiceItemsEMR(ItemEMRInputModel dem)
        {
            try
            {
                string message = string.Empty;
                ItemEMRInputModel vm = new ItemEMRInputModel();
                vm = emrdefaultService.InsertServiceItemsEMR(dem);
                if (vm.Id > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<ItemEMRInputModel>()
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
                return new ResponseDataModel<ItemEMRInputModel>()
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

        [Route("GetServiceItemsEMR")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ItemEMRInputModel>> GetServiceItemsEMR(EMRInputModel dmac)
        {
            try
            {
                List<ItemEMRInputModel> emrList = new List<ItemEMRInputModel>();
                emrList = emrdefaultService.GetServiceItemsEMR(dmac);
                var response = new ResponseDataModel<IEnumerable<ItemEMRInputModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = emrList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ItemEMRInputModel>>()
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
        [Route("InsertDentalExamination")]
        [HttpPost]
        public ResponseDataModel<DentalExaminationModel> InsertDentalExamination(DentalExaminationModel ndim)
        {
            try
            {
                string message = string.Empty;
                DentalExaminationModel vm = new DentalExaminationModel();
                vm = emrdefaultService.InsertDentalExamination(ndim);
                if (vm.Id > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<DentalExaminationModel>()
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
                return new ResponseDataModel<DentalExaminationModel>()
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

        [Route("GetDentalExaminationEMR")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DentalExaminationModel>> GetDentalExaminationEMR(EMRInputModel ndim)
        {
            try
            {
                List<DentalExaminationModel> cptList = new List<DentalExaminationModel>();
                cptList = emrdefaultService.GetDentalExaminationEMR(ndim);
                var response = new ResponseDataModel<IEnumerable<DentalExaminationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DentalExaminationModel>>()
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

        [Route("InsertDentalProcedureEMR")]
        [HttpPost]
        public ResponseDataModel<DentalProcedureEMRModel> InsertDentalProcedureEMR(DentalProcedureEMRModel ndim)
        {
            try
            {
                string message = string.Empty;
                DentalProcedureEMRModel vm = new DentalProcedureEMRModel();
                vm = emrdefaultService.InsertDentalProcedureEMR(ndim);
                if (vm.Id > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<DentalProcedureEMRModel>()
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
                return new ResponseDataModel<DentalProcedureEMRModel>()
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

        [Route("GetDentalProcedureEMR")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DentalProcedureEMRModel>> GetDentalProcedureEMR(EMRInputModel ndim)
        {
            try
            {
                List<DentalProcedureEMRModel> cptList = new List<DentalProcedureEMRModel>();
                cptList = emrdefaultService.GetDentalProcedureEMR(ndim);
                var response = new ResponseDataModel<IEnumerable<DentalProcedureEMRModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DentalProcedureEMRModel>>()
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

        [Route("CompleteDentalProcedureEMR")]
        [HttpPost]
        public ResponseDataModel<DentalProcedureEMR> CompleteDentalProcedureEMR(DentalProcedureEMR ndim)
        {
            try
            {
                string message = string.Empty;
                DentalProcedureEMR vm = new DentalProcedureEMR();
                vm = emrdefaultService.CompleteDentalProcedureEMR(ndim);
                if (vm.Id > 0)
                    message = "Success";
                else
                    message = "Failure";
                var response = new ResponseDataModel<DentalProcedureEMR>()
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
                return new ResponseDataModel<DentalProcedureEMR>()
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
