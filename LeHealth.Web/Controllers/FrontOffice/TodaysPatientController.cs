using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeHealth.Base.API.Controllers.FrontOffice
{
    [Route("api/TodaysPatient")]
    [ApiController]
    public class TodaysPatientController : ControllerBase
    {
        private readonly ILogger<TodaysPatientController> logger;
        private readonly IHospitalsService hospitalsService;

        public TodaysPatientController(ILogger<TodaysPatientController> _logger, IHospitalsService _hospitalsService)
        {
            logger = _logger;
            hospitalsService = _hospitalsService;
        }
        [Route("GetDepartments")]
        [HttpGet]
        public List<DepartmentModel> GetDepartments()
        {
            DataTable dt = new DataTable();
            List<DepartmentModel> departmentList = new List<DepartmentModel>();
            try
            {
                departmentList = hospitalsService.GetDepartments();
            }
            catch (Exception ex)
            {

            }
            return departmentList;
        }
        [Route("GetConsultant")]
        [HttpGet]
        public List<ConsultantModel> GetConsultant()
        {
            DataTable dt = new DataTable();
            List<ConsultantModel> consultantList = new List<ConsultantModel>();
            try
            {
                consultantList = hospitalsService.GetConsultant();
            }
            catch (Exception ex)
            {

            }
            return consultantList;

        }
        [Route("GetAppointments")]
        [HttpGet]
        public List<Appointments> GetAppointments()
        {
            DataTable dt = new DataTable();
            List<Appointments> appointmentList = new List<Appointments>();
            try
            {
                appointmentList = hospitalsService.GetAppointments();
            }
            catch (Exception ex)
            {

            }
            return appointmentList;

        }
        [Route("GetConsultation")]
        [HttpGet]
        public List<ConsultationModel> GetConsultation()
        {
            DataTable dt = new DataTable();
            List<ConsultationModel> consultationList = new List<ConsultationModel>();
            try
            {
                consultationList = hospitalsService.GetConsultation();
            }
            catch (Exception ex)
            {

            }
            return consultationList;

        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TodaysPatientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodaysPatientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TodaysPatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodaysPatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
