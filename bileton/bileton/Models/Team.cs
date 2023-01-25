using System.ComponentModel.DataAnnotations.Schema;

namespace bileton.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string? Image { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twiter
        {
            get; set;
        }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
