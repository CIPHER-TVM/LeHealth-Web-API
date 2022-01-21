using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface ITodaysPatientService
    {
        List<SearchAppointmentModel> GetAllAppointments(AppointmentModel appointment);
        List<SearchAppointmentModel> GetAppointmentById(AppointmentModel appointment);
        List<SearchAppointmentModel> SearchAppointment(AppointmentModel appointment);
        List<PatientListModel> SearchPatient(PatientSearchModel patientList);
        List<PatientListModel> GetPatientByRegNo(string Regno);
        FrontOfficePBarModel GetFrontOfficeProgressBars(string patientList);
       // List<MandatoryFieldsModel> GetSavingSchemaMandatory(string formname);
        List<SchemeModel> GetSchemeByConsultant(int consultantid);
        List<GetAppNoModel> GetAppNumber(GetAppNumberIPModel gap);
        List<GetAppTimeModel> GetAppTime(GetAppNumberIPModel gap);
        
        string DeleteAppointment(AppointmentModel appointment);
        string CancelConsultation(ConsultationModel consultantion);
        string PostponeAppointment(Appointments appointments);
        string SetUrgentConsultation(ConsultationModel consultantion);
        List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations);
        List<ConsultationModel> UpdateConsultationSymptoms(ConsultationModel consultations);
        List<TokenModel> GetNewTokenNumber(ConsultationModel cm);
        List<SheduleGetDataModel> GetScheduleData(GetScheduleInputModel gsi);
        List<SponsorModel> GetSponsorListByPatientId(int patientId);
        List<RecentConsultationModel> GetRecentConsultationData();
        List<ConsultRateModel> GetConsultRate(ConsultationModel cm);
        List<ConsultantModel> GetConsultant(ConsultantByDeptModel cm);
        string AppoinmentValidCheck(AppoinmentValidCheckModel avcm);
        List<ConsultationByPatientIdModel> GetConsultationByPatientId(ConsultationModel cm);
        List<PatientConsultationModel> GetConsultationDataByPatientId(int patientId); 
        List<PatRegByPatientIdModel> GetPatRegByPatientId(ConsultationModel cm);
        List<ConsultRateModel> GetRegSchmAmtOfPatient(ConsultationModel cm);
        List<PatientModel> GetPatient(int pid);
        List<Appointments> GetAppointments(AppointmentModel appointment);
        List<GetConsultantItemSchemeRateModel> GetConsultantItemSchemeRate(ConsultantItemSchemeRateIPModel cisr);
        List<ConsultantModel> GetConsultants(DepartmentIdModel deptId);
    }
}
