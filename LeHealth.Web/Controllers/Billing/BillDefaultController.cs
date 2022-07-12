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
        /// API For updating ExtTransactionDet  Details
        /// </summary>
        /// <param name="transactiondetails">LH_ExtTransactionDet table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertTransactionSOExternal")]
        public ResponseDataModel<string> InsertTransactionSOExternal(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertTransactionSOExternal(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertTransactionSOExternal()");

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
        /// API For Inserting investigation Details
        /// </summary>
        /// <param name="investigation Details">LH_Investigation table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdateInvestigation")]
        public ResponseDataModel<string> InsertUpdateInvestigation(InvestigationModel obj)
        {
            try
            {
                var recpt = billService.InsertUpdateInvestigation(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertUpdateInvestigation()");

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
        /// API For Services List

        /// </summary>
        /// <param name="credit details">LH_ServicePoint table</param>
        /// <returns>  Service Detail list  Under branch</returns>

        [HttpPost]
        [Route("GetServicesForAutoInitiate")]
        public ResponseDataModel<IEnumerable<ServiceAutoInitiateModel>> GetServicesForAutoInitiate(ServiceAutoInitiateModel details)
        {
            try
            {
                List<ServiceAutoInitiateModel> creditList = new List<ServiceAutoInitiateModel>();
                creditList = billService.GetServicesForAutoInitiate(details);
                var response = new ResponseDataModel<IEnumerable<ServiceAutoInitiateModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = creditList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ServiceAutoInitiateModel>>()
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
        /// API For Inserting Transactiontax Details
        /// </summary>
        /// <param name="transactiondetails">LH_TransactionDet table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertTransactionSO")]
        public ResponseDataModel<string> InsertTransactionSO(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertTransactionSO(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertTransactionSO()");

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
        /// API For Inserting Transactiontax Details
        /// </summary>
        /// <param name="transactiondetails">LH_TransactionLOC table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertTransactionLOC")]
        public ResponseDataModel<string> InsertTransactionLOC(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertTransactionLOC(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertTransactionLOC()");

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
        /// API For Deleting Transactiontax Details
        /// </summary>
        /// <param name="transactiondetails">lh_ClaimDet table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("DeleteTransactionLoc")]
        public ResponseDataModel<string> DeleteTransactionLoc(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.DeleteTransactionLoc(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "DeleteTransactionLoc()");

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
        /// API For Inserting Transactiontax Details
        /// </summary>
        /// <param name="transactiondetails">LH_TransactionTax table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertTransactionTAX")]
        public ResponseDataModel<string> InsertTransactionTAX(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertTransactionTAX(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertTransactionTAX()");

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
        /// API For Deleting Transactiontax Details
        /// </summary>
        /// <param name="transactiondetails">LH_TransactionTax table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("DeleteTransactionTax")]
        public ResponseDataModel<string> DeleteTransactionTax(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.DeleteTransactionTax(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "DeleteTransactionTax()");

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
        /// API For insert Transactionlocitem Details
        /// </summary>
        /// <param name="transaction details">LH_TransLocItem table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertTransLocItem")]
        public ResponseDataModel<string> InsertTransLocItem(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertTransLocItem(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertTransLocItem()");

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
        /// API For insert Transaction Details
        /// </summary>
        /// <param name="transaction details">TransactionDet table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertTransactionDet")]
        public ResponseDataModel<string> InsertTransactionDet(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertTransactionDet(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertTransactionDet()");

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
        /// API For Deleting Transaction Details
        /// </summary>
        /// <param name="transid">TransactionDet table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("DeleteTransactionDet")]
        public ResponseDataModel<string> DeleteTransactionDet(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.DeleteTransactionDet(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "DeleteTransactionDet()");

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
        /// API For insert transaction details
        /// </summary>
        /// <param name="transactiondetails">Transaction table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdateTransaction")]
        public ResponseDataModel<string> InsertUpdateTransaction(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertUpdateTransaction(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertUpdateTransaction()");

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
        /// API For insert TransCreditItemGroup details
        /// </summary>
        /// <param name="transactiondetails">LH_TransCreditItemGroup table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertTransCreditItemGroup")]
        public ResponseDataModel<string> InsertTransCreditItemGroup(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertTransCreditItemGroup(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertTransCreditItemGroup()");

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
        /// API For insert external transactionlocdetails
        /// </summary>
        /// <param name="transactiondetails">ExtTransactionLOC table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertTransactionLOCExternal")]
        public ResponseDataModel<string> InsertTransactionLOCExternal(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertTransactionLOCExternal(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertTransactionLOCExternal()");

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
        /// API For Deleting external transactiondloc
        /// </summary>
        /// <param name="transid">ExtTransactionLOC table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("DeleteTransactionLocExternal")]
        public ResponseDataModel<string> DeleteTransactionLocExternal(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.DeleteTransactionLocExternal(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "DeleteTransactionLocExternal()");

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
        /// API For insert external transactiondetails
        /// </summary>
        /// <param name="transaction details">ExtTransactionDet table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertTransactionDetExternal")]
        public ResponseDataModel<string> InsertTransactionDetExternal(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertTransactionDetExternal(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertTransactionDetExternal()");

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
        /// API For Deleting external transactiondetails
        /// </summary>
        /// <param name="transid">ExtTransactionDet table</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("DeleteTransactionDetExternal")]
        public ResponseDataModel<string> DeleteTransactionDetExternal(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.DeleteTransactionDetExternal(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "DeleteTransactionDetExternal()");

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
        /// API For insert external transactions
        /// </summary>
        /// <param name="transaction details">transaction details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdateTransactionExternal")]
        public ResponseDataModel<string> InsertUpdateTransactionExternal(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.InsertUpdateTransactionExternal(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertUpdateTransactionExternal()");

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
        /// API For returning order details as message
        /// </summary>
        /// <param name="patientid,itemid">serviceorder details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("CheckPatientSOHistory")]
        public ResponseDataModel<string> CheckPatientSOHistory(ServiceOrderModel obj)
        {
            try
            {
                var recpt = billService.CheckPatientSOHistory(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "CheckPatientSOHistory()");

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
        /// API For Getting agentid

        /// </summary>
        /// <param name="credit details">credit table</param>
        /// <returns>  agentid  </returns>

        [HttpPost]
        [Route("CheckSubAgentStatus")]

        public ResponseDataModel<IEnumerable<AgentModel>> CheckSubAgentStatus(CreditModel details)
        {
            try
            {
                List<AgentModel> agent = new List<AgentModel>();
                agent = billService.CheckSubAgentStatus(details);
                var response = new ResponseDataModel<IEnumerable<AgentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = agent
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
        /// API For getting the message with refno i
        /// </summary>
        /// <param name="transaction id">transaction details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("CheckForClaimGeneration")]
        public ResponseDataModel<string> CheckForClaimGeneration(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.CheckForClaimGeneration(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "CheckForClaimGeneration()");

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
        /// API For Cancelling Bill 
        /// </summary>
        /// <param name="transaction id">transaction details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("CancelBill")]
        public ResponseDataModel<string> CancelBill(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.CancelBill(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "CancelBill()");

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
        /// API For checking whether the Bill is Settled or not
        /// </summary>
        /// <param name="transaction id">transaction details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("IsBilledTransaction")]
        public ResponseDataModel<string> IsBilledTransaction(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.IsBilledTransaction(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "IsBilledTransaction()");

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
        /// API For Credit List

        /// </summary>
        /// <param name="credit details">Credit table</param>
        /// <returns>  credit list  Under branch</returns>

        [HttpPost]
        [Route("GetManageCreditForBilling")]
        public ResponseDataModel<IEnumerable<CreditModel>> GetManageCreditForBilling(CreditModelAll details)
        {
            try
            {
                List<CreditModel> creditList = new List<CreditModel>();
                creditList = billService.GetManageCreditForBilling(details);
                var response = new ResponseDataModel<IEnumerable<CreditModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = creditList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<CreditModel>>()
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
        /// API For Cancelling Bill Settlement
        /// </summary>
        /// <param name="transaction id">transaction details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("CancelBillSettlement")]
        public ResponseDataModel<string> CancelBillSettlement(TransactionModelAll obj)
        {
            try
            {
                var recpt = billService.CancelBillSettlement(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "CancelBillSettlement()");

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
        /// API For Bill List (External bills and normal bills )
        /// //External bill identified by the param 'Externalstatus'
        /// </summary>
        /// <param name="Bill details">Traansaction table,Exttransaction table</param>
        /// <returns>  bill list  Under branch</returns>

        [HttpPost]
        [Route("GetBillList")]

        public ResponseDataModel<IEnumerable<TransactionModel>> GetBillList(TransactionModelAll details)
        {
            try
            {
                List<TransactionModel> transList = new List<TransactionModel>();
                transList = billService.GetBillList(details);
                var response = new ResponseDataModel<IEnumerable<TransactionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = transList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<TransactionModel>>()
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
        /// API For Pending Bill List 
        /// </summary>
        /// <param name="Pending Bill details">Traansaction table</param>
        /// <returns> pending bill list  Under branch</returns>

        [HttpPost]
        [Route("GetPendingBill")]

        public ResponseDataModel<IEnumerable<TransactionModel>> GetPendingBill(TransactionModel details)
        {
            try
            {
                List<TransactionModel> transList = new List<TransactionModel>();
                transList = billService.GetPendingBill(details);
                var response = new ResponseDataModel<IEnumerable<TransactionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = transList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<TransactionModel>>()
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
        /// API For getting Payment List 
        /// </summary>
        /// <param name="Payment details">Payment table</param>
        /// <returns> Payment details  Under branch</returns>

        [HttpPost]
        [Route("GetPaymentList")]

        public ResponseDataModel<IEnumerable<PaymentModel>> GetPaymentList(PaymentModelAll details)
        {
            try
            {
                List<PaymentModel> pymntList = new List<PaymentModel>();
                pymntList = billService.GetPaymentList(details);
                var response = new ResponseDataModel<IEnumerable<PaymentModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = pymntList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<PaymentModel>>()
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
        /// API For getting Receipt List 
        /// </summary>
        /// <param name="Receipt details">Receipt table</param>
        /// <returns> Receipt details  Under branch</returns>

        [HttpPost]
        [Route("GetReceiptList")]

        public ResponseDataModel<IEnumerable<ReceiptModel>> GetReceiptList(ReceiptModelAll details)
        {
            try
            {
                List<ReceiptModel> recceiptList = new List<ReceiptModel>();
                recceiptList = billService.GetReceiptList(details);
                var response = new ResponseDataModel<IEnumerable<ReceiptModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recceiptList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ReceiptModel>>()
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
        /// API For saving Credit  Group 
        /// </summary>
        /// <param name="creditdetails">credit details</param>
        /// <returns>Success or reason for failure</returns>
        [HttpPost]
        [Route("InsertUpdateCredit")]
        public ResponseDataModel<string> InsertUpdateCredit(CreditModelAll obj)
        {
            try
            {
                var recpt = billService.InsertUpdateCredit(obj);
                var response = new ResponseDataModel<string>()
                {
                    Status = HttpStatusCode.OK,
                    Response = recpt,

                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BillDefaultController", "InsertUpdateCredit()");

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
