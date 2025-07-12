using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class Product_VariantConfig : EntityTypeConfiguration<Product_Variant>
    {
        public Product_VariantConfig()
        {
            ToTable("Product_Variants", "Product"); 
        }
    }
}
