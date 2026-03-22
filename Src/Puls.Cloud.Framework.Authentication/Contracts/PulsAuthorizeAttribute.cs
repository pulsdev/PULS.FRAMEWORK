using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace Puls.Cloud.Framework.Authentication.Contracts
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PulsAuthorizeAttribute : AuthorizeAttribute
    {
        public PulsAuthorizeAttribute([Required] string policy, string? permission = null) : base(policy)
        {
            Permission = permission;
        }

        public string? Permission { get; }
    }
}