using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Images
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        public string? UrlImage { get; set; } = string.Empty;
        public string? UserID { get; set; } = string.Empty;
        public IEnumerator<Images> GetEnumerator()
        {
            yield return this;
        }
    }
}
