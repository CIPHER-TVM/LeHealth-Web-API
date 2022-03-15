using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;
using System.Data;
using System.Threading.Tasks;
namespace LeHealth.Core.Interface
{
    public interface IConsultantManager
    {
        List<ConsultationModel> SearchConsultationById(int consultantId);
        List<SearchAppointmentModel> SearchAppointmentByConsultantId(int consultantId);
        List<PatientListModel> SearchPatientByConsultantId(int consultantId);
        string InsertUpdateConsultant(ConsultantMasterModel consultant);
        List<ConsultantMasterModel> GetAllConsultants(int consultantType);
    }
}
