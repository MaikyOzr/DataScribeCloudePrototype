using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataScribeCloudePrototype.Server.Repositories.Interfaces;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Audio : IFileEntity
    {
        [Key]
        public int Id { get; set; }
        public string UrlAidio { get; set; } = string.Empty;

        [ForeignKey("User")]
        public Guid CurrUserID { get; set; }
        public IEnumerator<Audio> GetEnumerator()
        {
            yield return this;
        }
    }
}
