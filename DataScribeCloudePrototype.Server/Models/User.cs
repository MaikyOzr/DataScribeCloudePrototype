using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataScribeCloudePrototype.Server.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public ICollection<Audio> Audios { get; set; } = new List<Audio>();
    public ICollection<DocFiles> DocFiles { get; set; } = new List<DocFiles>();
    public ICollection<Images> Images { get; set; } = new List<Images>();
    public ICollection<Notes> Notes { get; set; } = new List<Notes>();
    public ICollection<Pdf> Pdfs { get; set; } = new List<Pdf>();

}
