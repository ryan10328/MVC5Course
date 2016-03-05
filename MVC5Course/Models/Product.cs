namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int ProductId { get; set; }

        [Required]
        [StringLength(80)]
        public string ProductName { get; set; }

        [Required]
        [Range(2,99,ErrorMessage = "¼Æ¦r½Ð¤¶©ó 2 ~ 99")]
        [Column(TypeName = "smallmoney")]
        public decimal? Price { get; set; }

        [Required]
        public bool? Active { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public decimal? Stock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
