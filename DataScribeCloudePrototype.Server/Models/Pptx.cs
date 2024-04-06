using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Pptx
    {
        [Key]
        public int PptxId { get; set; }
        public string PptxUrl { get; set; } = string.Empty;
        [ForeignKey("User")]
        public Guid CurrUserID { get; set; }
        public IEnumerator<Pptx> GetEnumerator()
        {
            yield return this;
        }
    }
}
