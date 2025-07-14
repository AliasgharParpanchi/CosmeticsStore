using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class InterestConfig : EntityTypeConfiguration<Interest>
    {
        public InterestConfig()
        {
            ToTable("Interests");
            HasIndex(x=> new {x.UserId, x.ProductId}).IsUnique();
        }
    }
}
