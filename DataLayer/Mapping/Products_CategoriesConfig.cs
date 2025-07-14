using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class Products_CategoriesConfig: EntityTypeConfiguration<Products_Categories>
    {
        public Products_CategoriesConfig() {
            ToTable("Products_Categories", "Product");
            HasRequired(x => x.Categories).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);
            HasIndex(x => new { x.CategoryId, x.ProductId }).IsUnique();
        }
    }
}
