using CompanyAPI.Model;
using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController(IEmployeeRepository employeeRepository) : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = new Employee(
                model.Name,
                model.Email,
                model.Document,
                model.Phone,
                model.Address,
                model.City,
                model.Region,
                model.PostalCode,
                model.Country
            );

            await _employeeRepository.AddAsync(employee);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employee = await _employeeRepository.GetAllAsync();

            return Ok(employee);

        }

    }
}
