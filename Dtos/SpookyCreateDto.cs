using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpookyApp.Dtos
{
    public class SpookyCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Desc { get; set; }

        //TODO: Check options for specifying video or photo format type
        //
    }
}
