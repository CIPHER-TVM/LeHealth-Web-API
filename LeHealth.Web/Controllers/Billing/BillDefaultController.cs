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
        /// API For gettingSponsor Forms 
        /// </summary>
        /// <param name="sponsorformdetails">SponsorForm table</param>
        /// <returns> srvice details  for rule</returns>

        [HttpPost]
        [Route("GetSponsorForm")]

        public ResponseDataModel<IEnumerable<SponsorFormModel>> GetSponsorForm(SponsorFormModel frm)
        {
            try
            {
                List<SponsorFormModel> formList = new List<SponsorFormModel>();
                formList = billService.GetSponsorForm(frm);
                var response = new ResponseDataModel<IEnumerable<SponsorFormModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = formList
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

    }
}
