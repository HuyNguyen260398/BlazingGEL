using BlazingGEL.CoreBusiness.Dtos;

namespace BlazingGEL.WASM.ServiceInterfaces;

public interface ICommentRepository : IBaseRepository<CommentDto>
{
    Task<IEnumerable<CommentDto>> GetByPostAsync(string url, int postId);
}
