using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Pdf
    {
        [Key]
        public Guid PDFId { get; set; }
        public string PDFUrl { get; set; } = string.Empty;
        public User? CurrUserID { get; set; }
        public IEnumerator<Pdf> GetEnumerator()
        {
            yield return this;
        }
    }
}
