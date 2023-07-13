using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        //IEnumerable<CompanyInfo> GetAllCompanies();
        //CompanyInfo GetCompanyByCode(string companyCode);
        //bool SaveCompany(CompanyInfo company);
        //bool DeleteCompany(string companyCode);

        Task<IEnumerable<CompanyInfo>> GetAllCompanies();
        Task<CompanyInfo> GetCompanyByCode(string companyCode);
        Task<bool> SaveCompany(CompanyInfo company);
        Task<bool> DeleteCompany(string companyCode);
    }
}
