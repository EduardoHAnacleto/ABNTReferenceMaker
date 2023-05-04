using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ABNTReferenceMaker.Models
{
    public class Website : Paper
    {
        public int Id { get; set; }
        [Display(Name = "Accessed on")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AccessOn { get; set; }
        public string WebLink { get; set; }
        [Display(Name = "Link Status")]
        public bool LinkStatus { get; set; }

        public Website()
        {
            
        }

        public Website(DateTime accessOn, string webLink, bool linkStatus)
        {
            AccessOn = accessOn;
            WebLink = webLink;
            LinkStatus = linkStatus;
        }

        public ICollection<Website> GetByStatus (bool status, List<Website> list) 
        {
            List<Website> result = list.Where(p => p.LinkStatus == status).ToList();
            return result;
        }

        public ICollection<Website> GetByAccessOn(DateTime initial, DateTime? final, List<Website> list)
        {
            if (final == null)
            {
                final = DateTime.MaxValue;
            }

            List<Website> result = list.Where(p => p.AccessOn >= initial && p.ReleaseDate <= final).ToList();
            return result;
        }

    }
}
