using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class Product_VariantConfig : EntityTypeConfiguration<ProductVariant>
    {
        public Product_VariantConfig()
        {
            ToTable("ProductVariants", "Product");
            Property(p => p.VariantId).HasColumnName("VariantId");
        }
    }
}
