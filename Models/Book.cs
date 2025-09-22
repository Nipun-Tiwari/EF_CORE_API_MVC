using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CORE_EMPTY_CONTROLLER.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateOnly PublicationYear { get; set; }
        public int AuthId { get; set; }

        //Navigation Property
        [ForeignKey("AuthId")]
        public Author Author { get; set; }
    }
}
