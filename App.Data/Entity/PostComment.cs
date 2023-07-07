using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entity
{
	public class PostComment : IAuditEntity
	{
		[Key]
        public int Id { get; set; }

		[ForeignKey("Post")]

		public int PostId { get; set; }

        [ForeignKey("User")]

		public int UserId { get; set; }

        [Column(TypeName = "text"), DataType(DataType.Text)]

        public string Comment { get; set; }

		public bool IsActive { get; set; }
	
	}
}
