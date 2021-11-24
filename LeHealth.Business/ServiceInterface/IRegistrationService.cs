﻿using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.ServiceInterface
{
    public interface IRegistrationService
    {
        List<ProffessionModel> GetProfession();
        List<RateGroupModel> GetRateGroup(int rgroup);
        List<AllPatientModel> GetAllPatient();
        List<MaritalStatusModel> GetMaritalStatus();
        List<AllPatientModel> SearchPatientInList(PatientSearchModel patientList);
        List<PatientModel> GetRegsteredDataById(int patientId); 
        string SaveReRegistration(PatientModel patient);
        string BlockUnblockPatient(PatientModel patient); 
    }
}
