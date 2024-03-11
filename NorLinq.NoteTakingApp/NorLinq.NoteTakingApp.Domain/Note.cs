using NorLinq.NoteTakingApp.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace NorLinq.NoteTakingApp.Domain
{
    public class Note : Entity
    {
        public Note() { }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ColorCode { get; set; }
    }
}
