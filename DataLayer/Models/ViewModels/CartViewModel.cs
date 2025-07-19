using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class CartViewModel
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public UserViewModel User { get; set; }
        public List<CartItemViewModel> CartItemViewModels { get; set; }
    }
}
