using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key para o usuário que comentou
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Author { get; set; }

        // Foreign key para o post comentado
        public Guid PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
