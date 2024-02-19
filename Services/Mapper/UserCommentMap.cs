using DataLayer.Entity;
using Services.Commands;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public static class UserCommentMap
    {
        public static UserCommentModel MapModel(this UserComment userComment)
        {
            return new UserCommentModel()
            {
                Id = userComment.Id,
                Comment = userComment.Comment,
                CommentDate = userComment.CommentDate,
                NickName = userComment.NickName,
                IsUpdated = userComment.IsUpdated
            };
        }

        public static UserComment MapModel(this CreateUserCommentCommand userComment)
        {
            return new UserComment()
            {
                NickName = userComment.NickName,
                Comment = userComment.Comment,
                CommentDate = DateTime.Now
            };
        }
    }
}
