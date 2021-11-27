using Microsoft.AspNetCore.Mvc;
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
        [Route("GetProfession")]
        [HttpPost]
        public ResponseDataModel<IEnumerable<ProffessionModel>> GetProfession()
        {
            List<ProffessionModel> professionList = new List<ProffessionModel>();
            try
            {
                professionList = masterdataService.GetProfession();
                var response = new ResponseDataModel<IEnumerable<ProffessionModel>>()
                {
                    Status = HttpStatusCode.OK,
                    Response = professionList
                };
                return response;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Failed to perform operation by following Exception: " + ex.Message + " " + DateTime.Now.ToString());
                return new ResponseDataModel<IEnumerable<ProffessionModel>>()
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
                // dispose can be managed here
            }
        }
    }
}
