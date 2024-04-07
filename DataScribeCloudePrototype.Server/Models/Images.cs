using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataScribeCloudePrototype.Server.Repositories.Interfaces;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Images : IFileEntity
    {
        [Key]
        public int Id { get; set; }
        public string? UrlImage { get; set; } = string.Empty;
        [ForeignKey("User")]
        public Guid CurrUserID { get; set; }
        public IEnumerator<Images> GetEnumerator()
        {
            yield return this;
        }
    }
}
