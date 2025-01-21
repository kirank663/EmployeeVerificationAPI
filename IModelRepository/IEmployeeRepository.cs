using EmployeeVerificationAPI.Model;

namespace EmployeeVerificationAPI.IModelRepository
{
      public interface IEmployeeRepository
      {
            bool VerifyEmployee(Employee employee);
            bool CheckIfEmployeeIsExist(int empId);
      }
}
