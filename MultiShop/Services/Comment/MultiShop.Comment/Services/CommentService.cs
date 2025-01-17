using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentContext _context;

        public CommentService(CommentContext context)
        {
            _context = context;
        }

        public List<UserComment> GetComments()
        {
            return _context.UserComments.ToList();
        }

        public UserComment GetCommentById(int id)
        {
            return _context.UserComments.Find(id);
        }

        public void CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
        }

        public void UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = _context.UserComments.Find(id);
            if (comment != null)
            {
                _context.UserComments.Remove(comment);
                _context.SaveChanges();
            }
        }

        public List<UserComment> GetCommentsByProductId(string productId)
        {
            return _context.UserComments.Where(x => x.ProductId == productId).ToList();
        }

        public int GetActiveCommentCount()
        {
            return _context.UserComments.Count(x => x.Status == true);
        }

        public int GetPassiveCommentCount()
        {
            return _context.UserComments.Count(x => x.Status == false);
        }

        public int GetTotalCommentCount()
        {
            return _context.UserComments.Count();
        }
    }

}
