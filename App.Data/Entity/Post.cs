using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
    public class Post : BaseAuditEntity // Bunu News gibi işlerde kullanabiliyoruz Ancak poliklinikler için Departman Post ile Include ediyoruz.
    {

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public int PostImageId { get; set; }

        [ForeignKey(nameof(PostImageId))]
        public PostImage? PostImage { get; set; }


        [MaxLength(200, ErrorMessage = "The {0} cannot exceed 200 characters."), MinLength(1, ErrorMessage = "The {0} must be at least 1 characters."), Required(ErrorMessage = "The {0} field cannot be left blank!"), Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName ="ntext"),DataType(DataType.Text)]

        public string Content { get; set; }

        public List<PostComment>? Comments { get; set; }

        // 5 dakikaya geliyorum.
    }
}
