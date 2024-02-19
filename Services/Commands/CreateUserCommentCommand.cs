using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands
{
    public class CreateUserCommentCommand
    {
        public required string Comment { get; set; }
        public required string NickName { get; set; }
    }
}
