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

namespace LeHealth.Base.API.Controllers.Billing
{
    [Route("api/Bill")]
    [ApiController]
    public class BillDefaultController : ControllerBase
    {
        private readonly ILogger<BillDefaultController> logger;
        private readonly IBillService billService;
        public BillDefaultController(ILogger<BillDefaultController> _logger, IBillService _billservice)
        {
            logger = _logger;
            billService = _billservice;
        }

        /// <summary>
        /// API For getting unbilled item 
        /// </summary>
        /// <param name="unbilleditem details">unbilled item table</param>
        /// <returns> unbilled item details  in branch</returns>

        [HttpPost]
        [Route("GetSponsorAgent")]

        public ResponseDataModel<IEnumerable<AgentModel>> GetSponsorAgent(AgentModel details)
        {
            try
            {
                List<AgentModel> agentList = new List<AgentModel>();
                agentList = billService.GetSponsorAgent(details);
                var response = new ResponseDataModel<IEnumerable<AgentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = agentList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<AgentModel>>()
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
        /// API For getting unbilled item 
        /// </summary>
        /// <param name="unbilleditem details">unbilled item table</param>
        /// <returns> unbilled item details  in branch</returns>

        [HttpPost]
        [Route("GetUnBilledItem")]

        public ResponseDataModel<IEnumerable<UnBilledItemModel>> GetUnBilledItem(UnBilledItemModel details)
        {
            try
            {
                List<UnBilledItemModel> itemList = new List<UnBilledItemModel>();
                itemList = billService.GetUnBilledItem(details);
                var response = new ResponseDataModel<IEnumerable<UnBilledItemModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<UnBilledItemModel>>()
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
        /// API For getting  item under selected group
        /// </summary>
        /// <param name="item details">item table</param>
        /// <returns> iitem details under selcted group in branch</returns>

        [HttpPost]
        [Route("GetItemForSelectionByGroup")]

        public ResponseDataModel<IEnumerable<BillItemModel>> GetItemForSelectionByGroup(BillItemModel billdetails)
        {
            try
            {
                List<BillItemModel> itemList = new List<BillItemModel>();
                itemList = billService.GetItemForSelectionByGroup(billdetails);
                var response = new ResponseDataModel<IEnumerable<BillItemModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<BillItemModel>>()
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
        /// API For getting searched item 
        /// </summary>
        /// <param name="itrm details">item table</param>
        /// <returns> iitem details in branch</returns>

        [HttpPost]
        [Route("SearchServiceItem")]

        public ResponseDataModel<IEnumerable<BillItemModel>> SearchServiceItem(BillItemModel billdetails)
        {
            try
            {
                List<BillItemModel> itemList = new List<BillItemModel>();
                itemList = billService.SearchServiceItem(billdetails);
                var response = new ResponseDataModel<IEnumerable<BillItemModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<BillItemModel>>()
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
        /// API For getting Packges Item
        /// </summary>
        /// <param name="package">LH_PackageItem table</param>
        /// <returns> Packageitem details  for rule</returns>

        [HttpPost]
        [Route("GetPackageItem")]

        public ResponseDataModel<IEnumerable<PackageItemsModel>> GetPackageItem(PackageItemsModel inf)
        {
            try
            {
                List<PackageItemsModel> packageList = new List<PackageItemsModel>();
                packageList = billService.GetPackageItem(inf);
                var response = new ResponseDataModel<IEnumerable<PackageItemsModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = packageList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PackageItemsModel>>()
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
        /// API For getting Packges 
        /// </summary>
        /// <param name="package">package table</param>
        /// <returns> Package details  for rule</returns>

        [HttpPost]
        [Route("GetPackage")]

        public ResponseDataModel<IEnumerable<PackageModelAll>> GetPackage(PackageModelAll inf)
        {
            try
            {
                List<PackageModelAll> packageList = new List<PackageModelAll>();
                packageList = billService.GetPackage(inf);
                var response = new ResponseDataModel<IEnumerable<PackageModelAll>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = packageList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PackageModelAll>>()
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
        /// API For getting Sponsor Forms 
        /// </summary>
        /// <param name="sponsorformdetails">SponsorForm table</param>
        /// <returns> sponsor details  for item</returns>

        [HttpPost]
        [Route("GetItemForSelection")]

        public ResponseDataModel<IEnumerable<BillItemModel>> GetItemForSelection(BillItemModel billdetails)
        {
            try
            {
                List<BillItemModel> itemList = new List<BillItemModel>();
                itemList = billService.GetItemForSelection(billdetails);
                var response = new ResponseDataModel<IEnumerable<BillItemModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = itemList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<BillItemModel>>()
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
        /// API For saving Credit Item Group 
        /// </summary>
        /// <param name="creditdetails">credit details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdateCreditItemGroup")]
        public ResponseDataModel<string> InsertUpdateCreditItemGroup(CreditItemGroupModel obj)
        {
            try
            {
                var recpt = billService.InsertUpdateCreditItemGroup(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertUpdateCreditItemGroup()");

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
        }



        /// <summary>
        /// API For gettingSponsor Forms 
        /// </summary>
        /// <param name="sponsorformdetails">SponsorForm table</param>
        /// <returns> srvice details  for rule</returns>

        [HttpPost]
        [Route("GetCreditItemGroup")]

        public ResponseDataModel<IEnumerable<CreditItemGroupModel>> GetCreditItemGroup(CreditItemGroupModel spdetails)
        {
            try
            {
                List<CreditItemGroupModel> sponsorgrpList = new List<CreditItemGroupModel>();
                sponsorgrpList = billService.GetCreditItemGroup(spdetails);
                var response = new ResponseDataModel<IEnumerable<CreditItemGroupModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sponsorgrpList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CreditItemGroupModel>>()
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
        /// API For gettingSponsor Forms 
        /// </summary>
        /// <param name="sponsorformdetails">SponsorForm table</param>
        /// <returns> srvice details  for rule</returns>

        [HttpPost]
        [Route("GetSponsorDetailsByPatient")]

        public ResponseDataModel<IEnumerable<PatientSponsorModel>> GetSponsorDetailsByPatient(PatientSponsorModel sponsor)
        {
            try
            {
                List<PatientSponsorModel> sponsorList = new List<PatientSponsorModel>();
                sponsorList = billService.GetSponsorDetailsByPatient(sponsor);
                var response = new ResponseDataModel<IEnumerable<PatientSponsorModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = sponsorList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatientSponsorModel>>()
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
        /// API For gettingSponsor Forms 
        /// </summary>
        /// <param name="sponsorformdetails">SponsorForm table</param>
        /// <returns> srvice details  for rule</returns>

        [HttpPost]
        [Route("SearchTodayPatientBill")]

        public ResponseDataModel<IEnumerable<PatientBillModel>> SearchTodayPatientBill(PatientBillModel patbill)
        {
            try
            {
                List<PatientBillModel> billList = new List<PatientBillModel>();
                billList = billService.SearchTodayPatientBill(patbill);
                var response = new ResponseDataModel<IEnumerable<PatientBillModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = billList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PatientBillModel>>()
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
        /// API For Cancelling Payment 
        /// </summary>
        /// <param name="pymnt">Payment details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("CancelReceipt")]
        public ResponseDataModel<string> CancelReceipt(ReceiptModelAll obj)
        {
            try
            {
                var recpt = billService.CancelReceipt(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "CancelReceipt()");

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
        }


        /// <summary>
        /// API For Cancelling Payment 
        /// </summary>
        /// <param name="pymnt">Payment details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("CancelPayment")]
        public ResponseDataModel<string> CancelPayment(PaymentModelAll obj)
        {
            try
            {
                var recpt = billService.CancelPayment(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "CancelPayment()");

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
        }


        /// <summary>
        /// API For saving Payment 
        /// </summary>
        /// <param name="pymnt">Payment details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdatePayment")]
        public ResponseDataModel<string> InsertUpdatePayment(PaymentModelAll obj)
        {
            try
            {
                var recpt = billService.InsertUpdatePayment(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertUpdatePayment()");

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
        }


        /// <summary>
        /// API For saving Receipt 
        /// </summary>
        /// <param name="rcpt">Receipt details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdateReceipt")]
        public ResponseDataModel<string> InsertUpdateReceipt(ReceiptModelAll obj)
        {
            try
            {
                var recpt = billService.InsertUpdateReceipt(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertUpdateReceipt()");

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
        }

    }
}
