using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommentsAssessmentProject.Models
{
    public class CommentCore
    {
        [Required(ErrorMessage = "Please enter your message")]
        [MaxLength(400, ErrorMessage = "Your message is too long")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Your message")]
        public string CommentContent { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [MaxLength(100, ErrorMessage = "Your name is too long")]
        [DisplayName("Your name")]
        public string Author { get; set; }
    }

    public class Comment : CommentCore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PostedDateTime { get; set; }

        public int Votes { get; set; }

        public Comment Parent { get; set; }
        public List<Comment> Children { get; set; }

        public Comment()
        {
            Children = new List<Comment>();

        }
    }

    public class Reply : CommentCore
    {
        public int ParentId { get; set; }
    }


}
