using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Column("email", TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [StringLength(5)]
        [Column("password", TypeName = "varchar(225)")]

        public string Password { get; set; }
        [Column("description", TypeName = "varchar(225)")]
        public string Description { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
