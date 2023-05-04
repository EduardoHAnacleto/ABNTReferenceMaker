using ABNTReferenceMaker.Models.Enums;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ABNTReferenceMaker.Models
{
    public class Paper 
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        [Required]
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public int AuthorId { get; set; } // para o entity criar a FK
        public PaperType PaperType { get; set; }
        public int? Chapter { get; set; }
        public int? Edition { get; set; }
        public string? Editor { get; set; }

        [Display(Name = "Released on")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        [Display(Name = "Page")]
        public int? PageBeg { get; set; }
        [Display(Name = "End citation page")]
        public int? PageEnd { get; set; }
        public int? Version { get; set; }
        public string? Journal { get; set; }
        public bool? Cited { get; set; }
        [Display(Name = "Added on")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }

        public Paper()
        {
        }

        public Paper(int id, string title, string? subTitle, PaperType paperType, int? chapter, int? edition,
            string? editor, DateTime releaseDate, string? city, string? state, string? country, int? pageBeg,
            int? pageEnd, int? version, string? journal, bool cited, DateTime addDate)
        {
            Id = id;
            Title = title;
            SubTitle = subTitle;
            PaperType = paperType;
            Chapter = chapter;
            Edition = edition;
            Editor = editor;
            ReleaseDate = releaseDate;
            City = city;
            State = state;
            Country = country;
            PageBeg = pageBeg;
            PageEnd = pageEnd;
            Version = version;
            Journal = journal;
            Cited = cited;
            AddDate = addDate;
        }

        public ICollection<Paper> GetByType (PaperType type, List<Paper> list)
        {
            List<Paper> result = list.Where(p => p.PaperType == type).ToList();
            return result;
        }

        public ICollection<Paper> GetCited(bool status, List<Paper> list)
        {
            List<Paper> result = list.Where(p => p.Cited == status).ToList();
            return result;
        }

        public ICollection<Paper> GetByDateFoward (DateTime initial, DateTime? final, List<Paper> list)
        {
            if (final == null)
            {
                final = DateTime.MaxValue;
            }

            List<Paper> result = list.Where(p => p.ReleaseDate >= initial && p.ReleaseDate <= final).ToList();
            return result;
        }
    }
}
