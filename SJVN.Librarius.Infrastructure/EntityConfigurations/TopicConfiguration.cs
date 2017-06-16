using SJVN.Librarius.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.Infrastructure.EntityConfigurations
{
    public class TopicConfiguration : EntityConfiguration<Topic>
    {
        public TopicConfiguration() : base(true)
        {
            Property(x => x.Name).IsRequired();
        }
    }
}
