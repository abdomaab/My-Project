using Domins.Models;


namespace Handlers.Interfaces
{
    public interface IUserUploadService
    {
        ValueTask<UserUpload> ReadById(int id);
        ValueTask<IEnumerable<UserUpload>> ReadAll();
        ValueTask<UserUpload> Create(UserUpload userUpload);
        ValueTask<UserUpload> Edit(UserUpload userUpload);
        ValueTask<UserUpload> Delete(int  id);

    }
}
