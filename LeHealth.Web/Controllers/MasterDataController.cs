﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeHealth.Catalogue.API;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Net;
using Newtonsoft.Json;

namespace LeHealth.Base.API.Controllers.FrontOffice
{
    [Route("api/MasterData")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly ILogger<MasterDataController> logger;
        private readonly IMasterDataService masterdataService;
        public MasterDataController(ILogger<MasterDataController> _logger, IMasterDataService _masterdataService)
        {
            logger = _logger;
            masterdataService = _masterdataService;
        }
        [Route("InsertUpdateCommonMasterItem")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> InsertUpdateCommonMasterItem(CommonMasterFieldModelAll MasterItem)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateCommonMasterItem(MasterItem);
                var response = new ResponseDataModel<IEnumerable<string>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<string>>()
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
        [Route("GetCommonMasterItem")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CommonMasterFieldModel>> GetCommonMasterItem(CommonMasterFieldModelAll cmfma)
        {
            try
            {
                List<CommonMasterFieldModel> cptList = new List<CommonMasterFieldModel>();
                cptList = masterdataService.GetCommonMasterItem(cmfma);
                var response = new ResponseDataModel<IEnumerable<CommonMasterFieldModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CommonMasterFieldModel>>()
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

        [Route("InsertUpdateServiceItem")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ServiceItemModel>> InsertUpdateServiceItem(ServiceItemModel ServiceItem)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateServiceItem(ServiceItem);
                var response = new ResponseDataModel<IEnumerable<ServiceItemModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ServiceItemModel>>()
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

        [Route("DeleteServiceItem")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ServiceItemModel>> DeleteServiceItem(ServiceItemModel ServiceItem)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteServiceItem(ServiceItem);
                var response = new ResponseDataModel<IEnumerable<ServiceItemModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ServiceItemModel>>()
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

       

        //[Route("InsertUpdateCPTCode")]
        //[HttpPost]
        //public ResponseDataModel<IEnumerable<CPTCodeModel>> InsertUpdateCPTCode(CPTCodeModelAll CPTCode)
        //{
        //    try
        //    {
        //        string message = string.Empty;
        //        message = masterdataService.InsertUpdateCPTCode(CPTCode);
        //        var response = new ResponseDataModel<IEnumerable<CPTCodeModel>>()
        //        {
        //            Status = HttpStatusCode.OK,
        //            Message = message
        //        };
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
        //        return new ResponseDataModel<IEnumerable<CPTCodeModel>>()
        //        {
        //            Status = HttpStatusCode.InternalServerError,
        //            Response = null,
        //            ErrorMessage = new ErrorResponse()
        //            {
        //                Message = ex.Message
        //            }

        //        };
        //    }
        //    finally
        //    {
        //    }
        //}

        [Route("DeleteCPTCode")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CPTCodeModel>> DeleteCPTCode(CPTCodeModel CPTCode)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteCPTCode(CPTCode);
                var response = new ResponseDataModel<IEnumerable<CPTCodeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CPTCodeModel>>()
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

        [Route("GetCPTModifier")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CPTModifierModel>> GetCPTModifier(CPTModifierAll ccm)
        {
            try
            {
                List<CPTModifierModel> cptList = new List<CPTModifierModel>();
                cptList = masterdataService.GetCPTModifier(ccm);
                var response = new ResponseDataModel<IEnumerable<CPTModifierModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CPTModifierModel>>()
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

        [Route("InsertUpdateCPTModifier")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> InsertUpdateCPTModifier(CPTModifierAll cptm)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateCPTModifier(cptm);
                var response = new ResponseDataModel<IEnumerable<string>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<string>>()
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

        [Route("DeleteCPTModifier")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<string>> DeleteCPTModifier(CPTModifierAll CPTModifier)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteCPTModifier(CPTModifier);
                var response = new ResponseDataModel<IEnumerable<string>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<string>>()
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

        [Route("GetRateGroup")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RateGroupModel>> GetRateGroup(RateGroupModelAll rm)
        {
            try
            {
                List<RateGroupModel> RateGroupList = new List<RateGroupModel>();
                RateGroupList = masterdataService.GetRateGroup(rm);
                var response = new ResponseDataModel<IEnumerable<RateGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = RateGroupList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RateGroupModel>>()
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

        [Route("InsertUpdateRateGroup")]
        [HttpPost]
        public ResponseDataModel<RateGroupModel> InsertUpdateRateGroup(RateGroupModelAll zone)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateRateGroup(zone);
                var response = new ResponseDataModel<RateGroupModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<RateGroupModel>()
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

        [Route("DeleteRateGroup")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RateGroupModel>> DeleteRateGroup(RateGroupModel rm)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteRateGroup(rm);
                var response = new ResponseDataModel<IEnumerable<RateGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RateGroupModel>>()
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

        [Route("GetPackage")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PackageModel>> GetPackage(PackageModelAll pm)
        {
            try
            {
                List<PackageModel> packageList = new List<PackageModel>();
                packageList = masterdataService.GetPackage(pm);
                var response = new ResponseDataModel<IEnumerable<PackageModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = packageList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PackageModel>>()
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

        [Route("InsertUpdatePackage")]
        [HttpPost]
        public ResponseDataModel<PackageModel> InsertUpdatePackage(PackageModelAll la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdatePackage(la);
                var response = new ResponseDataModel<PackageModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<PackageModel>()
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
        [Route("DeletePackage")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PackageModel>> DeletePackage(PackageModel Package)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeletePackage(Package);
                var response = new ResponseDataModel<IEnumerable<PackageModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PackageModel>>()
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
        /// To get list of all Departments Or Departments Detail of Input parameter. 
        /// DeptId=Primary key of LH_Department Table, Returns all if DeptId=0
        /// </summary>
        /// <returns>
        /// returns List of Departments as JSON
        /// </returns>

        [Route("GetDepartment")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DepartmentModel>> GetDepartment(DepartmentModelAll DeptId)
        {
            try
            {
                List<DepartmentModel> departmentList = new List<DepartmentModel>();
                departmentList = masterdataService.GetDepartment(DeptId);
                var response = new ResponseDataModel<IEnumerable<DepartmentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = departmentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DepartmentModel>>()
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
        /// To Save or update department . if DeptId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateDepartment")]
        [HttpPost]
        public ResponseDataModel<DepartmentModel> InsertUpdateDepartment(DepartmentModelAll obj)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateDepartment(obj);
                var response = new ResponseDataModel<DepartmentModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<DepartmentModel>()
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
        /// To Save or update department . if DeptId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("DeleteDepartment")]
        [HttpPost]
        public ResponseDataModel<DepartmentModel> DeleteDepartment(DepartmentModel obj)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteDepartment(obj);
                var response = new ResponseDataModel<DepartmentModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<DepartmentModel>()
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

        [HttpPost]
        [Route("GetSymptom")]
        public ResponseDataModel<IEnumerable<SymptomModel>> GetSymptom(SymptomModelAll sm)
        {
            try
            {
                List<SymptomModel> activeSymptomsList = new List<SymptomModel>();
                activeSymptomsList = masterdataService.GetSymptom(sm);
                var response = new ResponseDataModel<IEnumerable<SymptomModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = activeSymptomsList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SymptomModel>>()
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
        //[Route("InsertUpdateSymptom")]
        //[HttpPost]
        //public ResponseDataModel<SymptomModel> InsertUpdateSymptom(SymptomModelAll Symptom)
        //{
        //    try
        //    {
        //        string message = string.Empty;
        //        message = masterdataService.InsertUpdateSymptom(Symptom);
        //        var response = new ResponseDataModel<SymptomModel>()
        //        {
        //            Status = HttpStatusCode.OK,
        //            Message = message
        //        };
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
        //        return new ResponseDataModel<SymptomModel>()
        //        {
        //            Status = HttpStatusCode.InternalServerError,
        //            Response = null,
        //            ErrorMessage = new ErrorResponse()
        //            {
        //                Message = ex.Message
        //            }
        //        };
        //    }
        //    finally
        //    {
        //    }
        //}
        [Route("DeleteSymptom")]
        [HttpPost]
        public ResponseDataModel<SymptomModel> DeleteSymptom(SymptomModel Symptom)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteSymptom(Symptom);
                var response = new ResponseDataModel<SymptomModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<SymptomModel>()
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

        [Route("GetLocation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LocationModel>> GetLocation(LocationAll location)
        {
            try
            {
                List<LocationModel> locationList = new List<LocationModel>();
                locationList = masterdataService.GetLocation(location);
                var response = new ResponseDataModel<IEnumerable<LocationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = locationList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LocationModel>>()
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

        [Route("InsertUpdateLocation")]
        [HttpPost]
        public ResponseDataModel<LocationModel> InsertUpdateLocation(LocationAll la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateLocation(la);
                var response = new ResponseDataModel<LocationModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<LocationModel>()
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
        [Route("DeleteLocation")]
        [HttpPost]
        public ResponseDataModel<LocationModel> DeleteLocation(LocationModel la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteLocation(la);
                var response = new ResponseDataModel<LocationModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<LocationModel>()
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
        /// To get list of all Country Or Country Detail of Input parameter. 
        /// id=Primary key of LH_Country Table, Returns all if id=0
        /// </summary>
        /// <returns>
        /// returns List of Country as JSON
        /// </returns>
        [HttpPost]
        [Route("GetCountry")]
        public ResponseDataModel<IEnumerable<CountryModel>> GetCountry(CountryModel country)
        {
            try
            {
                List<CountryModel> countryList = new List<CountryModel>();
                countryList = masterdataService.GetCountry(country);
                var response = new ResponseDataModel<IEnumerable<CountryModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = countryList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CountryModel>>()
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
        /// To Save or update country . if CountryId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateCountry")]
        [HttpPost]
        public ResponseDataModel<CountryModel> InsertUpdateCountry(CountryModel Country)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateCountry(Country);
                var response = new ResponseDataModel<CountryModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<CountryModel>()
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

        [Route("DeleteCountry")]
        [HttpPost]
        public ResponseDataModel<CountryModel> DeleteCountry(CountryModel Country)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteCountry(Country);
                var response = new ResponseDataModel<CountryModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<CountryModel>()
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
        //State Management Starts
        /// <summary>
        /// To get list of all State Or State Detail of Input parameter. 
        /// id=Primary key of LH_State Table, Returns all if id=0
        /// </summary>
        /// <returns>
        /// returns List of State as JSON
        /// </returns>
        [HttpPost]
        [Route("GetState")]
        public ResponseDataModel<IEnumerable<StateModel>> GetState(StateModel state)
        {
            try
            {
                List<StateModel> stateList = new List<StateModel>();
                stateList = masterdataService.GetState(state);
                var response = new ResponseDataModel<IEnumerable<StateModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = stateList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<StateModel>>()
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
        /// To Save or update country . if CountryId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateState")]
        [HttpPost]
        public ResponseDataModel<StateModel> InsertUpdateState(StateModel State)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateState(State);
                var response = new ResponseDataModel<StateModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<StateModel>()
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
        /// To Save or update country . if CountryId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("DeleteState")]
        [HttpPost]
        public ResponseDataModel<StateModel> DeleteState(StateModel State)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteState(State);
                var response = new ResponseDataModel<StateModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<StateModel>()
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

        //[Route("InsertUpdateCompany")]
        //[HttpPost]
        //public ResponseDataModel<CompanyModel> InsertUpdateCompany(CompanyModelAll cmp)
        //{
        //    try
        //    {
        //        string message = string.Empty;
        //        message = masterdataService.InsertUpdateCompany(cmp);
        //        var response = new ResponseDataModel<CompanyModel>()
        //        {
        //            Status = HttpStatusCode.OK,
        //            Message = message
        //        };
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
        //        return new ResponseDataModel<CompanyModel>()
        //        {
        //            Status = HttpStatusCode.InternalServerError,
        //            Response = null,
        //            ErrorMessage = new ErrorResponse()
        //            {
        //                Message = ex.Message
        //            }
        //        };
        //    }
        //    finally
        //    {
        //    }
        //}

        [Route("DeleteCompany")]
        [HttpPost]
        public ResponseDataModel<CompanyModel> DeleteCompany(CompanyModel cmp)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteCompany(cmp);
                var response = new ResponseDataModel<CompanyModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<CompanyModel>()
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
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// profid=Primary key of LH_Profession Table, Returns all if profid=0
        /// </summary>
        /// <returns>
        /// returns List of Professions as JSON
        /// </returns>
        [Route("GetProfession")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ProfessionModel>> GetProfession(ProfessionModelAll profid)
        {
            try
            {
                List<ProfessionModel> professionList = new List<ProfessionModel>();
                professionList = masterdataService.GetProfession(profid);
                var response = new ResponseDataModel<IEnumerable<ProfessionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ProfessionModel>>()
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
        /// To Save or update profession . if ProfId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        //[Route("InsertUpdateProfession")]
        //[HttpPost]
        //public ResponseDataModel<IEnumerable<ProfessionModel>> InsertUpdateProfession(ProfessionModelAll Profession)
        //{
        //    try
        //    {
        //        string message = string.Empty;
        //        message = masterdataService.InsertUpdateProfession(Profession);
        //        var response = new ResponseDataModel<IEnumerable<ProfessionModel>>()
        //        {
        //            Status = HttpStatusCode.OK,
        //            Message = message
        //        };
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
        //        return new ResponseDataModel<IEnumerable<ProfessionModel>>()
        //        {
        //            Status = HttpStatusCode.InternalServerError,
        //            Response = null,
        //            ErrorMessage = new ErrorResponse()
        //            {
        //                Message = ex.Message
        //            }

        //        };
        //    }
        //    finally
        //    {
        //    }
        //}

        [Route("DeleteProfession")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ProfessionModel>> DeleteProfession(ProfessionModel Profession)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteProfession(Profession);
                var response = new ResponseDataModel<IEnumerable<ProfessionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ProfessionModel>>()
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
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetCity")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<CityModel>> GetCity(CityModelAll city)
        {
            try
            {
                List<CityModel> cityList = new List<CityModel>();
                cityList = masterdataService.GetCity(city);
                var response = new ResponseDataModel<IEnumerable<CityModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cityList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CityModel>>()
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
        /// To Save or update profession . if ProfId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateCity")]
        [HttpPost]
        public ResponseDataModel<CityModel> InsertUpdateCity(CityModelAll City)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateCity(City);
                var response = new ResponseDataModel<CityModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<CityModel>()
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
        /// To Save or update profession . if ProfId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("DeleteCity")]
        [HttpPost]
        public ResponseDataModel<CityModel> DeleteCity(CityModel City)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteCity(City);
                var response = new ResponseDataModel<CityModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<CityModel>()
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
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetVitalSign")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<VitalSignModel>> GetVitalSign(VitalSignModelAll vitalSign)
        {
            try
            {
                List<VitalSignModel> vitalSignList = new List<VitalSignModel>();
                vitalSignList = masterdataService.GetVitalSign(vitalSign);
                var response = new ResponseDataModel<IEnumerable<VitalSignModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = vitalSignList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<VitalSignModel>>()
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
        /// To Save or update vital sign . if ProfId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateVitalSign")]
        [HttpPost]
        public ResponseDataModel<VitalSignModel> InsertUpdateVitalSign(VitalSignModelAll vitalSign)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateVitalSign(vitalSign);
                var response = new ResponseDataModel<VitalSignModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<VitalSignModel>()
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
        [Route("DeleteVitalSign")]
        [HttpPost]
        public ResponseDataModel<VitalSignModel> DeleteVitalSign(VitalSignModelAll vitalSign)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteVitalSign(vitalSign);
                var response = new ResponseDataModel<VitalSignModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<VitalSignModel>()
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
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetLedgerHead")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LedgerHeadModel>> GetLedgerHead(LedgerHeadModelAll ledgerhead)
        {
            try
            {
                List<LedgerHeadModel> vitalSignList = new List<LedgerHeadModel>();
                vitalSignList = masterdataService.GetLedgerHead(ledgerhead);
                var response = new ResponseDataModel<IEnumerable<LedgerHeadModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = vitalSignList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LedgerHeadModel>>()
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
        /// To Save or update vital sign . if ProfId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateLedgerHead")]
        [HttpPost]
        public ResponseDataModel<LedgerHeadModel> InsertUpdateLedgerHead(LedgerHeadModelAll ledgerhead)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateLedgerHead(ledgerhead);
                var response = new ResponseDataModel<LedgerHeadModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<LedgerHeadModel>()
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

        [Route("DeleteLedgerHead")]
        [HttpPost]
        public ResponseDataModel<LedgerHeadModel> DeleteLedgerHead(LedgerHeadModelAll ledgerHead)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteLedgerHead(ledgerHead);
                var response = new ResponseDataModel<LedgerHeadModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<LedgerHeadModel>()
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
        /// To get list of all State Or State Detail of Input parameter. 
        /// id=Primary key of LH_State Table, Returns all if id=0
        /// </summary>
        /// <returns>
        /// returns List of State as JSON
        /// </returns>
        [HttpPost]
        [Route("GetBodyPart")]
        public ResponseDataModel<IEnumerable<BodyPartModelReturn>> GetBodyPart(BodyPartModel bodypart)
        {
            try
            {
                List<BodyPartModelReturn> bodypartList = new List<BodyPartModelReturn>();
                bodypartList = masterdataService.GetBodyPart(bodypart);
                var response = new ResponseDataModel<IEnumerable<BodyPartModelReturn>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = bodypartList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<BodyPartModelReturn>>()
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
        /// To Save or update country . if CountryId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateBodyPart")]
        [HttpPost]
        public ResponseDataModel<string> InsertUpdateBodyPart([FromForm] BodyPartRequestModel obj)
        {
            try
            {
                string message = string.Empty;
                BodyPartRegModel bodypartDetail = JsonConvert.DeserializeObject<BodyPartRegModel>(obj.BodyPartJson);
                bodypartDetail.BodyPartImgFile = obj.BodyPartImg;
                message = masterdataService.InsertUpdateBodyPart(bodypartDetail);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("DeleteBodyPart")]
        [HttpPost]
        public ResponseDataModel<string> DeleteBodyPart(BodyPartModel bodypart)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteBodyPart(bodypart);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("GetSketchIndicators")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SketchIndicatorModel>> GetSketchIndicators(SketchIndicatorModelAll sketch)
        {
            try
            {
                List<SketchIndicatorModel> sketchIndicators = new List<SketchIndicatorModel>();
                sketchIndicators = masterdataService.GetSketchIndicators(sketch);
                var response = new ResponseDataModel<IEnumerable<SketchIndicatorModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sketchIndicators
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SketchIndicatorModel>>()
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
        [Route("InsertUpdateSketchIndicator")]
        [HttpPost]
        public ResponseDataModel<string> InsertUpdateSketchIndicator([FromForm] SketchIndicatorRequestModel obj)
        {
            try
            {
                string message = string.Empty;
                SketchIndicatorRegModel sketchDetail = JsonConvert.DeserializeObject<SketchIndicatorRegModel>(obj.SketchIndicatorJson);
                sketchDetail.IndicatorFile = obj.Indicator;
                message = masterdataService.InsertUpdateSketchIndicator(sketchDetail);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("DeleteSketchIndicator")]
        [HttpPost]
        public ResponseDataModel<string> DeleteSketchIndicator(SketchIndicatorModelAll sketchIndicator)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteSketchIndicator(sketchIndicator);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("GetRegScheme")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RegSchemeModel>> GetRegScheme(RegSchemeModelAll schemeId)
        {
            try
            {
                List<RegSchemeModel> regSchemeList = new List<RegSchemeModel>();
                regSchemeList = masterdataService.GetRegScheme(schemeId);
                var response = new ResponseDataModel<IEnumerable<RegSchemeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = regSchemeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RegSchemeModel>>()
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
        /// To get list of all State Or State Detail of Input parameter. 
        /// id=Primary key of LH_State Table, Returns all if id=0
        /// </summary>
        /// <returns>
        /// returns List of State as JSON
        /// </returns>
        [HttpPost]
        [Route("GetSalutation")]
        public ResponseDataModel<IEnumerable<SalutationModel>> GetSalutation(SalutationModelAll salutation)
        {
            try
            {
                List<SalutationModel> salutationList = new List<SalutationModel>();
                salutationList = masterdataService.GetSalutation(salutation);
                var response = new ResponseDataModel<IEnumerable<SalutationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = salutationList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SalutationModel>>()
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
        /// To Save or update country . if CountryId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        //[Route("InsertUpdateSalutation")]
        //[HttpPost]
        //public ResponseDataModel<SalutationModel> InsertUpdateSalutation(SalutationModelAll salutation)
        //{
        //    try
        //    {
        //        string message = string.Empty;
        //        message = masterdataService.InsertUpdateSalutation(salutation);
        //        var response = new ResponseDataModel<SalutationModel>()
        //        {
        //            Status = HttpStatusCode.OK,
        //            Message = message
        //        };
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
        //        return new ResponseDataModel<SalutationModel>()
        //        {
        //            Status = HttpStatusCode.InternalServerError,
        //            Response = null,
        //            ErrorMessage = new ErrorResponse()
        //            {
        //                Message = ex.Message
        //            }
        //        };
        //    }
        //    finally
        //    {
        //    }
        //}
        [Route("DeleteSalutation")]
        [HttpPost]
        public ResponseDataModel<SalutationModel> DeleteSalutation(SalutationModelAll salutation)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteSalutation(salutation);
                var response = new ResponseDataModel<SalutationModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<SalutationModel>()
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

        [HttpPost]
        [Route("GetMaritalStatus")]
        public ResponseDataModel<IEnumerable<MaritalStatusModel>> GetMaritalStatus(MaritalStatusModelAll msma)
        {
            try
            {
                List<MaritalStatusModel> maritalStatusList = new List<MaritalStatusModel>();
                maritalStatusList = masterdataService.GetMaritalStatus(msma);
                var response = new ResponseDataModel<IEnumerable<MaritalStatusModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = maritalStatusList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MaritalStatusModel>>()
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
        [Route("InsertUpdateMaritalStatus")]
        [HttpPost]
        public ResponseDataModel<string> InsertUpdateMaritalStatus(MaritalStatusModelAll maritalstatus)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateMaritalStatus(maritalstatus);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("DeleteMaritalStatus")]
        [HttpPost]
        public ResponseDataModel<string> DeleteMaritalStatus(MaritalStatusModelAll maritalStatus)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteMaritalStatus(maritalStatus);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [HttpPost]
        [Route("GetCommunicationType")]
        public ResponseDataModel<IEnumerable<CommunicationTypeModel>> GetCommunicationType(CommunicationTypeModelAll ctype)
        {
            try
            {
                List<CommunicationTypeModel> communicationTypeList = new List<CommunicationTypeModel>();
                communicationTypeList = masterdataService.GetCommunicationType(ctype);
                var response = new ResponseDataModel<IEnumerable<CommunicationTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = communicationTypeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CommunicationTypeModel>>()
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
        [Route("InsertUpdateCommunicationType")]
        [HttpPost]
        public ResponseDataModel<string> InsertUpdateCommunicationType(CommunicationTypeModelAll ctype)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateCommunicationType(ctype);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("DeleteCommunicationType")]
        [HttpPost]
        public ResponseDataModel<string> DeleteCommunicationType(CommunicationTypeModelAll ctype)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteCommunicationType(ctype);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("GetVisaType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<VisaTypeModel>> GetVisaType(VisaTypeModelAll visatype)
        {
            try
            {
                List<VisaTypeModel> visaTypeList = new List<VisaTypeModel>();
                visaTypeList = masterdataService.GetVisaType(visatype);
                var response = new ResponseDataModel<IEnumerable<VisaTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = visaTypeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<VisaTypeModel>>()
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
        [Route("InsertUpdateVisaType")]
        [HttpPost]
        public ResponseDataModel<string> InsertUpdateVisaType(VisaTypeModelAll visatype)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateVisaType(visatype);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("DeleteVisaType")]
        [HttpPost]
        public ResponseDataModel<string> DeleteVisaType(VisaTypeModelAll visatype)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteVisaType(visatype);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("GetReligion")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ReligionModel>> GetReligion(ReligionModelAll religion)
        {
            try
            {
                List<ReligionModel> religionList = new List<ReligionModel>();
                religionList = masterdataService.GetReligion(religion);
                var response = new ResponseDataModel<IEnumerable<ReligionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = religionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ReligionModel>>()
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

        [Route("InsertUpdateReligion")]
        [HttpPost]
        public ResponseDataModel<string> InsertUpdateReligion(ReligionModelAll religion)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateReligion(religion);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("DeleteReligion")]
        [HttpPost]
        public ResponseDataModel<string> DeleteReligion(ReligionModelAll religion)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteReligion(religion);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("GetLeadAgent")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LeadAgentModel>> GetLeadAgent(LeadAgentModelAll la)
        {
            try
            {
                List<LeadAgentModel> leadAgentList = new List<LeadAgentModel>();
                leadAgentList = masterdataService.GetLeadAgent(la);
                var response = new ResponseDataModel<IEnumerable<LeadAgentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = leadAgentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<LeadAgentModel>>()
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

        [Route("InsertUpdateLeadAgent")]
        [HttpPost]
        public ResponseDataModel<string> InsertUpdateLeadAgent(LeadAgentModelAll la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateLeadAgent(la);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("DeleteLeadAgent")]
        [HttpPost]
        public ResponseDataModel<string> DeleteLeadAgent(LeadAgentModelAll la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteLeadAgent(la);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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
        [Route("GetTax")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<TaxModel>> GetTax(TaxModelAll tax)
        {
            try
            {
                List<TaxModel> cptList = new List<TaxModel>();
                cptList = masterdataService.GetTax(tax);
                var response = new ResponseDataModel<IEnumerable<TaxModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = cptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<TaxModel>>()
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
        [Route("InsertUpdateTax")]
        [HttpPost]
        public ResponseDataModel<string> InsertUpdateTax(TaxModelAll la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateTax(la);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("DeleteTax")]
        [HttpPost]
        public ResponseDataModel<string> DeleteTax(TaxModelAll la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteTax(la);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        ////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetConsultant")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantMasterModel>> GetConsultant(ConsultantMasterModel consultant)
        {
            try
            {
                List<ConsultantMasterModel> consultantList = new List<ConsultantMasterModel>();
                consultantList = masterdataService.GetConsultant(consultant);
                var response = new ResponseDataModel<IEnumerable<ConsultantMasterModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantMasterModel>>()
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

        [Route("DeleteConsultant")]
        [HttpPost]
        public ResponseDataModel<string> DeleteConsultant(ConsultantMasterModel consultant)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteConsultant(consultant);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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


        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //END
        [Route("GetGender")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<GenderModel>> GetGender()
        {
            try
            {
                List<GenderModel> genderList = new List<GenderModel>();
                genderList = masterdataService.GetGender();
                var response = new ResponseDataModel<IEnumerable<GenderModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = genderList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<GenderModel>>()
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

        [Route("GetKinRelation")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<KinRelationModel>> GetKinRelation()
        {
            try
            {
                List<KinRelationModel> kinRelationList = new List<KinRelationModel>();
                kinRelationList = masterdataService.GetKinRelation();
                var response = new ResponseDataModel<IEnumerable<KinRelationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = kinRelationList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<KinRelationModel>>()
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

        [Route("InsertUpdateMenuGroupMap")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<MenuGroupModel>> InsertUpdateMenuGroupMap(MenuGroupModel mgm)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateMenuGroupMap(mgm);
                var response = new ResponseDataModel<IEnumerable<MenuGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MenuGroupModel>>()
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


        //Sponsor Management starts
        /// <summary>
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetSponsor")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SponsorMasterModel>> GetSponsor(SponsorMasterModelAll sponsor)
        {
            try
            {
                List<SponsorMasterModel> professionList = new List<SponsorMasterModel>();
                professionList = masterdataService.GetSponsor(sponsor);
                var response = new ResponseDataModel<IEnumerable<SponsorMasterModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorMasterModel>>()
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
        /// To Save or update profession . if ProfId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateSponsor")]
        [HttpPost]
        public ResponseDataModel<string> InsertUpdateSponsor(SponsorMasterModelAll Sponsor)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateSponsor(Sponsor);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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

        [Route("DeleteSponsor")]
        [HttpPost]
        public ResponseDataModel<string> DeleteSponsor(SponsorMasterModelAll Sponsor)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.DeleteSponsor(Sponsor);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<string>()
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


        //Sponsor management ends


        //Sponsor Type Management starts
        /// <summary>
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetSponsorType/{sponsortypeid}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SponsorTypeModel>> GetSponsorType(Int32 sponsortypeid)
        {
            try
            {
                List<SponsorTypeModel> professionList = new List<SponsorTypeModel>();
                professionList = masterdataService.GetSponsorType(sponsortypeid);
                var response = new ResponseDataModel<IEnumerable<SponsorTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorTypeModel>>()
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
        /// To Save or update profession . if ProfId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateSponsorType")]
        [HttpPost]
        public ResponseDataModel<SponsorTypeModel> InsertUpdateSponsorType(SponsorTypeModel Sponsor)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateSponsorType(Sponsor);
                var response = new ResponseDataModel<SponsorTypeModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<SponsorTypeModel>()
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

        //Sponsor Type management ends

        //Sponsor Form Management starts
        /// <summary>
        /// To get list of all Professions Or Profession Detail of Input parameter. 
        /// sponsorid=Primary key of LH_Sponsor Table, Returns all if sponsorid=0
        /// </summary>
        /// <returns>
        /// returns List of Sponsor as JSON
        /// </returns>
        [Route("GetSponsorForm/{sponsorformid}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<SponsorFormModel>> GetSponsorForm(Int32 sponsorformid)
        {
            try
            {
                List<SponsorFormModel> sponsorFormList = new List<SponsorFormModel>();
                sponsorFormList = masterdataService.GetSponsorForm(sponsorformid);
                var response = new ResponseDataModel<IEnumerable<SponsorFormModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sponsorFormList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<SponsorFormModel>>()
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
        /// To Save or update profession . if ProfId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateSponsorForm")]
        [HttpPost]
        public ResponseDataModel<SponsorFormModel> InsertUpdateSponsorForm(SponsorFormModel Sponsor)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateSponsorForm(Sponsor);
                var response = new ResponseDataModel<SponsorFormModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<SponsorFormModel>()
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


        //Consent Management starts

        /// <summary>
        /// To get list of all consents and some patient details to display in consent print form
        /// PatientId=Primary key of LH_Patient Table
        /// </summary>
        /// <returns>
        /// returns List of Consent content,Patient detail as JSON
        /// </returns>
        [Route("GetConsentPreviewContent")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsentPreviewModel>> GetConsentPreviewConsent(ConsentPreviewModel consentDetails)
        {
            try
            {
                List<ConsentPreviewModel> consentcontentList = new List<ConsentPreviewModel>();
                consentcontentList = masterdataService.GetConsentPreviewConsent(consentDetails.PatientId);
                var response = new ResponseDataModel<IEnumerable<ConsentPreviewModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consentcontentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsentPreviewModel>>()
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
        /// To get list of all Consent content Or Consent content Detail of Input parameter. 
        /// profid=Primary key of LH_PatConsent Table, Returns all if consentId=0
        /// </summary>
        /// <returns>
        /// returns List of ConsentContent as JSON
        /// </returns>
        [Route("GetConsent/{ConsentId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsentContentModel>> GetConsent(Int32 consentId)
        {
            try
            {
                List<ConsentContentModel> consentList = new List<ConsentContentModel>();
                consentList = masterdataService.GetConsent(consentId);
                var response = new ResponseDataModel<IEnumerable<ConsentContentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsentContentModel>>()
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
        /// To Save or update Consent Content . if ContentId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>

        [Route("InsertUpdateConsent")]
        [HttpPost]
        public ResponseDataModel<ConsentContentModel> InsertUpdateConsent(ConsentContentModel Consent)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateConsent(Consent);
                var response = new ResponseDataModel<ConsentContentModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<ConsentContentModel>()
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

        //Consent Management ends


        //Hospital Management Starts
        /// <summary>
        /// To get list of hospitals . A controller class. Step One in code execution flow
        /// branches=hospitals
        /// </summary>
        /// <returns>
        /// returns List of Hospitals as JSON
        /// </returns>

        [Route("GetUserHospitals/{id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<HospitalModel>> GetUserHospitals(Int32 id)
        {
            try
            {
                var hospitals = masterdataService.GetUserHospitals(id);
                var response = new ResponseDataModel<IEnumerable<HospitalModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = hospitals,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "HospitalsController", "GetUserHospitals()");

                return new ResponseDataModel<IEnumerable<HospitalModel>>()
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
        [Route("GetUserSpecificHospitals/{UserId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<HospitalModel>> GetUserSpecificHospitals(Int32 UserId)
        {
            try
            {
                List<HospitalModel> hospitals = masterdataService.GetUserSpecificHospitals(UserId);
                var response = new ResponseDataModel<IEnumerable<HospitalModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = hospitals,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "HospitalsController", "GetUserHospitals()");

                return new ResponseDataModel<IEnumerable<HospitalModel>>()
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
        [Route("GetUserSpecificHospitalLocations/{UserId}/{Branch}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<LocationModel>> GetUserSpecificHospitalLocations(Int32 UserId, Int32 Branch)
        {
            try
            {
                List<LocationModel> hospitals = masterdataService.GetUserSpecificHospitalLocations(UserId, Branch);
                var response = new ResponseDataModel<IEnumerable<LocationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = hospitals,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "HospitalsController", "GetUserSpecificHospitalLocations()");

                return new ResponseDataModel<IEnumerable<LocationModel>>()
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


        /// <summary>
        /// To Save or update Hospital . if HospitalId=0 saves data ,else update data
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateUserHospital")]
        [HttpPost]
        public ResponseDataModel<HospitalModel> InsertUpdateHospital([FromForm] HospitalRequestModel obj)
        {
            try
            {
                string message = string.Empty;
                HospitalRegModel hospitalDetail = JsonConvert.DeserializeObject<HospitalRegModel>(obj.HospitalJson);
                hospitalDetail.LogoFile = obj.Logo;
                hospitalDetail.ReportLogoFile = obj.ReportLogo;
                message = masterdataService.InsertUpdateUserHospitals(hospitalDetail);
                var response = new ResponseDataModel<HospitalModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<HospitalModel>()
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



        //Hospital Management Ends
        [Route("ConsentFormDataSave")]
        [HttpPost]
        public ResponseDataModel<ConsentFormDataSaveModel> ConsentFormDataSave([FromForm] ConsentFormSaveRequestModel obj)
        {
            try
            {
                string message = string.Empty;
                ConsentFormRegModel hospitalDetail = JsonConvert.DeserializeObject<ConsentFormRegModel>(obj.ConsentJson);
                hospitalDetail.SignFile = obj.Sign;
                message = masterdataService.ConsentFormDataSave(hospitalDetail);
                var response = new ResponseDataModel<ConsentFormDataSaveModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<ConsentFormDataSaveModel>()
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
        /// To get list of all Departments Or Departments Detail of Input parameter. 
        /// DeptId=Primary key of LH_Department Table, Returns all if DeptId=0
        /// </summary>
        /// <returns>
        /// returns List of Departments as JSON
        /// </returns>
        //[Route("GetDepartmentByHospital/{HospId}")]
        //[HttpPost]
        //public ResponseDataModel<IEnumerable<DepartmentModel>> GetDepartmentByHospital(Int32 HospId)
        //{
        //    try
        //    {
        //        List<DepartmentModel> departmentList = new List<DepartmentModel>();
        //        departmentList = masterdataService.GetDepartmentByHospital(HospId);
        //        var response = new ResponseDataModel<IEnumerable<DepartmentModel>>()
        //        {
        //            Status = HttpStatusCode.OK,
        //            Response = departmentList
        //        };
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
        //        return new ResponseDataModel<IEnumerable<DepartmentModel>>()
        //        {
        //            Status = HttpStatusCode.InternalServerError,
        //            Response = null,
        //            ErrorMessage = new ErrorResponse()
        //            {
        //                Message = ex.Message
        //            }

        //        };
        //    }
        //    finally
        //    {
        //    }
        //}

        [Route("GetConsultantByHospital")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantModel>> GetConsultantByHospital(ConsultantModel cmodel)
        {
            try
            {
                List<ConsultantModel> consultantList = new List<ConsultantModel>();
                consultantList = masterdataService.GetConsultantByHospital(cmodel);
                var response = new ResponseDataModel<IEnumerable<ConsultantModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consultantList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantModel>>()
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
        /// To get list of Zone Detail of Input parameter. 
        /// profid=Primary key of LH_Zone Table, Returns all if zoneId=0
        /// </summary>
        /// <returns>
        /// returns List of Zone as JSON
        /// </returns>
        [Route("GetDrugs")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsultantDrugModel>> GetDrugs(ConsultantDrugModel cm)
        {
            try
            {
                List<ConsultantDrugModel> drugList = new List<ConsultantDrugModel>();
                drugList = masterdataService.GetDrugs(cm);
                var response = new ResponseDataModel<IEnumerable<ConsultantDrugModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = drugList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsultantDrugModel>>()
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

        [Route("GetDosage")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<DosageModel>> GetDosage(DosageModel dm)
        {
            try
            {
                List<DosageModel> dosageList = new List<DosageModel>();
                dosageList = masterdataService.GetDosage(dm);
                var response = new ResponseDataModel<IEnumerable<DosageModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = dosageList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<DosageModel>>()
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
        [Route("GetRoute")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<RouteModel>> GetRoute(RouteModel rm)
        {
            try
            {
                List<RouteModel> routeList = new List<RouteModel>();
                routeList = masterdataService.GetRoute(rm);
                var response = new ResponseDataModel<IEnumerable<RouteModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = routeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<RouteModel>>()
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
        [Route("GetPendingServiceItemsByPatient")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<PendingItemModel>> GetPendingServiceItemsByPatient(PendingItemInputData rm)
        {
            try
            {
                List<PendingItemModel> routeList = new List<PendingItemModel>();
                routeList = masterdataService.GetPendingServiceItemsByPatient(rm);
                var response = new ResponseDataModel<IEnumerable<PendingItemModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = routeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PendingItemModel>>()
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
        //Zone Management Start
        /// <summary>
        /// To get list of Zone Detail of Input parameter. 
        /// profid=Primary key of LH_Zone Table, Returns all if zoneId=0
        /// </summary>
        /// <returns>
        /// returns List of Zone as JSON
        /// </returns>
        [Route("GetZone/{zoneId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ZoneModel>> GetZone(Int32 zoneId)
        {
            try
            {
                List<ZoneModel> zoneList = new List<ZoneModel>();
                zoneList = masterdataService.GetZone(zoneId);
                var response = new ResponseDataModel<IEnumerable<ZoneModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = zoneList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ZoneModel>>()
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
        /// To Save zone 
        /// </summary>
        /// <returns>
        /// returns success or reason of failure
        /// </returns>
        [Route("InsertUpdateZone")]
        [HttpPost]
        public ResponseDataModel<ZoneModel> InsertUpdateZone(ZoneModel zone)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateZone(zone);
                var response = new ResponseDataModel<ZoneModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<ZoneModel>()
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



        //RegSchemes CRUD STARTS


        //CRUD RateGroup


        //Operator CRUD

        [Route("GetOperator/{operatorId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<OperatorModel>> GetOperator(Int32 operatorId)
        {
            try
            {
                List<OperatorModel> zoneList = new List<OperatorModel>();
                zoneList = masterdataService.GetOperator(operatorId);
                var response = new ResponseDataModel<IEnumerable<OperatorModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = zoneList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by given Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<OperatorModel>>()
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



        [Route("InsertUpdateOperator")]
        [HttpPost]
        public ResponseDataModel<OperatorModel> InsertUpdateOperator(OperatorModel zone)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateOperator(zone);
                var response = new ResponseDataModel<OperatorModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<OperatorModel>()
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

        [Route("GetMovement/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<MovementModel>> GetMovement(Int32 Id)
        {
            try
            {
                List<MovementModel> movementList = new List<MovementModel>();
                movementList = masterdataService.GetMovement(Id);
                var response = new ResponseDataModel<IEnumerable<MovementModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = movementList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<MovementModel>>()
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

        [Route("InsertUpdateMovement")]
        [HttpPost]
        public ResponseDataModel<MovementModel> InsertUpdateMovement(MovementModel la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateMovement(la);
                var response = new ResponseDataModel<MovementModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<MovementModel>()
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

        [Route("GetScientificName/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ScientificNameModel>> GetScientificName(Int32 Id)
        {
            try
            {
                List<ScientificNameModel> scientificNameList = new List<ScientificNameModel>();
                scientificNameList = masterdataService.GetScientificName(Id);
                var response = new ResponseDataModel<IEnumerable<ScientificNameModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = scientificNameList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ScientificNameModel>>()
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

        [Route("InsertUpdateScientificName")]
        [HttpPost]
        public ResponseDataModel<ScientificNameModel> InsertUpdateScientificName(ScientificNameModel la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateScientificName(la);
                var response = new ResponseDataModel<ScientificNameModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<ScientificNameModel>()
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

        [Route("GetTendern/{Id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<TendernModel>> GetTendern(Int32 Id)
        {
            try
            {
                List<TendernModel> tendernessList = new List<TendernModel>();
                tendernessList = masterdataService.GetTendern(Id);
                var response = new ResponseDataModel<IEnumerable<TendernModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = tendernessList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<TendernModel>>()
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

        [Route("InsertUpdateTendern")]
        [HttpPost]
        public ResponseDataModel<TendernModel> InsertUpdateTendern(TendernModel la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateTendern(la);
                var response = new ResponseDataModel<TendernModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<TendernModel>()
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

        [Route("GetFormMaster")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<FormValidationModel>> GetFormMaster()
        {
            try
            {
                List<FormValidationModel> formMasterList = new List<FormValidationModel>();
                formMasterList = masterdataService.GetFormMaster();
                var response = new ResponseDataModel<IEnumerable<FormValidationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = formMasterList
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
        [Route("GetFormFields/{id}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<FormValidationModel>> GetFormFields(Int32 id)
        {
            try
            {
                List<FormValidationModel> formFieldList = new List<FormValidationModel>();
                formFieldList = masterdataService.GetFormFields(id);
                var response = new ResponseDataModel<IEnumerable<FormValidationModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = formFieldList
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
        /// <summary>
        /// To get list of all Appointment type 
        /// </summary>
        /// <returns>
        /// returns List of Appointment type as JSON
        /// </returns>
        [Route("GetAppType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<AppTypeModel>> GetAppType()
        {
            try
            {
                List<AppTypeModel> appTypeList = new List<AppTypeModel>();
                appTypeList = masterdataService.GetAppType();
                var response = new ResponseDataModel<IEnumerable<AppTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = appTypeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AppTypeModel>>()
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

        [Route("GetStateByCountryId/{countryId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<StateModel>> GetStateByCountryId(Int32 countryId)
        {
            try
            {
                List<StateModel> stateList = new List<StateModel>();
                stateList = masterdataService.GetStateByCountryId(countryId);
                var response = new ResponseDataModel<IEnumerable<StateModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = stateList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<StateModel>>()
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



        [Route("GetItemsByType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ItemsByTypeModel>> GetItemsByType(ItemsByTypeModel ibtm)
        {
            try
            {
                List<ItemsByTypeModel> itemsList = new List<ItemsByTypeModel>();
                itemsList = masterdataService.GetItemsByType(ibtm);
                var response = new ResponseDataModel<IEnumerable<ItemsByTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemsList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ItemsByTypeModel>>()
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

        [Route("GetConsentType")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ConsentTypeModel>> GetConsentType()
        {
            try
            {
                List<ConsentTypeModel> consentTypeList = new List<ConsentTypeModel>();
                consentTypeList = masterdataService.GetConsentType();
                var response = new ResponseDataModel<IEnumerable<ConsentTypeModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = consentTypeList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ConsentTypeModel>>()
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

        [Route("GetNumber/{numid}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<GetNumberModel>> GetNumber(string numid)
        {
            try
            {
                List<GetNumberModel> numberList = new List<GetNumberModel>();
                numberList = masterdataService.GetNumber(numid);
                var response = new ResponseDataModel<IEnumerable<GetNumberModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = numberList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<GetNumberModel>>()
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

        [Route("UpdateNumberTable")]
        [HttpPost]
        public ResponseDataModel<GetNumberModel> UpdateNumberTable(GetNumberModel la)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.UpdateNumberTable(la);
                var response = new ResponseDataModel<GetNumberModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<GetNumberModel>()
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
       
        [Route("InsertUpdateICDCategory")]
        [HttpPost]
        public ResponseDataModel<ICDCategroyModel> InsertUpdateICDCategory(ICDCategroyModel icdCategory)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateICDCategory(icdCategory);
                var response = new ResponseDataModel<ICDCategroyModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<ICDCategroyModel>()
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
        [Route("GetICDCategory/{categoryId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ICDCategroyModel>> GetICDCategory(int categoryId)
        {
            try
            {
                List<ICDCategroyModel> icdList = new List<ICDCategroyModel>();
                icdList = masterdataService.GetICDCategory(categoryId);
                var response = new ResponseDataModel<IEnumerable<ICDCategroyModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = icdList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ICDCategroyModel>>()
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


        [Route("InsertUpdateICDGroup")]
        [HttpPost]
        public ResponseDataModel<ICDGroupModel> InsertUpdateICDGroup(ICDGroupModel icdGroup)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateICDGroup(icdGroup);
                var response = new ResponseDataModel<ICDGroupModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<ICDGroupModel>()
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
        [Route("GetICDGroup")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ICDGroupModel>> GetICDGroup(ICDGroupModel groupId)
        {
            try
            {
                List<ICDGroupModel> icdList = new List<ICDGroupModel>();
                //icdList = masterdataService.GetICDGroup(groupId);
                var response = new ResponseDataModel<IEnumerable<ICDGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = icdList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ICDGroupModel>>()
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
        [Route("InsertUpdateICDLabel")]
        [HttpPost]
        public ResponseDataModel<ICDLabelModel> InsertUpdateICDLabel(ICDLabelModel icdLabel)
        {
            try
            {
                string message = string.Empty;
                message = masterdataService.InsertUpdateICDLabel(icdLabel);
                var response = new ResponseDataModel<ICDLabelModel>()
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<ICDLabelModel>()
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
        [Route("GetICDLabel/{labelId}")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ICDLabelModel>> GetICDLabel(int labelId)
        {
            try
            {
                List<ICDLabelModel> icdList = new List<ICDLabelModel>();
                icdList = masterdataService.GetICDLabel(labelId);
                var response = new ResponseDataModel<IEnumerable<ICDLabelModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = icdList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ICDLabelModel>>()
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
