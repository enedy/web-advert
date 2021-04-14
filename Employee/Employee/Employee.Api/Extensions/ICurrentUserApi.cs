using System.Collections.Generic;
using System.Security.Claims;

namespace Employee.Api.Extensions
{
    public interface ICurrentUserApi
    {
        string Name { get; }
        long GetUserId();
        string GetName();
        long GetCompanyId();
        long GetEmployeeId();
        long GetEmployeeCompanyId();
        string GetUsuPrivil();
        string GetRole();
        int GetUserType();
        string GetGuid();
        IEnumerable<long> GetAppsId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
