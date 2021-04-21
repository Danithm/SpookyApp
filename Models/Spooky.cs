using System.ComponentModel.DataAnnotations;

namespace SpookyApp.Models
{
    public class Spooky
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength (250)]
        public string Desc { get; set; }

        //TODO: Check options for specifying video or photo format type
        //Add image/video pathing istead of file directly

        //[DisplayName("Upload File")]
        //public IFormFile 

    }
}
