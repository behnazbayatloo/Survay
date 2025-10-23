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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.Text).HasMaxLength(200).IsRequired(true);
            builder.HasMany(q => q.Answers).WithOne(a => a.Question).HasForeignKey(a=>a.QuestionId).OnDelete(DeleteBehavior.NoAction);


        }
    }
    
}
