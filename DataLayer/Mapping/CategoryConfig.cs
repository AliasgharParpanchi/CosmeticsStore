using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class CategoryConfig: EntityTypeConfiguration<Category>
    {
        public CategoryConfig() {

            HasOptional(c => c.Parent)
           .WithMany(c => c.Children)
           .HasForeignKey(c => c.ParentId)
           .WillCascadeOnDelete(false);

            Property(c => c.MainSystemType)
           .HasColumnType("int");

            Property(c => c.SubSystemType)
           .HasColumnType("int");
        }
    }
}
