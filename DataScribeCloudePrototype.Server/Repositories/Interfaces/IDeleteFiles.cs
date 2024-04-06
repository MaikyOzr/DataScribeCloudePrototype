using DataScribeCloudePrototype.Server.Repositories.Enums;
using System.Threading.Tasks;

namespace DataScribeCloudePrototype.Server.Repositories.Interfaces
{
    public interface IDeleteFiles
    {
        Task DeleteFile(FileType fileType, int id);
    }
}
