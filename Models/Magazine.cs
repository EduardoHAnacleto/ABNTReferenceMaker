using System.ComponentModel.DataAnnotations;

namespace ABNTReferenceMaker.Models
{
    public class Magazine : Paper
    {
        [Required]
        public string Name { get; set; }

        public Magazine()
        {
            
        }

        public Magazine(string name)
        {
            Name = name;
        }
    }
}
