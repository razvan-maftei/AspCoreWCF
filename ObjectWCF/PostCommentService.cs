using System.Collections.Generic;
using System.ServiceModel;
using AutoMapper;
using PostComment;
using PostComment.APIStatic;
using PostComment.DTO;

namespace ObjectWCF {
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PostCommentService {

        private readonly MapperConfiguration config;
        private readonly IMapper iMapper;

        public PostCommentService()
        {
            config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Post, PostDTO>();
                    cfg.CreateMap<Comment, CommentDTO>();
                    cfg.CreateMap<PostDTO, Post>();
                    cfg.CreateMap<CommentDTO, Comment>();
                });
            iMapper = config.CreateMapper();
        }

        public void Cleanup()
        {
            Cleanup();
        }

        public List<PostDTO> GetAllPosts()
        {
            var lp = API.GetAllPosts();
            var lpDto = new List<PostDTO>();
            lpDto = iMapper.Map<List<Post>, List<PostDTO>>(lp);
            return lpDto;
        }

        public void DeleteComment(CommentDTO comment)
        {
            var comm = new Comment();
            comm = iMapper.Map<CommentDTO, Comment>(comment);
            API.DeleteComment(comm);
        }

        public PostDTO GetPostById(int id)
        {
            Post post = API.GetPostById(id);
            var postDTO = iMapper.Map<Post, PostDTO>(post);
            return postDTO;
        }

        public PostDTO SubmitPost(PostDTO postDTO)
        {
            Post post = new Post();
            post = iMapper.Map<PostDTO, Post>(postDTO);
            API.AddPost(post);
            postDTO = iMapper.Map<Post, PostDTO>(post);
            return postDTO;
        }

        public PostDTO UpdatePost(PostDTO newPost)
        {
            Post post = iMapper.Map<PostDTO, Post>(newPost);
            API.UpdatePost(post);
            PostDTO postDTO = iMapper.Map<Post, PostDTO>(post);
            return postDTO;
        }

        public int DeletePost(int postId)
        {
            return  API.DeletePost(postId);
        }

        public CommentDTO GetCommentById(int id)
        {
            Comment comment = API.GetCommentById(id);
            CommentDTO commentDTO = iMapper.Map<Comment, CommentDTO>(comment);
            return commentDTO;
        }

        public CommentDTO SubmitComment(CommentDTO commentDTO)
        {
            Comment comment = iMapper.Map<CommentDTO, Comment>(commentDTO);
            API.AddComment(comment);
            CommentDTO commDTO = iMapper.Map<Comment, CommentDTO>(comment);
            return commDTO;
        }

        public CommentDTO UpdateComment(CommentDTO oldCommentDTO, CommentDTO newCommentDTO)
        {
            Comment oldComment = iMapper.Map<CommentDTO, Comment>(oldCommentDTO);
            Comment newComment = iMapper.Map<CommentDTO, Comment>(newCommentDTO);
            Comment comment = API.UpdateComment(newComment);
            CommentDTO comm = iMapper.Map<Comment, CommentDTO>(comment);
            return comm;
        }

        public int DeleteComment(int commentId)
        {
            return API.DeleteComment(commentId);
        }

        List<PostDTO> GetAllPostsAndRelatedComments()
        {
            return GetAllPosts();
        }

    }
}