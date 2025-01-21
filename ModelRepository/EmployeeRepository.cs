using EmployeeVerificationAPI.DatabaseOperations;
using EmployeeVerificationAPI.IModelRepository;
using EmployeeVerificationAPI.Model;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeVerificationAPI.ModelRepository
{
      public class EmployeeRepository : IEmployeeRepository
      {
            DataTable _dt;
            private DatabaseOperation _dbOperation = new DatabaseOperation();
            public bool CheckIfEmployeeIsExist(int empId)
            {
                  _dt = new DataTable();
                  _dt = _dbOperation.ExecuteTableValuedFunction("SELECT * FROM dbo.udf_CheckIfEmployeeIsExist(" + empId + ")");
                  if(_dt.Rows.Count > 0)
                  { return true; }
                  else
                  { return false; }
            }

            public bool VerifyEmployee(Employee employee)
            {
                  SqlParameter[] _sqlParam = new SqlParameter[3];
                  _sqlParam[0] = new SqlParameter("@empId" , employee.empId);
                  _sqlParam[1] = new SqlParameter("@companyName" , employee.companyName);
                  _sqlParam[2] = new SqlParameter("@verificationCode" , employee.verificationCode);
                  _dt = _dbOperation.ExecuteDataTable(_sqlParam , "dbo.Proc_EmployeeVerification");
                  if(_dt.Rows.Count > 0)
                  {
                        return true;
                  }
                  else
                  {
                        return false;
                  }
            }
      }
}
