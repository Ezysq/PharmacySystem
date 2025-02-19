using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limedika.Models
{
    [Table("clients")]
    public class Client
    {
        [Key]
        [Column("name")]
        public required string Name { get; set; }

        [Column("address")]
        public required string Address { get; set; }

        [Column("post_code")]
        public string PostCode { get; set; }

    }
}
