﻿using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IEMRDefaultService
    {
        List<ConsultationEMRModel> GetConsultation(ConsultationEMRModelAll schedule);
        List<PatientBasicModel> GetBasicPatientDetails(PatientBasicModel schedule);
        VisitModel InsertVisit(VisitModel visit);
        ComplaintsModel InsertComplaints(ComplaintsModel complaints);
        List<ComplaintsModel> GetChiefComplaints(ComplaintsModel schedule);
        PhysicalExaminationModel InsertPhysicalExamination(PhysicalExaminationModel pe);
        SymptomReviewModel InsertReviewOfSymptoms(SymptomReviewModel srm);
        List<VisitModel> GetVisitDetails(VisitModel visit);
    }
}
