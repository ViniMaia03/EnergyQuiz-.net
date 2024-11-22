using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnergyQuiz.Models
{
    public class User
    {
        internal bool isActive;

        public string Email { get; internal set; }
        public string Password { get; internal set; }
        public string Name { get; internal set; }
        public int Id { get; internal set; }

        [Table("table_user_pb")]
        public class user
        {
            [Key]
            public int Id { get; set; }
            [Column("name_pb")]
            public string Name { get; set; } = "Sem Nome";
            [Column("email_pb")]
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;
            [Column("password_pb")]
            [Required]
            [StringLength(50)]
            [MinLength(6)]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
            [Column("status_active_pb")]
            public bool isActive { get; set; } = true;
            [Column("role_pb")]
            public string Role { get; set; } = "User";
            [Column("avatar_pb")]
            public string Avatar { get; set; } = "https://images.vexels.com/media/users/3/145908/raw/52eabf633ca6414e60a7677b0b917d92-criador-de-avatar-masculino.jpg";
        }
    }
}
