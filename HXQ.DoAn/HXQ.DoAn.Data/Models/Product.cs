using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HXQ.DoAn.Data.Models
{
    /* Class này chứa các model liên quan đế product nói chung, bao gồm các bảng:
    *  Product
       Image
       Brand
       Sale
       ProductCategory
       Category
       Attribute
    */
    public class Product
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(20)]
        public string? Code { get; set; }
        public DateTime? CreateDate { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        // Khóa ngoại
        public long? BrandId { get; set; }
        public long? SaleId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public virtual Brand? Brand { get; set; }
        [ForeignKey(nameof(SaleId))]
        public virtual Sale? Sale { get; set; }
        // Quan hệ 1-n
        public virtual ICollection<Image>? Images { get; set; }
        public virtual ICollection<AttributeProduct>? AttributeProducts { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }

        // Quan hệ nhiều-nhiều với Category qua bảng trung gian
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
    }

    public class Image
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreateDate { get; set; }
        [MaxLength(255)]
        public string? ImageLink { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifyDate { get; set; }
        // Khóa ngoại
        public long? ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }
    }

    public class Brand
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreateDate { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [MaxLength(255)]
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifyDate { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        // Quan hệ 1-n
        public virtual ICollection<Product>? Products { get; set; }
    }

    public class Sale
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreateDate { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public int Discount { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifyDate { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        // Quan hệ 1-n
        public virtual ICollection<Product>? Products { get; set; }
    }

    public class ProductCategory
    {
        [Key]
        public long Id { get; set; }
        // Khóa ngoại
        public long CategoryId { get; set; }
        public long ProductId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }
    }

    public class Category
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreateDate { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifyDate { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        // Quan hệ nhiều-nhiều với Product qua bảng trung gian ProductCategory
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
    }

    public class AttributeProduct
    {
        [Key]
        public long Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public double Price { get; set; }
        public int Size { get; set; }
        public int Stock { get; set; }
        [MaxLength(270)]
        public string? Name { get; set; }
        // Khóa ngoại
        public long ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }
        // Quan hệ 1-n
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
