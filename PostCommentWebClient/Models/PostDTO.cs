using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PostCommentWebClient.Models
{
    [DataContract(IsReference = true)]
    public partial class PostDTO
    {
        public PostDTO()
        {
            this.Comments = new List<CommentDTO>();
        }

        [DataMember]
        public int PostId { get; set; }
        [DataMember]
        public string Domain { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [DataMember]
        public virtual List<CommentDTO> Comments { get; set; }
    }
}
