using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class OrderConfig: EntityTypeConfiguration<Order>
    {
        public OrderConfig() {
            ToTable("Orders", "Order");
            HasIndex(x=> x.OrderCode).IsUnique();
            HasRequired(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            HasRequired(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressId).WillCascadeOnDelete(false);
        }
    }
}
