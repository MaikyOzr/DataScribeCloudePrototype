using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataScribeCloudePrototype.Server.Models
{
    public class DocFiles
    {
        [Key]
        public int DocId { get; set; }
        public string DocUrl { get; set; } = string.Empty;
        public User? UserID { get; set; }
        public IEnumerator<DocFiles> GetEnumerator()
        {
            yield return this;
        }
    }
}
