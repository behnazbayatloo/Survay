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
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.Property(a => a.TextAnswer).HasMaxLength(200);
            builder.HasMany(a=>a.Votes).WithOne(v=>v.Answer).HasForeignKey(v=>v.AnswerId).OnDelete(DeleteBehavior.NoAction);
       
        }
    }
}
