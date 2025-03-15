using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXQ.DoAn.Data.Models
{
    public class Notification
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(255)]
        public string? Content { get; set; }

        public bool Read { get; set; }

        public bool Deliver { get; set; }

        public int Type { get; set; }

        // Khóa ngoại (tùy chọn)
        public long? OrderId { get; set; }
        public long? ProductId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order? Order { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }
    }
}
