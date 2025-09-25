using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class CartItemConfig: EntityTypeConfiguration<CartItem>
    {
        public CartItemConfig() {
            ToTable("CartItems", "Cart");
            HasIndex(x=> new {x.CartId, x.VariantIdCart}).IsUnique();
            HasRequired(x => x.VariantCart).WithMany(x => x.CartItems).HasForeignKey(x => x.VariantIdCart).WillCascadeOnDelete(false);
        }
    }
}
