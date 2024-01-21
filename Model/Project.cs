using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseApplication.Model
{
    public class Project
    {
        [Key]
        public long Id { get; set; }
        public string ProjectTitle { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; } 
    }
}
