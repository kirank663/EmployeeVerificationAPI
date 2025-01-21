using EmployeeVerificationAPI.IModelRepository;
using EmployeeVerificationAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeVerificationAPI.Controllers
{
      [Route("api/verify-employment")]
      [ApiController]
      public class EmployeeController : ControllerBase
      {
            private IEmployeeRepository _employeeRepository;
            public EmployeeController(IEmployeeRepository employeeRepository)
            {
                  _employeeRepository = employeeRepository;
            }
            [HttpPost("verify-employee")]
            public IActionResult VerifyEmployee(Employee employee)
            {
                  if(employee == null)
                        return BadRequest("Invalid request.");

                  MessageResponce _responce = new MessageResponce();
                  if(_employeeRepository.VerifyEmployee(employee))
                  {
                        _responce.Status = true;
                        _responce.Message = "Verified";
                  }
                  else
                  {
                        _responce.Status = false;
                        _responce.Message = "Not Verified.";
                  }
                  return new JsonResult(_responce);
            }
      }
}
