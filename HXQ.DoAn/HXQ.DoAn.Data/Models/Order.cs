using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXQ.DoAn.Data.Models
{
    /* Class này chứa các model liên quan đế order nói chung, bao gồm các bảng:
     * Order 
       OrderDetail
       OrderStatus
       Voucher
     */
    public class Order
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(255)]
        public string? Address { get; set; }
        public DateTime? CreateDate { get; set; }
        [MaxLength(50)]
        public string? Fullname { get; set; }
        public bool IsPending { get; set; }
        public DateTime? ModifyDate { get; set; }
        [MaxLength(1000)]
        public string? Note { get; set; }
        [MaxLength(11)]
        public string? Phone { get; set; }
        public DateTime? ShipDate { get; set; }
        public double Total { get; set; }
        // Các thông tin khác
        [MaxLength(25)]
        public string? Email { get; set; }
        [MaxLength(255)]
        public string? EcodeUrl { get; set; }
        public bool Seen { get; set; }
        [MaxLength(1000)]
        public string? Code { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        [MaxLength(1000)]
        public string? Shipment { get; set; }
        [MaxLength(1000)]
        public string? Payment { get; set; }
        // Khóa ngoại
        public long? AccountId { get; set; }
        public long? OrderStatusId { get; set; }
        public long? VoucherId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account? Account { get; set; }
        [ForeignKey(nameof(OrderStatusId))]
        public virtual OrderStatus? OrderStatus { get; set; }
        [ForeignKey(nameof(VoucherId))]
        public virtual Voucher? Voucher { get; set; }
        // Quan hệ 1-n
        public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        [Key]
        public long Id { get; set; }
        public double OriginPrice { get; set; }
        public int Quantity { get; set; }
        public double SellPrice { get; set; }
        // Khóa ngoại
        public long AttributeProductId { get; set; }
        public long OrderId { get; set; }
        [ForeignKey(nameof(AttributeProductId))]
        public virtual AttributeProduct? AttributeProduct { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order? Order { get; set; }
    }
    public class OrderStatus
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreateDate { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        public DateTime? UpdateDate { get; set; }
        // Quan hệ 1-n
        public virtual ICollection<Order>? Orders { get; set; }
    }

    public class Voucher
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(12)]
        public string? Code { get; set; }
        public int Count { get; set; }
        public DateTime? CreateDate { get; set; }
        public int Discount { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool IsActive { get; set; }
        // Quan hệ 1-n
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
