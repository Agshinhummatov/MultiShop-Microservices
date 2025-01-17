using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;
using MultiShop.Comment.Services;

namespace MultiShop.Comment.Controllers
{

    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentService.GetComments();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _commentService.CreateComment(userComment);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var comment = _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }

            _commentService.DeleteComment(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentService.GetCommentById(id);
            if (value == null)
            {
                return NotFound("No comments found");
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _commentService.UpdateComment(userComment);
            return Ok("Comment updated successfully");
        }

        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _commentService.GetCommentsByProductId(id);
            return Ok(value);
        }

        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            int value = _commentService.GetActiveCommentCount();
            return Ok(value);
        }

        [HttpGet("GetPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            int value = _commentService.GetPassiveCommentCount();
            return Ok(value);
        }

        [HttpGet("GetTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            int value = _commentService.GetTotalCommentCount();
            return Ok(value);
        }

    }
}
