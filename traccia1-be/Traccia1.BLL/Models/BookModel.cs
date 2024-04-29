using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia1.DAL.Entities;

namespace Traccia1.BLL.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        [ForeignKey("AuthorId")]
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
