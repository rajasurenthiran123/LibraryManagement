using LBMS_V1.Models;
using LBMS_V1.NewFolder;

namespace LBMS_V1
{
    public interface ILibrary
    {  
         Task CreateBookAsync(CreateBookDTO book);

        Task<bool> UpdateBookAsync(int id, CreateBookDTO bookDto);
        Task<bool> DeleteBookAsync(int id);

        Task<IEnumerable<Books>> GetAllBooksAsync();



    }
}
