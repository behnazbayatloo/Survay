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
    public class PollConfiguration : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.HasMany(p=>p.Questions).WithOne(q=>q.Poll).HasForeignKey(q=>q.PollId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p=>p.CreatedBy).WithMany(a=>a.Polls).HasForeignKey(p=>p.AdminId).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
