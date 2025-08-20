using DataLayer.Models;
using DataLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Specification
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductViewModel specParams)
       : base(p =>
           (string.IsNullOrEmpty(specParams.Search) || p.ProductName.Contains(specParams.Search)) &&
           (!specParams.CategoryIdSearch.HasValue || p.Categories.Any(pc => pc.CategoryId == specParams.CategoryIdSearch)) &&
           p.IsActive
       )
        {
            AddInclude(p => p.Categories);
            AddInclude(p => p.Variant);
            AddInclude(p => p.Interest);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.ProductName);
                        break;
                }
            }

            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }

        public ProductSpecification(int id) : base(p => p.ProductId == id)
        {
            AddInclude(p => p.Categories);
            AddInclude(p => p.Variant);
            AddInclude(p => p.Interest);
        }
    }
}
