using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataScribeCloudePrototype.Server.Models
{
    public class Image
    {
        [Key]
        public Guid ImageId { get; set; }
        public string UrlImage { get; set; } = string.Empty;
        public User? UserID { get; set; }
        public IEnumerator<Image> GetEnumerator()
        {
            yield return this;
        }
    }
}
