﻿using CompanyAPI.Model;
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
        public async Task<IActionResult> Create(EmployeeViewModel employeeView)
        {

            string? filePath = null;

            // Verificar se a foto foi enviada
            if (employeeView.Photo != null)
            {
                filePath = Path.Combine("Storage", employeeView.Photo.FileName);

                // Salvar o arquivo no diretório especificado
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await employeeView.Photo.CopyToAsync(fileStream);
                }
            }

            var employee = new Employee(
                employeeView.Name,
                filePath,
                employeeView.Email,
                employeeView.Document,
                employeeView.Phone,
                employeeView.Address,
                employeeView.City,
                employeeView.Region,
                employeeView.PostalCode,
                employeeView.Country
            );

            await _employeeRepository.AddAsync(employee);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/download")]
        public async Task<IActionResult> DownloadPhoto(int id)
        {
            var employee = await _employeeRepository.GetAsync(id);
            if (employee?.Photo == null || !System.IO.File.Exists(employee.Photo))
                return NotFound();

            var dataBytes = await System.IO.File.ReadAllBytesAsync(employee.Photo);
            var mimeType = Path.GetExtension(employee.Photo)?.ToLower() switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                _ => "application/octet-stream"
            };

            return File(dataBytes, mimeType, Path.GetFileName(employee.Photo));
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employee = await _employeeRepository.GetAllAsync();

            return Ok(employee);

        }

    }
}
