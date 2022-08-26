using Dojo.Bakery.BuildingBlocks.Commons.ModelContracts;
using Microsoft.AspNetCore.Identity;

namespace Dojo.Bakery.Security.Domain
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>, IAggregateRoot, IEntity
    {
    }
}
