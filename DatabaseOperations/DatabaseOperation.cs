using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeVerificationAPI.DatabaseOperations
{
      public class DatabaseOperation
      {
            private static DatabaseOperation _dbOperation = null;
            private SqlConnection _sqlConnection;
            private SqlCommand _sqlCommand;
            private SqlDataAdapter _sqlAdapter;
            private DataTable _dataTable=null;
            public DatabaseOperation()
            {
                  _sqlConnection = new SqlConnection("Server=DESKTOP-6RR8FGI\\SQLEXPRESS;Database=EmployeeVerificationDB;Trusted_Connection=True;");
                  _sqlCommand = new SqlCommand();
            }
            public static DatabaseOperation GetInstance
            {
                  get
                  {
                        if(_dbOperation == null)
                        {
                              _dbOperation = new DatabaseOperation();
                        }
                        return _dbOperation;
                  }
            }
            public DataTable ExecuteDataTable(SqlParameter[] parameters , string procedureName)
            {
                  try
                  {
                        _dataTable = new DataTable();
                        _sqlCommand = new SqlCommand(procedureName , _sqlConnection);
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.Parameters.AddRange(parameters);
                        _sqlAdapter = new SqlDataAdapter(_sqlCommand);
                        _sqlAdapter.Fill(_dataTable);
                  }
                  catch(Exception ex)
                  {

                  }
                  finally
                  {
                     
                  }
                  return _dataTable;
            }
            public DataTable ExecuteTableValuedFunction(string functionName)
            {
                  try
                  {
                        _dataTable = new DataTable();
                        _sqlAdapter = new SqlDataAdapter(functionName , _sqlConnection);
                        _sqlAdapter.Fill(_dataTable);
                  }
                  catch(Exception ex)
                  {

                  }
                  finally
                  {

                  }
                  return _dataTable;
            }
      }
}
