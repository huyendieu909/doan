using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXQ.DoAn.Data.Models
{

    public class CartItem
    {
        [Key]
        public long Id { get; set; }

        public int Quantity { get; set; }

        public double LastPrice { get; set; }

        public bool IsActive { get; set; }

        // Khóa ngoại: liên kết với Account và ProductAttribute
        public long? AccountId { get; set; }
        public long? AttributeProductId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account? Account { get; set; }

        [ForeignKey(nameof(AttributeProductId))]
        public virtual AttributeProduct? AttributeProduct { get; set; }
    }
}
