using System.ComponentModel.DataAnnotations;

//TODO: This class is redundant, implement create dto instead

namespace SpookyApp.Dtos
{
    public class SpookyUpdateDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Desc { get; set; }

        //TODO: Check options for specifying video or photo format type
    }
}
