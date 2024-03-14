using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Audio
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AudioId { get; set; }
        public string? UrlAidio { get; set; }
        public string? CurrUserID { get; set; }
        public IEnumerator<Audio> GetEnumerator()
        {
            yield return this;
        }
    }
}
