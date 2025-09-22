using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EF_CORE_EMPTY_CONTROLLER.Models
{
    public class Author
    {
        [Key]
        public int AuthId { get; set; }
        public string? AuthName { get; set; }
        public ICollection<Book>? Books { get; set; }

    }
}
