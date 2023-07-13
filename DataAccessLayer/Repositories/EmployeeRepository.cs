using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbWrapper<Employee> _employeeDbWrapper;
        private readonly IDbWrapper<Company> _companyDbWrapper;

        public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper, IDbWrapper<Company> companyDbWrapper)
        {
            _employeeDbWrapper = employeeDbWrapper;
            _companyDbWrapper = companyDbWrapper;
        }

        public IEnumerable<Employee> GetAll()
        {
            var itemEmployeeRepo = _employeeDbWrapper.FindAll();
            var itemCompanyRepo = _companyDbWrapper.FindAll();
            if (itemEmployeeRepo != null && itemCompanyRepo != null)
            {
                var companyMap = itemCompanyRepo.ToDictionary(t => t.CompanyCode, t => t.CompanyName);
                foreach (var item in itemEmployeeRepo)
                {
                    string companyName;
                    if (companyMap.TryGetValue(item.CompanyCode, out companyName))
                        item.CompanyName = companyName;
                }

                return itemEmployeeRepo;
            }
            else return null;
        }

        public Employee GetByCode(string employeeCode)
        {
            var itemEmployeeRepo = _employeeDbWrapper.Find(t => t.EmployeeCode.Equals(employeeCode))?.FirstOrDefault();
            if (itemEmployeeRepo != null)
            {
                var itemCompanyRepo = _companyDbWrapper.Find(t => t.CompanyCode.Equals(itemEmployeeRepo.CompanyCode))?.FirstOrDefault();
                itemEmployeeRepo.CompanyName = itemCompanyRepo.CompanyName;

            }
            return itemEmployeeRepo;
        }
    }
}
