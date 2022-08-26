using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Bakery.Security.Domain
{
    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
    }
}
