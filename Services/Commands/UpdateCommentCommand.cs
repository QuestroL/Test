using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands
{
    public class UpdateCommentCommand
    {
        public int Id { get; set; }
        public required string Comment { get; set; }
    }
}
