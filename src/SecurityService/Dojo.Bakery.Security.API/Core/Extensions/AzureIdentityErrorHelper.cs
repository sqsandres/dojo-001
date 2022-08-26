using Microsoft.AspNetCore.Identity;
using System.Text;

namespace Dojo.Bakery.Security.API.Core.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class AzureIdentityErrorHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static string GetErrors(IEnumerable<IdentityError> errors)
        {
            StringBuilder errorDescription = new StringBuilder();
            foreach (IdentityError error in errors)
            {
                errorDescription.AppendLine(error.Description);
            }
            return errorDescription.ToString();
        }
    }
}