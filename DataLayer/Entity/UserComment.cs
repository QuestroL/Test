using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace DataLayer.Entity
{
    [Table("usersComments")]
    public class UserComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [PropertyTab("id")]
        public int Id { get; set; }

        [PropertyTab("Comment")]
        [NotNull]
        public  string Comment { get; set; }

        [PropertyTab("CommentDate")]
        [NotNull]
        public DateTime CommentDate { get; set; }

        [PropertyTab("NickName")]
        [NotNull]
        public string NickName { get; set; }
        
        [PropertyTab("IsUpdated")]
        [DefaultValue(false)]
        public bool IsUpdated { get; set; }
    }
}
