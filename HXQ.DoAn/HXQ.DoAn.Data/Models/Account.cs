using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Class này chứa các model liên quan đế account nói chung, bao gồm các bảng:
 * Account 
   AccountDetail
   Role
 */

namespace HXQ.DoAn.Data.Models
{
    public class Account : IdentityUser<long>
    {
        public DateTime? CreateDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifyDate { get; set; }

        // Navigation: chi tiết tài khoản
        public virtual AccountDetail? AccountDetail { get; set; }
        // Navigation: giỏ hàng và đơn hàng của người dùng
        public virtual ICollection<CartItem>? CartItems { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }

    public class AccountDetail
    {
        [Key]
        public long Id { get; set; }

        public DateTime? Birthdate { get; set; }

        public DateTime? CreateDate { get; set; }

        [MaxLength(50)]
        public string? Fullname { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        [MaxLength(11)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        // Khóa ngoại: liên kết với Account
        public long? AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account? Account { get; set; }
    }

    public class Role : IdentityRole<long>
    {
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
