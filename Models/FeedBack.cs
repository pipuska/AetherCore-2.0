using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AetherCore.Models
{
    public class FeedBack
    {
        [Key]
        public int ID_OtZOV { get; set; }
        public string Text { get; set; }

        [ForeignKey("User")] 
        public int Id_Prepod { get; set; }

        [Column("Grade")]
        public int Grade { get; set; }

        public User User { get; set; }
    }
}
