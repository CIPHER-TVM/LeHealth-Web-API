using LeHealth.Entity.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeHealth.Service.ServiceInterface
{
    public interface IStudentService
    {
        Task<List<StudentViewModel>> GetStudents();
        Task<StudentViewModel> GetStudentDetailsById(int studentId);
        Task<StudentViewModel> CreateStudent(StudentViewModel studentViewModel);
        Task<StudentViewModel> UpdateStudent(StudentViewModel studentViewModel);
        Task<int> DeleteStudent(int studentId);
    }
}
