using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ABNTReferenceMaker.Models
{
    public class Book : Paper
    {

        [Display(Name = "Total Number of Pages")]
        public int TotalPagesNum { get; set; }
        public Paper Paper { get; set; } = new Paper();

        public Book()
        {
            
        }

        public Book(int totalPagesNum, Paper paper)
        {
            TotalPagesNum = totalPagesNum;
            Paper = paper;
        }
    }
}
