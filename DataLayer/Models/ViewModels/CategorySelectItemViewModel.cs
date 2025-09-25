using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class CategorySelectItemViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string DisplayName { get; set; } 
    }
}
