using SJVN.Librarius.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Infrastructure
{
    /// <summary>
    /// Represent abstraction configuration to Entity base type
    /// </summary>
    public abstract class EntityConfiguration<T> : EntityTypeConfiguration<T>
        where T : Entity
    {
        /// <summary>
        /// Create new instance of EntityConfiguration
        /// </summary>
        /// <param name="hasDatabaseGeneratedOption">Whether entity will generate automatically identity for Id. Default is false</param>
        protected EntityConfiguration(bool hasDatabaseGeneratedOption = true)
        {
            HasKey(x => x.Id);

            if (hasDatabaseGeneratedOption)
            {
                Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            }
        }
    }
}