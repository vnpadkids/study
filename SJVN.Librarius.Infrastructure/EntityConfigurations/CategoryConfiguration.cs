using SJVN.Librarius.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Infrastructure.EntityConfigurations
{
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        public CategoryConfiguration() : base(true)
        {
            Property(x => x.Name)
                .IsRequired();

            // DDC must be unique
            Property(x => x.DDC)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_DDC", 1) { IsUnique = true }));
        }

    }
}
