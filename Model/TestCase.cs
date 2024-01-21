using System.ComponentModel.DataAnnotations.Schema;

namespace TestCaseApplication.Model
{
    public class TestCase
    {
        public long Id { get; set; }
        public string Input1 { get; set; }
        public string Input2 { get; set; }
        public string Result { get; set; }
        public TestCaseStatus Status { get; set; }

        [ForeignKey("ProjectId")]
        public long ProjectId { get; set; }
    }
}
