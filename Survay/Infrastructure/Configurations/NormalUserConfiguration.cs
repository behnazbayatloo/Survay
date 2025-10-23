using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Infrastructure.Configurations
{
    public class NormalUserConfiguration :  IEntityTypeConfiguration<NormalUser>
    {
        public void Configure(EntityTypeBuilder<NormalUser> builder)
        {
            builder.Property(u => u.UserName).HasMaxLength(200).IsRequired(true);
            builder.Property(u => u.Password).HasMaxLength(200).IsRequired(true);
            builder.HasMany(nu=>nu.Votes).WithOne(v=>v.AnsweredBy).HasForeignKey(v=>v.NormalUserId).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
