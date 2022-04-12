using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IConsultantService
    {
        List<ConsultationModel> SearchConsultationById(ConsultationModel consultation);
        List<SearchAppointmentModel> SearchAppointmentByConsultantId(SearchAppointmentModel appointment);
        List<ConsultantPatientModel> SearchPatientByConsultantId(PatientSearchModel patient);
        string InsertUpdateConsultant(ConsultantMasterModel consultant);
        List<ConsultantMasterModel> GetAllConsultants(int consultantType);
        string InsertConsultantService(ConsultantServiceModel consultant);
        string DeleteConsultantService(int serviceId);
        List<ConsultantServiceModel> GetConsultantServices(int consultantId);
        string InsertConsultantDrugs(ConsultantDrugModel consultantDrug);
        string UpdateConsultantDrugs(ConsultantDrugModel consultantDrug);
        List<ConsultantDrugModel> GetConsultantDrugs(int consultantId);
        string DeleteConsultantDrug(int drugId);
        string InsertConsultantDiseases(DiseaseModel disease);
        List<DiseaseSymptomModel> GetDiseaseSymptoms(int diseaseId);
        List<DiseaseSignModel> GetDiseaseVitalSigns(int diseaseId);
        List<DiseaseCDModel> GetDiseaseICD(int diseaseId);
        string DeleteDiseaseICD(int diseaseId);
        string DeleteDiseaseSymptom(int diseaseId);
        string DeleteDiseaseSign(int diseaseId);
        string BlockDisease(DiseaseModel disease);
        string UnblockDisease(DiseaseModel disease);
        List<Appointments> GetMyAppointments(AppointmentModel appointment);
        List<ConsultationModel> GetMyConsultations(ConsultantModel consultant);
        string InsertUpdateSchedule(ScheduleModel schedule);
        List<ScheduleModel> GetSchedules(int consultantId);
        string DeleteSchedule(int scheduleId);

        string InsertUpdateTimer(TimerModel timer);
        List<AvailableServiceModel> GetServicesOrderLoadByConsultantId(AvailableServiceModel availableService);

        FrontOfficePBarModel GetFrontOfficeProgressBarsByConsultantId(AppointmentModel appointment);

    }
}
