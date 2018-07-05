using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommentsAssessmentProject.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(400)]
        public string Content { get; set; }

        public string Author { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PostedDateTime { get; set; }
    }
}
