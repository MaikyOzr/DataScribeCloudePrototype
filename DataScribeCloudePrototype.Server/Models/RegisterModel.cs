namespace DataScribeCloudePrototype.Server.Models
{
    public record RegisterModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfPassword { get; set; }
    }
}
