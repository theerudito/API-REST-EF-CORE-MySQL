using System.ComponentModel.DataAnnotations;

namespace EF_MySQL.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        [MaxLength(60)]
        public string Clan { get; set; } = null!;
    }
}
