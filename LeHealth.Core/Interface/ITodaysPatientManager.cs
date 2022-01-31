using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface ITodaysPatientManager
    {
        List<SearchAppointmentModel> GetAllAppointments(AppointmentModel appointment);
        List<SearchAppointmentModel> GetAppointmentById(AppointmentModel appointment);
        List<SearchAppointmentModel> SearchAppointment(AppointmentModel appointment);
        List<PatientListModel> SearchPatient(PatientSearchModel patientList);
        List<PatientListModel> GetPatientByRegNo(String regNo);
        FrontOfficePBarModel GetFrontOfficeProgressBars(String patientList);
        //List<MandatoryFieldsModel> GetSavingSchemaMandatory(String formname);
        List<SchemeModel> GetSchemeByConsultant(int consultantid);
        
        List<GetAppNoModel> GetAppNumber(GetAppNumberIPModel gap);
        List<GetAppTimeModel> GetAppTime(GetAppNumberIPModel gap);
        
        String DeleteAppointment(AppointmentModel appointment);
        String UpdateAppointmentStatus(AppointmentModel appointment);
        List<SheduleGetDataModel> GetScheduleData(GetScheduleInputModel gsi);
        List<ConsultationModel> InsertUpdateConsultation(ConsultationModel appointments);
        List<ConsultationModel> UpdateConsultationSymptoms(ConsultationModel appointments);
        List<RecentConsultationModel> GetRecentConsultationData();
        List<TokenModel> GetNewTokenNumber(ConsultationModel cm);
        List<SponsorModel> GetSponsorListByPatientId(int patientId);
        
        List<ConsultRateModel> GetConsultRate(ConsultationModel cm);
        List<ConsultantModel> GetConsultant(ConsultantByDeptModel cm);
        String AppoinmentValidCheck(AppoinmentValidCheckModel cm);
        List<ConsultationByPatientIdModel> GetConsultationByPatientId(ConsultationModel cm);
        List<PatientConsultationModel> GetConsultationDataById(int patientId);
        List<PatRegByPatientIdModel> GetPatRegByPatientId(ConsultationModel cm);
        List<ConsultRateModel> GetRegSchmAmtOfPatient(ConsultationModel cm);
        List<PatientModel> GetPatient(int pid);
        List<Appointments> GetAppointments(AppointmentModel appointment);
        List<GetConsultantItemSchemeRateModel> GetConsultantItemSchemeRate(ConsultantItemSchemeRateIPModel cisr);
        
        String CancelConsultation(ConsultationModel cons);
        String PostponeAppointment(Appointments cons);
        String SetUrgentConsultation(ConsultationModel cons);
        List<ConsultantModel> GetConsultants(DepartmentIdModel deptId);
    }
}
