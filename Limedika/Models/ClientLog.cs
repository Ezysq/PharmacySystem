using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Limedika.Models
{
    [Table("client_logs")]
    public class ClientLog
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        [Column("action")]
        public string Action { get; set; }

        [Column("date_time")]
        public DateTime DateTime { get; set; }

        public ClientLog(String name, String action)
        {
            this.Name = name;
            this.Action = action;
            this.DateTime = DateTime.UtcNow;
        }
    }
}
