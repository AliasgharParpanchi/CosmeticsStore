using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class ProductConfig: EntityTypeConfiguration<Product>
    {
        public ProductConfig() {
            ToTable("Products", "Product");
            HasIndex(x=> x.ProductCode).IsUnique();
        }
    }
}
