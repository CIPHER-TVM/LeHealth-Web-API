﻿using LeHealth.Catalogue.API;
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
                //message = masterdataService.InsertVisit(visit);
                var response = new ResponseDataModel<VisitModel>()
                {
                    Status = HttpStatusCode.OK,
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

    }
}