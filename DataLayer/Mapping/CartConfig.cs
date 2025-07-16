using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class CartConfig: EntityTypeConfiguration<Cart>
    {
        public CartConfig() {
            ToTable("Carts", "Cart");
            HasIndex(x=> x.UserId).IsUnique();

        }
    }
}
