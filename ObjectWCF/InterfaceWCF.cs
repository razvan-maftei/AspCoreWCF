using System.Collections.Generic;

using System.ServiceModel;
using PostComment;
using PostComment.DTO;

namespace ObjectWCF
{
    [ServiceContract]
    public interface InterfacePost {
        [OperationContract]
        bool AddPost(Post post);

        [OperationContract]
        Post UpdatePost(Post post);

        [OperationContract]
        int DeletePost(int id);

        [OperationContract]
        Post GetPostById(int id);

        [OperationContract]
        List<Post> GetPosts();
    }

    [ServiceContract]
    public interface InterfaceComment {
        [OperationContract]
        bool AddComment(Comment comment);

        [OperationContract]
        Comment UpdateComment(Comment newComment);

        [OperationContract]
        Comment GetCommentById(int id);
    }
    
    [ServiceContract]
    public interface ILoadData {
        [OperationContract]
        List<Post> GetAllPostsAndRelatedComments();
    }

    [ServiceContract]
    public interface IPostComment : InterfacePost, InterfaceComment, ILoadData {

    }
}
