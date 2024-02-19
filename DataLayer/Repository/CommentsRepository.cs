using DataLayer.Entity;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.Repository
{
    public interface ICommentsRepository : IBaseRepositoty<UserComment>
    { 
    
    }

    public  class CommentsRepository : BaseRepositoty<UserComment>, ICommentsRepository
    {
        public CommentsRepository(DbContext dbContext)
            :base(dbContext)
        {
            
        }
    }
}
