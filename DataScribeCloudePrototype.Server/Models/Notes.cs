using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Notes
    {
        [Key]
        public int NotesId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        [ForeignKey("User")]
        public Guid CurrUserID { get; set; }
    }
}
