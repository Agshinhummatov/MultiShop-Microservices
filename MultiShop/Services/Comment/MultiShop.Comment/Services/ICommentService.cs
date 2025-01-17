using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Services
{
    public interface ICommentService
    {
        List<UserComment> GetComments();
        UserComment GetCommentById(int id);
        void CreateComment(UserComment userComment);
        void UpdateComment(UserComment userComment);
        void DeleteComment(int id);
        List<UserComment> GetCommentsByProductId(string productId);
        int GetActiveCommentCount();
        int GetPassiveCommentCount();
        int GetTotalCommentCount();
    }
}
