using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class UserCommentModel
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string Comment { get; set; }

        public DateTime CommentDate { get; set; }
        public bool IsUpdated { get; set; }
    }
}
