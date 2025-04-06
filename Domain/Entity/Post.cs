using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key para o autor do post
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Author { get; set; }

        // Relacionamento: Um post pode ter vários comentários
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
