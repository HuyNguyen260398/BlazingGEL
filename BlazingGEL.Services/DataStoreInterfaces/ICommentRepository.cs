﻿using BlazingGEL.CoreBusiness.Models;

namespace BlazingGEL.Services.DataStoreInterfaces;

public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<IEnumerable<Comment>> GetCommentsByPostAsync(int postId);
}
