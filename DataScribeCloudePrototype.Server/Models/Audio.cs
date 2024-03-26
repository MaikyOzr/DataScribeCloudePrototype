using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Audio
    {
        [Key]
        public int AudioId { get; set; }
        public string UrlAidio { get; set; } = string.Empty;

        [ForeignKey("User")]
        public Guid CurrUserID { get; set; }
        public IEnumerator<Audio> GetEnumerator()
        {
            yield return this;
        }
    }
}
