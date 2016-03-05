namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        public int? ClientId { get; set; }

        public DateTime? OrderDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OrderTotal { get; set; }

        [StringLength(1)]
        public string OrderStatus { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
