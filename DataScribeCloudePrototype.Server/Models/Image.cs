using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Image
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        public string? UrlImage { get; set; }
        [ForeignKey("User")]
        public string? CurrUserID { get; set; }
        public IEnumerator<Image> GetEnumerator()
        {
            yield return this;
        }
    }
}
