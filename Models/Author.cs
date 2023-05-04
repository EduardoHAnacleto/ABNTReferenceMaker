using System.ComponentModel.DataAnnotations;

namespace ABNTReferenceMaker.Models
{
    public class Author
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public Author()
        {

        }

        public Author(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
