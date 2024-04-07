using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataScribeCloudePrototype.Server.Repositories.Interfaces;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Pdf : IFileEntity
    {
        [Key]
        public int Id { get; set; }
        public string PDFUrl { get; set; } = string.Empty;
        [ForeignKey("User")]
        public Guid CurrUserID { get; set; }
        public IEnumerator<Pdf> GetEnumerator()
        {
            yield return this;
        }
    }
}
