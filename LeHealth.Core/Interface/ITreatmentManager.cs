using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Core.Interface
{
    public interface ITreatmentManager
    {
        PhysioAnalysisHistoryModel InsertUpdatePhysioAnalysisHistoryTreatment(PhysioAnalysisHistoryModel dem);
        List<PhysioAnalysisHistoryModel> GetPhysioAnalysisHistoryTreatment(PhysioAnalysisHistoryModel dac);
        TreatmentDetailsModel InsertTreatmentDetails(TreatmentDetailsModel vsem);
        List<TreatmentDetailsModel> GetTreatmentDetails(TreatmentDetailsModel vsem);
    }
}
