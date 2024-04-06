
namespace DataScribeCloudePrototype.Server.Service.Interfaces
{
    public interface IUpdateNotes
    {
        Task UpdateNotes(int id, string title, string content);
    }
}
