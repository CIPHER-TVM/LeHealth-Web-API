using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface ITodaysPatientManager
    {
        List<SearchAppointmentModel> GetAllAppointments(AppointmentModel appointment);
        SearchAppointmentModel GetAppointmentById(AppointmentModel appointment);
        List<SearchAppointmentModel> SearchAppointment(AppointmentModel appointment);
        List<PatientListModel> SearchPatient(PatientSearchModel patientList);
        List<PatientListModel> GetPatientByRegNo(string regNo);
        FrontOfficePBarModel GetFrontOfficeProgressBars(ConsultationModel cm);
        List<SchemeModel> GetSchemeByConsultant(ConsultantModel consultant);
        List<GetAppNoModel> GetAppNumber(GetAppNumberIPModel gap);
        List<GetAppTimeModel> GetAppTime(GetAppNumberIPModel gap);
        string DeleteAppointment(AppointmentModel appointment);
        string UpdateAppointmentStatus(AppointmentModel appointment);
        List<SheduleGetDataModel> GetScheduleData(GetScheduleInputModel gsi);
        List<ConsultationModel> InsertUpdateConsultation(ConsultationModel appointments);
        List<ConsultationModel> UpdateConsultationSymptoms(ConsultationModel appointments);
        List<RecentConsultationModel> GetRecentConsultationData();
        List<TokenModel> GetNewTokenNumber(ConsultationModel cm);
        List<SponsorModel> GetSponsorListByPatientId(Int32 patientId);
        List<ConsultRateModel> GetConsultRate(ConsultationModel cm);
        List<ConsultantModel> GetConsultant(ConsultantByDeptModel cm);
        string AppoinmentValidCheck(AppoinmentValidCheckModel cm);
        List<ConsultationByPatientIdModel> GetConsultationByPatientId(ConsultationModel cm);
        PatientConsultationModel GetConsultationDataById(Int32 patientId);
        List<PatRegByPatientIdModel> GetPatRegByPatientId(ConsultationModel cm);
        List<ConsultRateModel> GetRegSchmAmtOfPatient(ConsultationModel cm);
        List<PatientModel> GetPatient(Int32 pid);
        List<Appointments> GetAppointments(AppointmentModel appointment);
        List<GetConsultantItemSchemeRateModel> GetConsultantItemSchemeRate(ConsultantItemSchemeRateIPModel cisr);
        string CancelConsultation(ConsultationModel cons);
        string PostponeAppointment(Appointments cons);
        string SetUrgentConsultation(ConsultationModel cons);
        List<ConsultantModel> GetConsultants(DepartmentIdModel deptId);
        string CheckConsultantSchedule(CheckConsultantScheduleModel scheduleModel);
    }
}
