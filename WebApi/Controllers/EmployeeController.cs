using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILogger logger)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _logger = logger;
        }
        // GET api/<controller>
        public IEnumerable<EmployeeDto> GetAll()
        {
            try
            {
                var items = _employeeService.GetAllEmployees();
                return _mapper.Map<IEnumerable<EmployeeDto>>(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }

        }

        // GET api/<controller>/5
        public EmployeeDto Get(string employeeCode)
        {
            try
            {
                var item = _employeeService.GetEmployeeByCode(employeeCode);
                return _mapper.Map<EmployeeDto>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
            
        }
    }
}