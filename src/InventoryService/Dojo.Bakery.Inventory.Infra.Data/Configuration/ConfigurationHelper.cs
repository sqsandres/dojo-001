using Dojo.Bakery.BuildingBlocks.Commons;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Bakery.Inventory.Infra.Data.Configuration
{
    public static class ConfigurationHelper
    {
        public static void ConfigureBase<T>(this EntityTypeBuilder<T> builder) where T : Entity
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).IsRequired();
        }
        public static void ConfigureAuditable<T>(this EntityTypeBuilder<T> builder) where T : Entity
        {
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.UpdatedOn);
        }
    }
}
