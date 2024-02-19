using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Commands;
using Services.DTO;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commnetService;

        public CommentController(ICommentService commnetService)
        {
            _commnetService = commnetService;
        }
        [HttpGet(Name = "GetAllComments")]
        public IEnumerable<UserCommentModel> GetAllComments()
        {
            return _commnetService.GetUsersComments();
        }

        [HttpGet(Name = "GetByNickName")]
        public IActionResult GetByNickName(string nickName)
        {

            if (nickName == null)
            {
                return ValidationProblem();
            }
            return Ok(_commnetService.GetByNickName(nickName));
        }

        [HttpPost]
        public IActionResult AddComment([FromBody]CreateUserCommentCommand model)
        {
            try
            {
                _commnetService.AddComment(model);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult UpdateComment([FromBody] UpdateCommentCommand model)
        {
            try
            {
                _commnetService.GetUsersComments();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
