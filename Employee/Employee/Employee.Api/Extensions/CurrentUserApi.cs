using Employee.Api.EnumsAndConsts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Employee.Api.Extensions
{
    public class CurrentUserApi : ICurrentUserApi
    {
        private readonly IHttpContextAccessor _accessor;

        public CurrentUserApi(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public long GetUserId()
        {
            return IsAuthenticated() ? long.Parse(_accessor.HttpContext.User.GetUserId()) : 0;
        }

        public string GetName()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetName() : string.Empty;
        }

        public long GetCompanyId()
        {
            return IsAuthenticated() ? long.Parse(_accessor.HttpContext.User.GetCompanyId()) : 0;
        }

        public long GetEmployeeId()
        {
            return IsAuthenticated() ? long.Parse(_accessor.HttpContext.User.GetEmployeeId()) : 0;
        }

        public long GetEmployeeCompanyId()
        {
            return IsAuthenticated() ? long.Parse(_accessor.HttpContext.User.GetEmployeeCompanyId()) : 0;
        }

        public string GetUsuPrivil()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetUsuPrivil() : string.Empty;
        }

        public string GetRole()
        {
            return this.GetUsuPrivil();
        }

        public int GetUserType()
        {
            return IsAuthenticated() ? int.Parse(_accessor.HttpContext.User.GetUserType()) : 0;
        }

        public string GetGuid()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetGuid() : string.Empty;
        }

        public IEnumerable<long> GetAppsId()
        {
            return _accessor.HttpContext.User.GetApplications();
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : string.Empty;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }

        public static string GetName(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.Name);
            return claim?.Value;
        }

        public static string GetCompanyId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(CertpontoClaimTypes.CompanyId);
            return claim?.Value;
        }

        public static string GetEmployeeId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(CertpontoClaimTypes.EmployeeId);
            return claim?.Value;
        }

        public static string GetEmployeeCompanyId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(CertpontoClaimTypes.EmployeeCompanyId);
            return claim?.Value;
        }

        public static string GetUsuPrivil(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(CertpontoClaimTypes.UsuPrivil);
            return claim?.Value;
        }

        public static string GetUserType(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            //var claim = principal.FindFirst(CertpontoClaimTypes.UserType);
            //return claim?.Value;
            return "0";
        }

        public static string GetGuid(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            //var claim = principal.FindFirst(CertpontoClaimTypes.Guid);
            //return claim?.Value;
            return null;
        }

        public static IEnumerable<long> GetApplications(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var list = Enumerable.Empty<long>();
            var appsId = principal.FindAll(CertpontoClaimTypes.AppId);
            if (appsId != null)
            {
                foreach (var item in appsId)
                {
                    list.ToList().Add(long.Parse(item.Value));
                }
            }

            return list;
        }
    }
}
