using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataScribeCloudePrototype.Server.Models;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

}
