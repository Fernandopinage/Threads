
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entity
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Relacionamento: Um usuário pode ter vários posts
        public virtual ICollection<Post> Posts { get; set; }

        // Relacionamento: Um usuário pode fazer vários comentários
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
