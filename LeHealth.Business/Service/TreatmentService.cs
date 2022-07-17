using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using LeHealth.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Service.Service
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentManager treatmentManager;
        private readonly IFileUploadService fileUploadService;
        public TreatmentService(ITreatmentManager _treatmentManager, IFileUploadService _fileUploadService)
        {
            treatmentManager = _treatmentManager;
            fileUploadService = _fileUploadService;
        }

        public PhysioAnalysisHistoryModel InsertUpdatePhysioAnalysisHistoryTreatment(PhysioAnalysisHistoryModel vsem)
        {
            return treatmentManager.InsertUpdatePhysioAnalysisHistoryTreatment(vsem);
        }
        public List<PhysioAnalysisHistoryModel> GetPhysioAnalysisHistoryTreatment(PhysioAnalysisHistoryModel dmac)
        {
            return treatmentManager.GetPhysioAnalysisHistoryTreatment(dmac);
        }
        public TreatmentDetailsModel InsertTreatmentDetails(TreatmentDetailsModel dem)
        {
            return treatmentManager.InsertTreatmentDetails(dem);
        }
        public List<TreatmentDetailsModel> GetTreatmentDetails(TreatmentDetailsModel dmac)
        {
            return treatmentManager.GetTreatmentDetails(dmac);
        }
    }
}
