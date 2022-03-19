﻿using System;
using System.Collections.Generic;
using System.Text;
using LeHealth.Entity.DataModel;
using System.Data;
using System.Threading.Tasks;
namespace LeHealth.Core.Interface
{
    public interface IConsultantManager
    {
        List<ConsultationModel> SearchConsultationById(ConsultationModel consultation);
        List<SearchAppointmentModel> SearchAppointmentByConsultantId(SearchAppointmentModel appointment);
        List<PatientListModel> SearchPatientByConsultantId(PatientSearchModel patient);
        string InsertUpdateConsultant(ConsultantMasterModel consultant);
        List<ConsultantMasterModel> GetAllConsultants(int consultantType);
        string InsertConsultantService(ConsultantServiceModel consultant);
        string DeleteConsultantService(int serviceId);
        List<ConsultantServiceModel> GetConsultantServices(int consultantId);

        string InsertConsultantDrugs(ConsultantDrugModel consultantDrug);
        List<ConsultantDrugModel> GetConsultantDrugs(int consultantId);
        string DeleteConsultantDrug(int drugId);
        string UpdateConsultantDrugs(ConsultantDrugModel consultantDrug);
       
        string InsertConsultantDiseases(DiseaseModel disease);
    }
}
