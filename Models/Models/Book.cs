using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    public class Book
    {
       // [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; }
        public double Price { get; set; }
        [NotMapped] 
        public string PriceRange { get; set; }
        public BookDetail BookDetail { get; set; }
        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        public Publisher Publisher { get; set; }

        public List<BookAuthorMap> BookAuthorMap { get; set; }
    }
}
