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
    public class Poll_NUserConfiguration : IEntityTypeConfiguration<Poll_NUser>
    {
        public void Configure(EntityTypeBuilder<Poll_NUser> builder)
        {
            builder.HasKey(pn => new { pn.PollId, pn.VotedId });
            builder.HasOne(pn => pn.Voted).WithMany(nu => nu.Polls).HasForeignKey(p => p.VotedId);
            builder.HasOne(pn => pn.Poll).WithMany(p => p.Voted).HasForeignKey(p => p.PollId);

        }
    }
    
}
