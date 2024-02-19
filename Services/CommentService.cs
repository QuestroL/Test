using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Services.Commands;
using Services.DTO;
using Services.Mapper;

namespace Services
{
    public interface ICommentService
    {
        void AddComment(CreateUserCommentCommand model);
        IEnumerable<UserCommentModel> GetUsersComments();
        IEnumerable<UserCommentModel> GetByNickName(string nickName);
    }

    public class CommentService : ICommentService
    {
        private readonly ICommentsRepository _commentsRepository;
       
        public CommentService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public void AddComment(CreateUserCommentCommand model)
        {
            _commentsRepository.Create(model.MapModel());
        }

        public IEnumerable<UserCommentModel> GetUsersComments()
        {
            return _commentsRepository.Get().Select(x => x.MapModel());
        }

        public IEnumerable<UserCommentModel> GetByNickName(string nickName)
        {
            return _commentsRepository.Get(x => x.NickName.Equals(nickName)).Select(x => x.MapModel());
        }

        public void UpdateComment(UpdateCommentCommand model)
        {
            var userComment = _commentsRepository.GetById(model.Id);
            if (userComment != null) 
            { 
                userComment.Comment = model.Comment;
                userComment.CommentDate = DateTime.Now;
                userComment.IsUpdated = true;

                _commentsRepository.Update(userComment);
            }
        }
    }
}
