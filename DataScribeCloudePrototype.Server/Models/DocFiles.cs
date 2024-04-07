using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataScribeCloudePrototype.Server.Repositories.Interfaces;

namespace DataScribeCloudePrototype.Server.Models
{
    public class DocFiles : IFileEntity
    {
        [Key]
        public int Id { get; set; }
        public string DocUrl { get; set; } = string.Empty;
        [ForeignKey("User")]
        public Guid CurrUserID { get; set; }
        public IEnumerator<DocFiles> GetEnumerator()
        {
            yield return this;
        }
    }
}
