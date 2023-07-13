using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CompanyController(ICompanyService companyService, IMapper mapper,ILogger _log )
        {
            _companyService = companyService;
            _mapper = mapper;
            _logger = _log;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            try
            {
                var items = await _companyService.GetAllCompanies();
                return _mapper.Map<IEnumerable<CompanyDto>>(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
           
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            try
            {
                var item = await _companyService.GetCompanyByCode(companyCode);
                return _mapper.Map<CompanyDto>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
            
        }

        public async Task<bool> Post([FromBody] string value)
        {
            try
            {
                return await _companyService.SaveCompany(_mapper.Map<CompanyInfo>(value));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
            // create
           
        }

        // PUT api/<controller>/5
        public async Task<bool> Put([FromBody] CompanyDto value)
        {
            //Save is handling both insert and update.
            try
            {
                return await _companyService.SaveCompany(_mapper.Map<CompanyInfo>(value));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
          
        }

        public async Task<bool> Delete(string companyCode)
        {
            try
            {
                return await _companyService.DeleteCompany(companyCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
            
        }

    }
}