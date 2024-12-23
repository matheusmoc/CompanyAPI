﻿using AutoMapper;
using CompanyAPI.Application.ViewModel;
using CompanyAPI.Domain.DTOs;
using CompanyAPI.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeView)
        {

            string? filePath = null;


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
        public async Task<IActionResult> Get(int pageNumber, int pageQuantity)
        {
            _logger.Log(LogLevel.Information, "Listagem de funcionários");
            var employee = await _employeeRepository.GetAllAsync(pageNumber, pageQuantity);

            return Ok(employee);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Search(int id)
        {
            var employee = await _employeeRepository.GetAsync(id);
            var employeesDTO = _mapper.Map<Employee>(employee);
            if (employeesDTO == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            return Ok(employeesDTO);
        }

    }
}
