using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AetherCore.Models
{
    public class User
    {
        [Key]
        public int? Id_Prepod { get; set; }
        public string? Name { get; set; }
        [Column("GradeO")]
        public double? GradeO { get; set; }
        public string? Avatat { get; set; }
        public string? opisanie { get; set; }

        public List<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();

    }
}
